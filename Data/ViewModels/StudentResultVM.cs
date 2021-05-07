using System.Collections.Generic;

namespace MalaikaSchool.Data.ViewModels
{
    public class StudentResultVM
    {
        public ICollection<ResultVM> ResultVM { get; set; }
        public ICollection<StudentInfoVM> StudentInfoVM { get; set; }
        public string SessionId { get; set; }
   
        public string StudentClassId { get; set; }

        public string StudentId { get; set; }
    }
}