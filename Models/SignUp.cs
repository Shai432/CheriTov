using System.ComponentModel.DataAnnotations;

namespace ChariTov.Models
{
    public class SignUp
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
