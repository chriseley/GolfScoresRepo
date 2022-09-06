using System.ComponentModel.DataAnnotations;

 public class Golfer
 {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
    public string HomeCourse { get; set; }
 }
 

