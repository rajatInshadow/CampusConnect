using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class AttendanceRecordService : IAttendanceRecordRepository
    {
        private readonly DbConnectContext _dbContext;

        public AttendanceRecordService(DbConnectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AttendanceRecordDto>> GetAllAttendanceRecords()
        {
            return await _dbContext.AttendanceRecord
                .Select(a => new AttendanceRecordDto
                {
                    AttendanceRecordId = a.AttendanceRecordId,
                    AttendanceSessionId = a.AttendanceSessionId,
                    StudentId = a.StudentId,
                    Status = a.Status
                })
                .ToListAsync();
        }

        public async Task<AttendanceRecordDto> GetAttendanceRecordById(int id)
        {
            AttendanceRecord attendanceRecord =
                await _dbContext.AttendanceRecord
                .FirstOrDefaultAsync(a => a.AttendanceRecordId == id);

            if (attendanceRecord == null)
            {
                return null;
            }

            return new AttendanceRecordDto
            {
                AttendanceRecordId = attendanceRecord.AttendanceRecordId,
                AttendanceSessionId = attendanceRecord.AttendanceSessionId,
                StudentId = attendanceRecord.StudentId,
                Status = attendanceRecord.Status
            };
        }

        public async Task<ApiResponse<AttendanceRecordDto>> CreateAttendanceRecord(
            AttendanceRecordDto attendanceRecordDto)
        {
            AttendanceRecord attendanceRecord = new AttendanceRecord
            {
                AttendanceSessionId = attendanceRecordDto.AttendanceSessionId,
                StudentId = attendanceRecordDto.StudentId,
                Status = attendanceRecordDto.Status
            };

            await _dbContext.AttendanceRecord.AddAsync(attendanceRecord);

            await _dbContext.SaveChangesAsync();

            attendanceRecordDto.AttendanceRecordId =
                attendanceRecord.AttendanceRecordId;

            return new ApiResponse<AttendanceRecordDto>
            {
                Success = true,
                Message = "Attendance record created successfully",
                Data = attendanceRecordDto
            };
        }

        public async Task<ApiResponse<AttendanceRecordDto>> UpdateAttendanceRecord(
            int id,
            AttendanceRecordDto attendanceRecordDto)
        {
            AttendanceRecord attendanceRecord =
                await _dbContext.AttendanceRecord
                .FirstOrDefaultAsync(a => a.AttendanceRecordId == id);

            if (attendanceRecord == null)
            {
                return null;
            }

            attendanceRecord.AttendanceSessionId =
                attendanceRecordDto.AttendanceSessionId;

            attendanceRecord.StudentId =
                attendanceRecordDto.StudentId;

            attendanceRecord.Status =
                attendanceRecordDto.Status;

            _dbContext.AttendanceRecord.Update(attendanceRecord);

            await _dbContext.SaveChangesAsync();

            return new ApiResponse<AttendanceRecordDto>
            {
                Success = true,
                Message = "Attendance record updated successfully",
                Data = attendanceRecordDto
            };
        }

        public async Task<ApiResponse<AttendanceRecordDto>> DeleteAttendanceRecord(
            int id)
        {
            AttendanceRecord attendanceRecord =
                await _dbContext.AttendanceRecord
                .FirstOrDefaultAsync(a => a.AttendanceRecordId == id);

            if (attendanceRecord == null)
            {
                return null;
            }

            _dbContext.AttendanceRecord.Remove(attendanceRecord);

            await _dbContext.SaveChangesAsync();

            return new ApiResponse<AttendanceRecordDto>
            {
                Success = true,
                Message = "Attendance record deleted successfully"
            };
        }
    }
}