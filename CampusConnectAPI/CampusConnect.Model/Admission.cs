namespace CampusConnect.Model
{
    public class Admission
    {
        public int AdmissionId { get; set; }

        public int StudentId { get; set; }

        public string AcademicYear { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Status { get; set; }

        // Navigation Property
        public Student Student { get; set; }
    }
}
