using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.Activity
{
    public class UsersActivity
    {
        [Key]
        public Guid ActivityId { get; set; } = Guid.NewGuid();
        public Guid LoginId { get; set; }
        public DateTime ActivityDate { get; set; } = DateTime.Now;

        public string? UserName { get; set; }


    }
}
