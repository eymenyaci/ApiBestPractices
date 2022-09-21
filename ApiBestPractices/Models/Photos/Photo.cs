using System.Data.Entity;

namespace ApiBestPractices.Models.Photos
{
    public class Photo
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThambnailUrl { get; set; }
    }
}
