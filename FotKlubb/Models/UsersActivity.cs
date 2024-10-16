using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models
{
    public class UsersActivity
    {
        [Key]
        public int ActivityId { get; set; }
        public Guid usersId { get; set; }
        public DateTime ActivityDate { get; set; }


    }
}
