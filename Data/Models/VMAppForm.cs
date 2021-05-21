using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MalaikaSchool.Data.Models
{
    public class VMAppForm
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


        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        public string Nationality { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Parmanent Address")]
        public string ParmanentAddress { get; set; }

        
        [MaxLength(15)]
        public string Religion { get; set; }

        public byte[] Image { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }

        public ICollection<PhoneNumber> PhoneNumber { get; set; }

        public virtual ICollection<Guardian> Guardians { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Guardian Name")]
        public string NameName { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Guardian Email")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        public string NID { get; set; }

        [Required(ErrorMessage = "Required!")]
        public int GuardianTypeId { get; set; }

        public virtual GuardianType GuardianType { get; set; }

      

       

    }
}

