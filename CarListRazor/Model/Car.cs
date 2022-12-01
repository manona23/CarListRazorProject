﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarListRazor.Model
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

    }
}
