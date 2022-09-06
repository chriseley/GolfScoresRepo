using System.Data.Entity;

public class GolferService : IGolferService
{
    async Task<bool> CreateGolferAsync(GolferCreate model)
    {
        var golferEntity = new Golfer
        {
            Name = model.Name,
            Age = model.Age,
            HomeCourse = model.HomeCourse
        };
        
        _context.Golfers.Add(golferEntity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteGolferAsync(int golferId)
    {
        var entity = await _context.Golfers.FindAsync(golferId);
        if (entity == null)
            return false;

        _context.Golfers.Remove(entity);
        return await _context.SaveChangesAsync() == 1; 
    }

    public async Task<IEnumerable<ListGolfers>> GetAllGolfersAsync()
    {
        var golferQuery =
             _context
             .Golfers
             .Select(entity =>
                 new ListGolfers
                 {
                     Id = entity.Id,
                     Name = entity.Name,
                 });
        return await golferQuery.ToListAsync();
    }

    public async Task<GolferDetail> GetGolferByIdAsync(int golferId)
    {
        var golferEntity = await _context
            .Golfers
            .FirstOrDefaultAsync(g => g.Id == golferId);

        if (golferEntity == null)
            return null;

        var detail = new GolferDetail
        {
            Name = golferEntity.Name,
            Age = golferEntity.Age,
            HomeCourse = golferEntity.HomeCourse
        };
        return detail;
    }

    public async Task<bool> UpdateGolferAsync(GolferEdit model)
    {
        if (model == null) return false;

        var entity = await _context.Golfers.FindAsync(model.Id);

        if (entity == null) return false;

        entity.Name = model.Name;
        entity.Age = model.Age;
        entity.HomeCourse = model.HomeCourse;

        return await _context.SaveChangesAsync() == 1;
    }

    private readonly ApplicationDbContext _context;
    
    public GolferService(ApplicationDbContext context)
    {
        _context = context;
    }

    private string _golferId;

    public void SetGolferId(string golferId) => _golferId = golferId;

    Task<bool> IGolferService.CreateGolferAsync(GolferCreate model)
    {
        throw new NotImplementedException();
    }
}
