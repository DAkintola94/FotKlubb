namespace FotKlubb.Models.ViewModel
{
    public class PositionViewModel
    {
        public string? GeoJson { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        //public IFormFile VideoFile { get; set; }
        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
