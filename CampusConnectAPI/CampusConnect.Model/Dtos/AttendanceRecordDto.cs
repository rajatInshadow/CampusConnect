namespace CampusConnect.Model.Dtos
{
    public class AttendanceRecordDto
    {
        public int AttendanceRecordId { get; set; }

        public int AttendanceSessionId { get; set; }

        public int EnrollmentID { get; set; }

        public string Status { get; set; }
    }
}