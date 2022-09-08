﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GolferEdit
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Age { get; set; }
    public string HomeCourse { get; set; }
}

