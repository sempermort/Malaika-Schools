using MalaikaSchool.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MalaikaSchool.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }


        [Required(ErrorMessage = "Date Of Birth Required!")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
          
        public string AppUserId { get; set; }

        public virtual AppUser UserStudent { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "PresentAddress is Required!")]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = " Nationality is Required!")]
        public string Nationality { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "ParmanentAddress is  Required!")]
        [Display(Name = "Parmanent Address")]
        public string ParmanentAddress { get; set; }
        [Required(ErrorMessage = "Student Class is  Required!")]
        public int? StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }

        [Required(ErrorMessage = "Religion Field Required!")]
        [MaxLength(15)]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Student image Required!")]
        public byte[] Image { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Gender Required!")]
        public string Gender { get; set; }

        public ICollection<PhoneNumber> PhoneNumber { get; set; }

        public virtual ICollection<Guardian> Guardians { get; set; }
    }
}