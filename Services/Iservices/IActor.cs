using Szabo_Flora_backend.Models.Dtos;

namespace Szabo_Flora_backend.Services.Iservices
{
    public interface IActor
    {
        Task<ResultDto> GetActorWithMovies(string name);
        Task<ResultDto> ActorCount();
    }
}
