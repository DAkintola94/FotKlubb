using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FotKlubb.Models.DomainModel
{
    public class CreateProfileModel
    {
        [Required]
        public string Username { get; set; }
        [Required]

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password did not match")]
        public string RepeatPassword { get; set; }

        public byte? ImageData { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
