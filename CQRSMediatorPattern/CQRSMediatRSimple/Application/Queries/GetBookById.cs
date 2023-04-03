using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRSimple.Application.Queries
{
    public class GetBookById
    {
        public class Query : IRequest<Book>
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Book>
        {
            private readonly DataContext _context;

            public QueryHandler(DataContext context)
            {
                _context = context;
            }

            public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Books.FindAsync(request.Id);
            }
        }
    }
}