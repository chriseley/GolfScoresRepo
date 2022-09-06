public interface IGolferService
{
    Task<IEnumerable<ListGolfers>> GetAllGolfersAsync();
    Task<bool> CreateGolferAsync(GolferCreate model);
    Task<GolferDetail> GetGolferByIdAsync(int golferId);
    Task<bool> UpdateGolferAsync(GolferEdit model);
    Task<bool> DeleteGolferAsync(int golferId);
    void SetGolferId(string golferId);
}
