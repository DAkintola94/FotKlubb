using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.ViewModel
{
    public class ProfilePageViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNr { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }

    }
}
