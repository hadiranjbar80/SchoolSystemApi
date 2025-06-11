using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string StudentId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.StudentId);

                if (student == null) return null;

                _context.Remove(student);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the student");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}