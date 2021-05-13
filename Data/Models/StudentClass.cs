using System.Collections.Generic;

namespace MalaikaSchool.Data.Models
{
    public class StudentClass
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

    
        public List<ClassFee> ClassFees { get; set; }

        public List<Student> Students { get; set; }

        public List<Subject> Subjects { get; set; }

    }
}