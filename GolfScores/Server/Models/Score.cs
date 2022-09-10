using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Score
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Golfer))]
    public int GolferId { get; set; }
    public virtual Golfer Golfer { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public virtual Course Course { get; set; }

    [Required]
    public string NewScore { get; set; }
}