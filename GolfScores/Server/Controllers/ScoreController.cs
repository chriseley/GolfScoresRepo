using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class ScoreController : ControllerBase
{
    private readonly IScoreService _scoreService;

    public ScoreController(IScoreService scoreService)
    {
        _scoreService = scoreService;
    }

    [HttpGet]
    public async Task<List<ListScores>> GetAllScores()
    {
        var scores = await _scoreService.GetAllScoresAsync();
        return scores.ToList();
    }

    [HttpPost]
    public async Task<IActionResult> PostScore(ScoreCreate model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest();

        bool wasSuccessful = await _scoreService.CreateScoreAsync(model);

        if (wasSuccessful) return Ok();
        return UnprocessableEntity();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var score = await _scoreService.GetScoreByGolferIdAsync(id);

        if (score == null) return NotFound();

        bool wasSuccessful = await _scoreService.DeleteScoreAsync(id);

        if (!wasSuccessful) return BadRequest();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ScoreInfo(int id)
    {
        var score = await _scoreService.GetScoreByGolferIdAsync(id);

        if (score == null) return NotFound();

        return Ok(score);
    }

}

