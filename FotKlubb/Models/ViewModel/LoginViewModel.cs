using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Dette feltet må fylles ut")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Dette feltet må fylles ut")]
        public string Password { get; set; }
        public string? RememberMe { get; set; }
        public string? ReturnUrl { get; set; }

        [NotMapped]
        [ValidateNever]
        public bool PasswordFailed { get; set; } = false;
    }
}
