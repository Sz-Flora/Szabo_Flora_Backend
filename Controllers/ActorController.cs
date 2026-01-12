using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Szabo_Flora_backend.Services.Iservices;

namespace Szabo_Flora_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActor _actor;

        public ActorController(IActor actor)
        {
            _actor = actor;
        }

        [HttpGet("feladat9/{name}")]
        public async Task<IActionResult> GetActorWithMovies(string name)
        {
            var result = await _actor.GetActorWithMovies(name);

            if (result.result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("feladat12")]
        public async Task<IActionResult> ActorCount()
        {
            var result = await _actor.ActorCount();

            if (result.result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
