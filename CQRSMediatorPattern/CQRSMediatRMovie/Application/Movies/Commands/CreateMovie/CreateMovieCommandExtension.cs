using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Commands.CreateMovie
{
    public static class CreateMovieCommandExtension
    {
        public static Movie CreateMovie(this CreateMovieCommand command)
        {
            var movie = new Movie
                (
                    command.Title,
                    command.Description,
                    command.Genre,
                    command.Rating
                );

            return movie;
        }
    }
}