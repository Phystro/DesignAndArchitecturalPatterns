using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<CreateMovieDto>
    {
        public CreateMovieCommand(string? title, string? description, MovieGenre genre, int? rating)
        {
            Title = title;
            Description = description;
            Genre = genre;
            Rating = rating;
        }

        public string? Title {  get; set; }
        public string? Description { get; set; }
        public MovieGenre Genre { get; set; }
        public int? Rating { get; set; }
    }
}