using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class Admission
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required!")]
        public DateTime? AdmissionDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string PreviousSchool { get; set; }

        [Required]
        [MaxLength(20)]
        public string PreviousSchoolAddrs { get; set; }

        public byte[] PreviousSchoolDocument { get; set; }

        public string Extension { get; set; }

   

        public virtual Session Session { get; set; }

        public int StudentClassId { get; set; }

        public virtual List<StudentClass> StudentClasses  { get; set; }
        
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }

        public int StudentId { get; set; }

        public virtual List<Student> Students { get; set; }

    }
}