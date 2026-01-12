using Microsoft.EntityFrameworkCore;
using Szabo_Flora_backend.Models;
using Szabo_Flora_backend.Models.Dtos;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Services
{
    public class MovieService : IMovie
    {
        private readonly CinemadbContext _context;

        public MovieService(CinemadbContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> GetAllMovies()
        {
            ResultDto resultDto = new ResultDto();

            try
            {
                var movies = await _context.Movies
                    .Select(m => new MovieDto
                    {
                        movieId = m.MovieId,
                        title = m.Title,
                        releaseDate = m.ReleaseDate,
                        actorId = m.ActorId,
                        filmTypeId = m.FilmTypeId
                    }).ToListAsync();

                resultDto.message = "Sikeres lekérdezés";
                resultDto.result = movies;
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
