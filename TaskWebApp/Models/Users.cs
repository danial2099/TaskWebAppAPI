using Microsoft.EntityFrameworkCore;

namespace TaskWebApp.Models
{
    [Index("Email", IsUnique = true)]
    public class Users
    {

        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        public string ICNumber { get; set; }
    }
}
