using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class School
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "School Name")]
        public string Name { get; set; }

        [Display(Name = "School Address")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Required!")]
        public string Address { get; set; }

        [Display(Name = "School Phone Primary")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        public string PhonePrimary { get; set; }

        [MaxLength(30)]        
        [Display(Name = "School Phone Alt")]
        public string PhoneAlt { get; set; }

        [MaxLength(10)]        
        [Display(Name = "School Fax")]
        public string Fax { get; set; }

        [MaxLength(50)]
        [Display(Name = "School Email")]
        public string Email { get; set; }

        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }
    }
}