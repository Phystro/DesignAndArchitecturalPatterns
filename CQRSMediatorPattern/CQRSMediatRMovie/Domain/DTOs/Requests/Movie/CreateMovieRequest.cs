using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Domain.DTOs.Requests.Movie
{
    public class CreateMovieRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public MovieGenre Genre { get; set; }
        public int? Rating { get; set; }
    }
}