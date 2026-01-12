using Microsoft.EntityFrameworkCore;
using Szabo_Flora_backend.Models;
using Szabo_Flora_backend.Models.Dtos;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Services
{
    public class FilmTypeService : IFilmType
    {
        private readonly CinemadbContext _context;

        public FilmTypeService(CinemadbContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> GetAllFilmTypeWithMovies()
        {
            ResultDto resultDto = new ResultDto();

            try
            {
                var filmtypes = await _context.FilmTypes
                    .Include(t => t.Movies)
                    .Select(t => new FilmTypeDto
                    {
                        typeId = t.TypeId,
                        typeName = t.TypeName,
                        Movies = t.Movies.Select(m => new MovieDto
                        {
                            movieId = m.MovieId,
                            title = m.Title,
                            releaseDate = m.ReleaseDate,
                            actorId = m.ActorId,
                            filmTypeId = m.FilmTypeId
                        }).ToList()
                     }).FirstOrDefaultAsync();

                resultDto.message = "Sikeres lekérdezés";
                resultDto.result = filmtypes;
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
