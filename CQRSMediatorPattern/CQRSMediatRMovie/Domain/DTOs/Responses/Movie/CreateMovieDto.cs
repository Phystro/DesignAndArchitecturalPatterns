using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRMovie.Domain.DTOs.Responses.Movie
{
    public class CreateMovieDto
    {
        public CreateMovieDto(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}