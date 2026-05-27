namespace CampusConnect.Model.Dtos
{
    public class AttendanceSessionDto
    {
        public int AttendanceSessionId { get; set; }

        public int CourseId { get; set; }

        public int FacultyId { get; set; }

        public DateTime SessionDate { get; set; }

        public string Topic { get; set; }
    }
}
