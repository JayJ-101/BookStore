using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class User: IdentityUser
    {
        [NotMapped]
        public IList<string> RoleName { get; set; } = null!;
    }
}
