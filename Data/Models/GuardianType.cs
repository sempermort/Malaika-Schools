﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalaikaSchool.Data.Models
{
    public class GuardianType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}