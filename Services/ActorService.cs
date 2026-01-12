using Microsoft.EntityFrameworkCore;
using Szabo_Flora_backend.Models;
using Szabo_Flora_backend.Models.Dtos;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Services
{
    public class ActorService : IActor
    {
        private readonly CinemadbContext _context;

        public ActorService(CinemadbContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> ActorCount()
        {
            ResultDto resultDto = new ResultDto();

            try
            {
                var count = await _context.Actors.CountAsync();

                resultDto.message = "Sikeres lekérdezés";
                resultDto.result = count;
                return resultDto;

            }
            catch (Exception)
            {
                resultDto.message = "Nem lehet csatlakozni az adatbázishoz";
                resultDto.result = null;
                return resultDto;
            }
        }

        public async Task<ResultDto> GetActorWithMovies(string name)
        {
            ResultDto resultDto = new ResultDto();

            try
            {
                var actor = await _context.Actors.Include(a => a.Movies).Where(a => a.ActorName == name)
                    .Select(a => new ActorDto
                    {
                        actorId = a.ActorId,
                        actorName = a.ActorName,
                        Movies = a.Movies.Select(m => new MovieDto
                        {
                            movieId = m.MovieId,
                            title = m.Title,
                            releaseDate = m.ReleaseDate,
                            actorId = m.ActorId,
                            filmTypeId = m.FilmTypeId
                        }).ToList()
                    }).FirstOrDefaultAsync();

                if (actor == null)
                {
                    resultDto.message = "A színész nem található";
                    resultDto.result = null;
                    return resultDto;
                }

                resultDto.message = "Sikeres lekérdezés";
                resultDto.result = actor;
                return resultDto;
            }

            catch (Exception ex)
            {
                resultDto.message = ex.Message;
                resultDto.result = null;
                return resultDto;
            }
        }
    }
    
}
