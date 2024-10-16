using System.ComponentModel.DataAnnotations;

namespace FotKlubb.Models
{
    public class PositionModel
    {
        [Key]
        public Guid InterractorId { get; set; } = Guid.NewGuid();
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
        //public IFormFile VideoFile { get; set; }

    }
}
