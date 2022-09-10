using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
    private readonly ICourseService _courseService;
    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CourseInfo(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);

        if (course == null) return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CourseCreate model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest();

        bool wasSuccesssful = await _courseService.CreateCourseAsync(model);

        if (wasSuccesssful) return Ok();
        return UnprocessableEntity();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, CourseEdit model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest();

        if (model.Id != id) return BadRequest();

        bool wasSuccessful = await _courseService.UpdateCourseAsync(model);

        if (wasSuccessful) return Ok();

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);

        if (course == null) return NotFound();

        bool wasSuccessful = await _courseService.DeleteCourseAsync(id);

        if (!wasSuccessful) return BadRequest();

        return Ok();
    }

    
    }

