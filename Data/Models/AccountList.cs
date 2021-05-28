using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class AccountList
    {
        public int Id { get; set; }

        [Required]     
        public DateTime Date { get; set; }
       
        [Required]
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Fee Type")]
        public int ClassFeeId { get; set; }
        public virtual ClassFee ClassFee{ get; set; }
    }
}