using System.ComponentModel.DataAnnotations;

namespace UserAPI.Controllers
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and repassword different")]
        public string RePassword { get; set; }

    }
}