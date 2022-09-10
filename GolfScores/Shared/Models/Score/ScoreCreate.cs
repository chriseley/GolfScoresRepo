using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScoreCreate
{
    [Required]
    public int GolferId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    public string Score { get; set; }
}
