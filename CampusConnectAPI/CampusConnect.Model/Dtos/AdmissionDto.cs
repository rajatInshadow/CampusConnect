namespace CampusConnect.Model.Dtos
{
    public class AdmissionDto
    {
        public int AdmissionId { get; set; }

        public int StudentId { get; set; }

        public string AcademicYear { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Status { get; set; }
    }
}
