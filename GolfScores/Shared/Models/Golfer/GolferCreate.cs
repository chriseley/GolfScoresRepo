using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class GolferCreate
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Age { get; set; }
    [Required]
    public string HomeCourse { get; set; }
}