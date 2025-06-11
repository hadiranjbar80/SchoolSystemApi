using Application.Core;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Students
{
    public class Update
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Student Student { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context; 
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Student.Id);

                if (student == null) return null;

                _mapper.Map(request.Student, student);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update the student");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}