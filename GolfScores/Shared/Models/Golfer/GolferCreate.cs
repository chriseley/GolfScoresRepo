﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public class GolferCreate
{
    [Required]
    public string Name { get; set; }
    public int Age { get; set; }
    public string HomeCourse { get; set; }
}