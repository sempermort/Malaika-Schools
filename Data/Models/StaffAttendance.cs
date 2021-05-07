using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalaikaSchool.Data.Models
{
    public class StaffAttendance
    {
        public int Id { get; set; }
        public bool present { get; set; }
        public DateTime ComingTime { get; set; }
        public DateTime LeavingingTime { get; set; }
        public int EmployeeId { get; set; }
        public Employee Instructor { get; set; }
        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
