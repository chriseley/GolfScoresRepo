using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]

public class GolfersController : ControllerBase
{
    private readonly IGolferService _golferService;
    public GolfersController(IGolferService golferService)
    {
        _golferService = golferService;
    }

    [HttpGet]
    public async Task<IActionResult> GetGolfers()
    {
        var golfers = await _golferService.GetAllGolfersAsync();

        return Ok(golfers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Golfer(int id)
    {
        var golfer = await _golferService.GetGolferByIdAsync(id);

        if (golfer == null) return NotFound();

        return Ok(golfer);
    }

    [HttpPost]
    public async Task<IActionResult> AddGolfer(GolferCreate model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest();

        bool wasSuccesssful = await _golferService.CreateGolferAsync(model);

        if (wasSuccesssful) return Ok();
        return UnprocessableEntity();
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> Edit(int id, GolferEdit model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest();

        if (model.Id != id) return BadRequest();

        bool wasSuccessful = await _golferService.UpdateGolferAsync(model);

        if (wasSuccessful) return Ok();

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _golferService.GetGolferByIdAsync(id);

        if (course == null) return NotFound();

        bool wasSuccessful = await _golferService.DeleteGolferAsync(id);

        if (!wasSuccessful) return BadRequest();

        return Ok();
    }


}

