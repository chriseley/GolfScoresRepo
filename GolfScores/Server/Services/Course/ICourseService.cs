public interface ICourseService
{
    Task<IEnumerable<ListCourses>> GetAllCoursesAsync();
    Task<bool> CreateCourseAsync(CourseCreate model);
    Task<CourseDetail> GetCourseByIdAsync(int courseId);
    Task<bool> UpdateCourseAsync(CourseEdit model);
    Task<bool> DeleteCourseAsync(int courseId);
}
