using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRSimple.Application.Commands
{
    public class CreateNewBook
    {
        public class Command : IRequest<int>
        {
            public string Author { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly DataContext _context;

            public CommandHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Book
                {
                    Title = request.Title,
                    Author = request.Author,
                    Description = request.Description
                };

                await _context.Books.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}