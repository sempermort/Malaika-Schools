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
        [Display(Name = "Opening Balance")]
        public decimal OpeningBalance { get; set; }
        [Required]
        [Display(Name = "Current Balance")]
        public decimal CurrentBalance { get; set; }

        [Required]
        [Display(Name = "Total Due")]
        public decimal TotalDue { get; set; }

        [Required]
        [Display(Name = "Student Class")]
        public int StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        [Required]
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "Account Group")]
        public int AccountGroupId { get; set; }
        public virtual AccountGroup AccountGroup { get; set; }
        [Required]
        [Display(Name = "Fee Type")]
        public int FeeTypeId { get; set; }
        public virtual FeeType FeeType { get; set; }
    }
}