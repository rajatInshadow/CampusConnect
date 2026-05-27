namespace CampusConnect.Model
{
    public class AttendanceSession
    {
        public int AttendanceSessionId { get; set; }

        public int CourseId { get; set; }

        public int FacultyId { get; set; }

        public DateTime SessionDate { get; set; }

        public string Topic { get; set; }

        // Navigation Properties
        public Course Course { get; set; }

        public Faculty Faculty { get; set; }

        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}