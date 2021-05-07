using System;
using System.Collections.Generic;

namespace  MalaikaSchool.Data.Models
{
    public class News
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public IList<Category> Category { get; set; }
        public DateTime? Time { get; set; }


    }

}