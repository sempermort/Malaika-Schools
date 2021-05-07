using System.Collections.Generic;

namespace MalaikaSchool.Data.Models
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<UserImageFile> Image { get; set; }

    }
}
