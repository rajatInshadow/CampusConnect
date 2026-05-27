using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface IAttendanceSessionRepository
    {
        Task<List<AttendanceSessionDto>> GetAllAttendanceSessions();

        Task<AttendanceSessionDto> GetAttendanceSessionById(int id);

        Task<ApiResponse<AttendanceSessionDto>> CreateAttendanceSession(
            AttendanceSessionDto attendanceSessionDto);

        Task<ApiResponse<AttendanceSessionDto>> UpdateAttendanceSession(
            int id,
            AttendanceSessionDto attendanceSessionDto);

        Task<ApiResponse<AttendanceSessionDto>> DeleteAttendanceSession(int id);
    }
}