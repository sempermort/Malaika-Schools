using System;
using System.ComponentModel.DataAnnotations;

namespace  MalaikaSchool.Data.Models
{
    public class Event
    {
        public Event()
        {

            Timer = DateTime.Now;
        }
        public int Id { get; set; }

        [Display(Name = "DateTime")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Timer { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Describe more")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string Place { get; set; }

        [Display(Name = "Event photo")]
        public virtual UserImageFile Image { get; internal set; }
        //public virtual UserImageFile image { get; set; }
    }
}