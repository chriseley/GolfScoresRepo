using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Keyless]
public class Score
{
    [ForeignKey(nameof(Golfer))]
    public int GolferId { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    [Required]
    public int NewScore { get; set; }
}