using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.DomainModel
{
    public class UsersActivity
    {
        [Key]
        public int ActivityId { get; set; } 
        public Guid LoginId { get; set; } = Guid.NewGuid();
        public DateTime ActivityDate { get; set; } = DateTime.Now;
        public string? UserName { get; set; }
        public int? UsersSessionId { get; set; }
        public ApplicationUser? UsersApplication { get; set; }


    }
}
