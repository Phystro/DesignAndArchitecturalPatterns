using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Queries.GetMovie
{
    public static class GetMovieQueryExtensions
    {
        public static GetMovieDto MapTo(this Movie movie)
        {
            return new GetMovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating
            };
        }
    }
}