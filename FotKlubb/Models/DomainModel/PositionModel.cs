using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.DomainModel
{
    public class PositionModel
    {
        
        public int PositionId { get; set; } 
        public string? GeoJson { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        //public IFormFile VideoFile { get; set; }
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
