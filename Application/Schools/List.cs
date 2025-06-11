using Application.Core;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class List
    {
        public class Query : IRequest<Result<List<School>>> { }

        public class Handler : IRequestHandler<Query, Result<List<School>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<School>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schools = await _context.Schools
                    .Include(x=>x.Students).ToListAsync();

                return Result<List<School>>.Success(schools);
            }
        }
    }
}