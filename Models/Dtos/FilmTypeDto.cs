namespace Szabo_Flora_backend.Models.Dtos
{
    public class FilmTypeDto
    {
        public int typeId { get; set; }
        public string typeName { get; set; } = string.Empty;
        public List<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}

