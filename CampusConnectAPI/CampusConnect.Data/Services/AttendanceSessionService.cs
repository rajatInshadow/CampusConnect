using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class AttendanceSessionService : IAttendanceSessionRepository
    {
        private readonly DbConnectContext _dbContext;

        public AttendanceSessionService(DbConnectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AttendanceSessionDto>> GetAllAttendanceSessions()
        {
            return await _dbContext.AttendanceSession
                .Select(a => new AttendanceSessionDto
                {
                    AttendanceSessionId = a.AttendanceSessionId,
                    CourseId = a.CourseId,
                    FacultyId = a.FacultyId,
                    SessionDate = a.SessionDate,
                    Topic = a.Topic
                })
                .ToListAsync();
        }

        public async Task<AttendanceSessionDto> GetAttendanceSessionById(int id)
        {
            AttendanceSession attendanceSession = await _dbContext.AttendanceSession
                .FirstOrDefaultAsync(a => a.AttendanceSessionId == id);

            if (attendanceSession == null)
            {
                return null;
            }

            return new AttendanceSessionDto
            {
                AttendanceSessionId = attendanceSession.AttendanceSessionId,
                CourseId = attendanceSession.CourseId,
                FacultyId = attendanceSession.FacultyId,
                SessionDate = attendanceSession.SessionDate,
                Topic = attendanceSession.Topic
            };
        }

        public async Task<ApiResponse<AttendanceSessionDto>> CreateAttendanceSession(
            AttendanceSessionDto attendanceSessionDto)
        {
            AttendanceSession attendanceSession = new AttendanceSession
            {
                CourseId = attendanceSessionDto.CourseId,
                FacultyId = attendanceSessionDto.FacultyId,
                SessionDate = attendanceSessionDto.SessionDate,
                Topic = attendanceSessionDto.Topic
            };

            await _dbContext.AttendanceSession.AddAsync(attendanceSession);

            await _dbContext.SaveChangesAsync();

            attendanceSessionDto.AttendanceSessionId =
                attendanceSession.AttendanceSessionId;

            return new ApiResponse<AttendanceSessionDto>
            {
                Success = true,
                Message = "Attendance session created successfully",
                Data = attendanceSessionDto
            };
        }

        public async Task<ApiResponse<AttendanceSessionDto>> UpdateAttendanceSession(
            int id,
            AttendanceSessionDto attendanceSessionDto)
        {
            AttendanceSession attendanceSession =
                await _dbContext.AttendanceSession
                .FirstOrDefaultAsync(a => a.AttendanceSessionId == id);

            if (attendanceSession == null)
            {
                return null;
            }

            attendanceSession.CourseId = attendanceSessionDto.CourseId;
            attendanceSession.FacultyId = attendanceSessionDto.FacultyId;
            attendanceSession.SessionDate = attendanceSessionDto.SessionDate;
            attendanceSession.Topic = attendanceSessionDto.Topic;

            _dbContext.AttendanceSession.Update(attendanceSession);

            await _dbContext.SaveChangesAsync();

            return new ApiResponse<AttendanceSessionDto>
            {
                Success = true,
                Message = "Attendance session updated successfully",
                Data = attendanceSessionDto
            };
        }

        public async Task<ApiResponse<AttendanceSessionDto>> DeleteAttendanceSession(
            int id)
        {
            AttendanceSession attendanceSession =
                await _dbContext.AttendanceSession
                .FirstOrDefaultAsync(a => a.AttendanceSessionId == id);

            if (attendanceSession == null)
            {
                return null;
            }

            _dbContext.AttendanceSession.Remove(attendanceSession);

            await _dbContext.SaveChangesAsync();

            return new ApiResponse<AttendanceSessionDto>
            {
                Success = true,
                Message = "Attendance session deleted successfully"
            };
        }
    }
}