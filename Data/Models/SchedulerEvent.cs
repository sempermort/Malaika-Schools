using System;
using System.ComponentModel.DataAnnotations;

namespace MalaikaSchool.Data.Models
{
    public class SchedulerEvent
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "MM / dd / yyyy HH: mm")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Range(typeof(decimal), "0", "24")]
        public Decimal Duration { get; set; }

        public int? StudentClassId { get; set; }
        public virtual StudentClass StudentClass { get; set; }

        public int? ExamId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
