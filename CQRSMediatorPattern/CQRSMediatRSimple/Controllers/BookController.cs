using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRSimple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerator<Book>> GetBooks() => (IEnumerator<Book>)await _mediator.Send(new GetBooks.Query());

        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id) => (Book)await _mediator.Send(new GetBookById.Query{Id = id} );

        [HttpPost]
        public async Task<ActionResult> CreateBook( [FromBody] CreateNewBook.Command command )
        {
            var createdBookId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBook), new { id = createdBookId }, null );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _mediator.Send(new DeleteBook.Command { Id = id } );
            return NoContent();
        }
    }
}