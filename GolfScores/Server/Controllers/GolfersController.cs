using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class GolfersController : ControllerBase
{
    private readonly IGolferService _golferService;

    public GolfersController(IGolferService golferService)
    {
        _golferService = golferService;
    }

    [HttpGet]
    public async Task<List<ListGolfers>> Index()
    {
        var golfers = await _golferService.GetAllGolfersAsync();
        return golfers.ToList();
    }

    [HttpGet]
    public async Task<IActionResult> Golfer(int id)
    {
        var golfer = await _golferService.GetGolferByIdAsync(id);
        if (golfer == null) return NotFound();
        return Ok(golfer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GolferCreate model)
    {
        if (model == null) return BadRequest();

        bool wasSuccessful = await _golferService.CreateGolferAsync(model);

        if (wasSuccessful) return Ok();
        else return UnprocessableEntity();
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
        var golfer = await _golferService.GetGolferByIdAsync(id);

        if (golfer == null) return NotFound();

        bool wasSuccessful = await _golferService.DeleteGolferAsync(id);

        if (!wasSuccessful) return BadRequest();

        return Ok();
    }
}

