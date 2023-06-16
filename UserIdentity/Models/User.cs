using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Models
{
    public class User:IdentityUser
        
    {
        
        public DateOnly BirthDate { get; set; } 
        public string Address { get; set; } 
    }
}
