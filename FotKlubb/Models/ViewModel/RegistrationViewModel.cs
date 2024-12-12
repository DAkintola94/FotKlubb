using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.ViewModel
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [MinLength(8)]
        public string PhoneNr { get; set; }
        [Required]
        public string Password { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passordet stemmer ikke.")]
        public string RepeatPassword { get; set; }

    }
}
