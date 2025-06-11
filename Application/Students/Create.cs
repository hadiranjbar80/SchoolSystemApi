using System.Data;
using Application.Core;
using Domain.Models;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Students
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Student Student { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Student).SetValidator(new StudentValidator());
            }
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
                var student = _context.Students.Any(x => x.Id == request.Student.Id);
                if (student) return Result<Unit>.Failure("This Id already exists");
                _context.Add(request.Student);
                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}