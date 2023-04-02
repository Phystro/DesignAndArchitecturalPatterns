using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GetMovieDto>
    {
        public readonly DataContext _context;

        public GetMovieQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetMovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(movie != null)
            {
                var movieItem = movie.MapTo();
                return movieItem;
            }

            return null;
        }
    }
}