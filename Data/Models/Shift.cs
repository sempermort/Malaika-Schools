using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}