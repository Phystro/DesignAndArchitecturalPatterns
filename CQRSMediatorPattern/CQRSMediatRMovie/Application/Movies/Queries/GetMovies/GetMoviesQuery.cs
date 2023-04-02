using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<IList<GetMovieDto>>
    {
        
    }
}