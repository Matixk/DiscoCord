using System.ComponentModel.DataAnnotations;

namespace DiscoCordAPI.Models.Users
{
    public class UserForRegisterDto
    {
        [Required] public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
        public string Password { get; set; }
    }
}