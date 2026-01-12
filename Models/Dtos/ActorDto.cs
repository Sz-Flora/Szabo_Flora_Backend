namespace Szabo_Flora_backend.Models.Dtos
{
    public class ActorDto
    {
        public int actorId { get; set; }
        public string actorName { get; set; } = string.Empty;
        public List<MovieDto>? Movies { get; set; }

    }
}