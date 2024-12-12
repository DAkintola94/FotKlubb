using Microsoft.AspNetCore.Components.Routing;

namespace FotKlubb.Models.DomainModel
{
    public class UsersPostModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? Date { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public ApplicationUser? User { get; set; }
        public PositionModel? LocationModel { get; set; }

    }
}
