using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Score
{
    [Key]
    public int Id { get; set; }

    public int GolferId { get; set; }
    [ForeignKey(nameof(GolferId))]
    public virtual Golfer Golfer { get; set; }

    public int CourseId { get; set; }
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; }

    [Required]
    public string NewScore { get; set; }
}