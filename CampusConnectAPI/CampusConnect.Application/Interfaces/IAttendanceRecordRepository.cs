using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface IAttendanceRecordRepository
    {
        Task<List<AttendanceRecordDto>> GetAllAttendanceRecords();

        Task<AttendanceRecordDto> GetAttendanceRecordById(int id);

        Task<ApiResponse<AttendanceRecordDto>> CreateAttendanceRecord(
            AttendanceRecordDto attendanceRecordDto);

        Task<ApiResponse<AttendanceRecordDto>> UpdateAttendanceRecord(
            int id,
            AttendanceRecordDto attendanceRecordDto);

        Task<ApiResponse<AttendanceRecordDto>> DeleteAttendanceRecord(int id);
    }
}