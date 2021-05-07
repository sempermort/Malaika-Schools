using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class AccountGroup
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }
    }
}