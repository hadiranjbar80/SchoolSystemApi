using System.Data;
using System.Xml;
using Domain.Models;
using FluentValidation;

namespace Application.Students
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .MinimumLength(10)
                .MaximumLength(10); 
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.FatherName)
                .NotEmpty();
            RuleFor(x => x.ParentPhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(11);
            RuleFor(x => x.Address)
                .NotEmpty();
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(10); 
        }
    }
}