using Szabo_Flora_backend.Models.Dtos;

namespace Szabo_Flora_backend.Services.Iservices
{
    public interface IMovie
    {
        Task<ResultDto> GetAllMovies();
    }
}
