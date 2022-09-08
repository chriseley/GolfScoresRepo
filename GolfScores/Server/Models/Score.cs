using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Keyless]
public class Score
{
    [ForeignKey(nameof(Golfer))]
    public string GolferId { get; set; }

    [ForeignKey(nameof(Course))]
    public string CourseId { get; set; }

    [Required]
    public string NewScore { get; set; }
}