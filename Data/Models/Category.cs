using System.ComponentModel.DataAnnotations;

namespace  MalaikaSchool.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
     
        [Display(Name = "Category Name")]
        public string CName { get; set; }
    }
}
