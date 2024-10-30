using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.AccountModel
{
    public class LoginProfileModel
    {
        [Key] //needed a key, also to uniquely identify login attepmts
        public Guid LoginId { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Husk meg?")]
        public bool RememberMe { get; set; }


    }
}
