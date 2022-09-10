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
        try
        {
            if (model == null) return false;

            var scoreEntity = new Score
            {
                GolferId = model.GolferId,
                CourseId = model.CourseId,
                NewScore = model.Score
            };

            await _context.Scores.AddAsync(scoreEntity);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex) 
        {

            throw new Exception(ex.Message);

        }
        return true;
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
                        Id = entity.Id,
                        CourseId = entity.CourseId,
                        GolferId = entity.GolferId,
                        Score = entity.NewScore
                    });

        return await scoreQuery.ToListAsync();
    }

    public async Task<ScoreDetail> GetScoreByGolferIdAsync(int golferId)
    {
        var scoreQuery = await _context.Scores.FindAsync(golferId);

        if (scoreQuery == null) return null;

        return new ScoreDetail() {
        Id = scoreQuery.Id,
        CourseId = scoreQuery.CourseId,
        GolferId = scoreQuery.GolferId,
        Score = scoreQuery.NewScore
        };

    }
}