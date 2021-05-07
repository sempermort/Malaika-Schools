using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MalaikaSchool.Data.Models
{
    public class StudentAttendance
    {
        public int Id { get; set; }
        public bool present { get; set; }
        public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public Employee Instructor { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }


    }
}