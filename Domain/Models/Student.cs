using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string SchoolCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string ParentPhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public CommuteService CommuteService { get; set; } = CommuteService.Bus;

        // Navigation props

        [ForeignKey("SchoolCode")]
        public School School { get; set; }
    }
}