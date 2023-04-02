using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<GetMovieDto>
    {
        public GetMovieQuery(long? id)
        {
            Id = id;
        }

        public long? Id { get; set; }
    }
}