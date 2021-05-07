using Microsoft.AspNetCore.Identity;

namespace MalaikaSchool.Data.Models
{
    public class AppUser: IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
        public virtual Guardian Guardian { get; set; }
    }
}