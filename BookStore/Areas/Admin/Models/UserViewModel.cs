
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }    
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
