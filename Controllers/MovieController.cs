using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movies;

        public MovieController(IMovie movies)
        {
            _movies = movies;
        }

        [HttpGet("feladat10")]
        public async Task<IActionResult> GetAllMovies()
        {
            var result = await _movies.GetAllMovies();

            if (result.result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
