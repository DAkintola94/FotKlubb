using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg;
using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.DomainModel
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        public string? Address { get; set; }
        [Required]
        public string ImageUrl { get; set; }

    }
}
