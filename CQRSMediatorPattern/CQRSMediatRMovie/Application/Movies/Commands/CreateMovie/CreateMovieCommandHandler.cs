using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieDto>
    {
        private readonly DataContext _context;

        public CreateMovieCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<CreateMovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.CreateMovie();
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return new CreateMovieDto(movie.Id);
        }
    }
}