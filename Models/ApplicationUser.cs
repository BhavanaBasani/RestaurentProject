using Microsoft.AspNetCore.Identity;

namespace RestaurentProject.Models
{
    public class ApplicationUser :IdentityUser
    {
        public ICollection<Order>? Orders { get; set; }
    }
}
