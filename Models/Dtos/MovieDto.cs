namespace Szabo_Flora_backend.Models.Dtos
{
    public class MovieDto
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public int actorId { get; set; }
        public int filmTypeId { get; set; }
    }
}
