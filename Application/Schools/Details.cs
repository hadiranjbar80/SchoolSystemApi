using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class Details
    {
        public class Query : IRequest<Result<School>>
        {
            public School School { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<School>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context; 
            }
            public async Task<Result<School>> Handle(Query request, CancellationToken cancellationToken)
            {
                var pass = Seed.HashPassword(request.School.Password);

                var school = await _context.Schools.FirstOrDefaultAsync
                    (x => x.SchoolCode == request.School.SchoolCode && x.Password == Seed.HashPassword(request.School.Password));

                if (school == null) return Result<School>.Failure("Faild to find the school");

                return Result<School>.Success(school);
            }
        }
    }
}