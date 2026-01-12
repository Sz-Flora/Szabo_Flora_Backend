using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTypeController : ControllerBase
    {
        private readonly IFilmType _filmtype;

        public FilmTypeController(IFilmType filmtype)
        {
            _filmtype = filmtype;
        }

        [HttpGet("feladat11")]
        public async Task<IActionResult> GetAllFilmTypeWithMovies()
        {
            var result = await _filmtype.GetAllFilmTypeWithMovies();

            if (result.result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
