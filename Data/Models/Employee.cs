using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Staff's Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Staff's Email")]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string MaritalStatus { get; set; }

        [MaxLength(20)]
        public string Religion { get; set; }

        [MaxLength(40)]
        public string Nationality { get; set; }

        [MaxLength(30)]
        [Display(Name = "National ID No.")]
        public string NID { get; set; }

        [MaxLength(30)]
        [Display(Name = "Present Address")]
        public string PresentAddress  { get; set; }


        [MaxLength(30)]
        [Display(Name = "Parmanent Address")]
        public string PermanentAddress { get; set; }
         
        [MaxLength(50)]
        public string Qualification { get; set; } 

        public byte[] Image { get; set; }

        public string AppUserId { get; set; }
      
        public virtual AppUser AppUser { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<EmployeeEducation> EmployeeEducation { get; set; }
        public ICollection<EmploymentHistory> EmploymentHistory { get; set; }

        public ICollection<JobInfo> JobInfo { get; set; }
    }
}