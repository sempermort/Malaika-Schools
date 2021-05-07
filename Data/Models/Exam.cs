using System;

namespace MalaikaSchool.Data.Models
{
    public class Exam
    {
        private float _total = 0;
        public float Mark { get; set; }
        public DateTime Datetime { get; set; } = DateTime.Now;
        private string _grade = "";
        public int Id { get; set; }

        public float Theory { get; set; }
        public float Mcq { get; set; }
        public float Practical { get; set; }
        public float Total
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
        public string Grade 
        {
            get 
            {
                if (_total >= 80) 
                {
                    return _grade = "A+";
                }
                else if (_total >= 70 && _total < 80)
                {
                    return _grade = "A";
                }
                else if (_total >= 60 && _total < 70)
                {
                    return _grade = "A-";
                }
                else if (_total >= 50 && _total < 60)
                {
                    return _grade = "B";
                }
                else if (_total >= 40 && _total < 50)
                {
                    return _grade = "C";
                }
                else if (_total >= 33 && _total < 40)
                {
                    return _grade = "D";
                }
                else
                    return _grade = "F";
                    
            }
            private set 
            {
                _grade = value;
            }
        }
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int? StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? AssignRollId { get; set; }
        public virtual AssignRoll AssignRoll { get; set; }

        public int? ExamTypeId { get; set; }
        public virtual ExamType ExamType { get; set; }
    }
}