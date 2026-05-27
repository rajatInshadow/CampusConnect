namespace CampusConnect.Model
{
    public class AttendanceRecord
    {
        public int AttendanceRecordId { get; set; }

        public int AttendanceSessionId { get; set; }

        public int EnrollmentID { get; set; }

        public string Status { get; set; }

        // Navigation Properties
        public AttendanceSession AttendanceSession { get; set; }

        public Student Student { get; set; }
    }
}