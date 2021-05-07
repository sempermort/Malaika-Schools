using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class ExamTitle
    {
        public int Id { get; set; }

        [Display(Name = "Title Name")]
        [Required(ErrorMessage = "Required!")]
        public string TitleName { get; set; }


        public int EducationLevelId { get; set; }

        public EducationLevel EducationLevel { get; set; }
    }
}