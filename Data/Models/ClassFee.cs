using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalaikaSchool.Data.Models
{
    public class ClassFee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Fee")]
        public string Name { get; set; }

        public double Amount { get; set; }

        public int StudentClassId { get; set; }
    }
}