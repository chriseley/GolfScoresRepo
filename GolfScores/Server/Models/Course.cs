using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string CourseRating { get; set; }
}
