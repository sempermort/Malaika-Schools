using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MalaikaSchool.Data.Models
{
    public class Guardian
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Guardian Name")]
        public string Name { get; set; }
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
        public string AppUserId { get; set; }
        public virtual AppUser UserGuardian { get; set; }
        public byte[] Image { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
        public int StudentId { get; set; }
        public List<Student> Student { get; set; }

    }
}