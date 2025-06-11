using Application.Core;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class List
    {
        public class Query : IRequest<Result<List<Student>>>
        {
            public string SchoolCode { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<Student>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Student>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var students = await _context.Students.Where(x => x.SchoolCode == request.SchoolCode)
                    .ToListAsync();

                return Result<List<Student>>.Success(students);
            }
        }
    }
}