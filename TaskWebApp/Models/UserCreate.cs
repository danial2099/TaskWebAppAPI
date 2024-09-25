using System.ComponentModel.DataAnnotations;

namespace TaskWebApp.Models
{
    public class UserCreate
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = " ";
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = " ";
        [Required(ErrorMessage = "Phone number requires to start from 60")]
        public string? PhoneNumber { get; set; } = " ";
        [Required(ErrorMessage = "IC number requires to include NUMERICAL only")]
        public string ICNumber { get; set; }
            
    }
}
