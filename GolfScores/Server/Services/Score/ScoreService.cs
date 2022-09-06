using Microsoft.EntityFrameworkCore;

public class ScoreService : IScoreService
{
    private readonly ApplicationDbContext _context;
    
    public ScoreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateScoreAsync(ScoreCreate model)
    {
        if (model == null) return false;

        var scoreEntity = new Score
        {
            NewScore = model.Score
        };

        _context.Scores.Add(scoreEntity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteScoreAsync(int scoreId)
    {
        var entity = await _context.Scores.FindAsync(scoreId);

        if (entity == null) return false;

        _context.Scores.Remove(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ListScores>> GetAllScoresAsync()
    {
        var scoreQuery =
            _context
                .Scores
                .Select(entity =>
                    new ListScores
                    {
                        CourseId = entity.CourseId,
                        GolferId = entity.GolferId,
                        Score = entity.NewScore
                    });

        return await scoreQuery.ToListAsync();
    }

    public Task<ScoreDetail> GetScoreByGolferIdAsync(int golferId)
    {
        throw new NotImplementedException();
    }
}