using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatRSimple.Application.Queries
{
    public class GetBooks
    {
        public class Query : IRequest<IEnumerable<Book>> {}

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Book>>
        {
            private readonly DataContext _context;

            public QueryHandler(DataContext context) => _context = context;

            public async Task<IEnumerable<Book>> Handle(Query request, CancellationToken cancellationToken) => await _context.Books.ToListAsync(cancellationToken);
        }
    }
}