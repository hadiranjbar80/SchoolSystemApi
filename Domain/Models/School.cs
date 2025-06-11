namespace Domain.Models
{
    public class School
    {
        public string SchoolCode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        // Navigation props

        public ICollection<Student> Students { get; set; }
    }
}