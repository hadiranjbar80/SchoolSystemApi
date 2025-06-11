using Domain.Models;

namespace API.DTOs
{
    public class AddStudentDto
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string ParentPhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public CommuteService CommuteService { get; set; } = CommuteService.Bus;
    }
}