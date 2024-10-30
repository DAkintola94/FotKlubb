using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models.LocationModel
{
    public class PositionModel
    {
        [Key]
        public Guid InterractorId { get; set; } = Guid.NewGuid();
        public string GeoJson { get; set; }
        public string Description { get; set; }
        //public IFormFile VideoFile { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
