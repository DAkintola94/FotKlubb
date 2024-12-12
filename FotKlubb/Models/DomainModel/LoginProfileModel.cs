using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.DomainModel
{
    public class LoginProfileModel
    {
        

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Husk meg?")]
        public bool? RememberMe { get; set; }

    }
}
