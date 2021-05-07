using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalaikaSchool.Data.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }

        public int GuardianId { get; set; }
        public Guardian guardian { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
