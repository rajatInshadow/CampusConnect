namespace CampusConnect.Model.Students
{
    public class StudentDto
    {
        public int StudentID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DOB { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
    }
}
