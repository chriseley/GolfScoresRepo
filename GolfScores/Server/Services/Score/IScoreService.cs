public interface IScoreService
{
    Task<IEnumerable<ListScores>> GetAllScoresAsync();
    Task<bool> CreateScoreAsync(ScoreCreate model);
    Task<ScoreDetail> GetScoreByGolferIdAsync(int golferId);
    Task<bool> DeleteScoreAsync(int scoreId);
}