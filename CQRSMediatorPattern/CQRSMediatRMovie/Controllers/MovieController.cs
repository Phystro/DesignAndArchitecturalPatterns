using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRMovie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(long id)
        {
            var movie = await _mediator.Send(new GetMovieQuery(id));
            if(movie != null) return Ok(movie);

            return NotFound($"No movie in the database with ID: {id}.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request)
        {
            var movie = await _mediator.Send(
                new CreateMovieCommand(
                    request.Title,
                    request.Description,
                    request.Genre,
                    request.Rating
                )
            );

            return Ok(movie);
        }
    }
}