using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Admission Admission { get; set; }

        public int AdmissionId { get; set; }

    }
}