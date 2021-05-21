using Blazorise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MalaikaSchool.Data.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name  = "News Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required !")]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        
        [Required(ErrorMessage = "Required!")]
        [Display(Name = "Massege")]
        public string Massege { get; set; }

        [Required]
        public byte[] Image { get; set; }
        
        public string UserId { get; set; }

        public AppUser User { get; set; }
        public int CategoryId { get; set; }
        public IList<Category> Category { get; set; }

    }
}
