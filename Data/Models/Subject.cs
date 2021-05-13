using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class Subject
    {
        private int _total = 0;
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Required!")]
        public string Name { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Required!")]
        public string Code { get; set; }

        public int Theory { get; set; }
        public int Mcq { get; set; }
        public int Practical { get; set; }

        public int Total
        {
            get //get method for returning value
            {
                _total = this.Theory + this.Mcq + this.Practical;
                return _total;
            }
           private set // set method for storing value in name field.
            {
                _total = value;
            }
        }
        public int StudentClassId { get; set; }

         public StudentClass StudentClass { get; set; }
    }
}