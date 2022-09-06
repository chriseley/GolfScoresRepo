using Microsoft.EntityFrameworkCore;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;
    
    public CourseService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<bool> CreateCourseAsync(CourseCreate model)
    {
        if (model == null) return false;

        var courseEntity = new Course
        {
            Name = model.Name,
            CourseRating = model.CourseRating
        };

        _context.Courses.Add(courseEntity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        var entity = await _context.Courses.FindAsync(courseId);
        if (entity == null) return false;

        _context.Courses.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ListCourses>> GetAllCoursesAsync()
    {
        var courseQuery =
            _context
                .Courses
                .Select(entity =>
                    new ListCourses
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                    });

        return await courseQuery.ToListAsync();
    }

    public async Task<CourseDetail> GetCourseByIdAsync(int courseId)
    {
     var courseEntity = await _context
            .Courses
            .FirstOrDefaultAsync(c => c.Id == courseId);

        if (courseEntity == null)
            return null;

        var detail = new CourseDetail
        {
            Id = courseEntity.Id,
            Name = courseEntity.Name,
            CourseRating = courseEntity.CourseRating
        };
        return detail;
    }

    public async Task<bool> UpdateCourseAsync(CourseEdit model)
    {
        if (model == null) return false;

        var entity = await _context.Courses.FindAsync(model.Id);

        if (entity == null) return false;

        entity.Name = model.Name;
        entity.CourseRating = model.CourseRating;

        return await _context.SaveChangesAsync() == 1;
       
    }
}