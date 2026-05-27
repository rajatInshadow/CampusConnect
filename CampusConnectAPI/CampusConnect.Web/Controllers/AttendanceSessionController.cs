using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceSessionController : ControllerBase
    {
        private readonly IAttendanceSessionRepository _attendanceSessionRepository;

        public AttendanceSessionController(
            IAttendanceSessionRepository attendanceSessionRepository)
        {
            _attendanceSessionRepository = attendanceSessionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttendanceSessionDto>>>
            GetAllAttendanceSessions()
        {
            List<AttendanceSessionDto> attendanceSessions =
                await _attendanceSessionRepository
                .GetAllAttendanceSessions();

            return Ok(attendanceSessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceSessionDto>>
            GetAttendanceSessionById(int id)
        {
            AttendanceSessionDto attendanceSession =
                await _attendanceSessionRepository
                .GetAttendanceSessionById(id);

            if (attendanceSession == null)
            {
                return NotFound("Attendance session not found");
            }

            return Ok(attendanceSession);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<AttendanceSessionDto>>>
            CreateAttendanceSession(
                AttendanceSessionDto attendanceSessionDto)
        {
            ApiResponse<AttendanceSessionDto> response =
                await _attendanceSessionRepository
                .CreateAttendanceSession(attendanceSessionDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<AttendanceSessionDto>>>
            UpdateAttendanceSession(
                int id,
                AttendanceSessionDto attendanceSessionDto)
        {
            ApiResponse<AttendanceSessionDto> response =
                await _attendanceSessionRepository
                .UpdateAttendanceSession(id, attendanceSessionDto);

            if (response == null)
            {
                return NotFound("Attendance session not found");
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<AttendanceSessionDto>>>
            DeleteAttendanceSession(int id)
        {
            ApiResponse<AttendanceSessionDto> response =
                await _attendanceSessionRepository
                .DeleteAttendanceSession(id);

            if (response == null)
            {
                return NotFound("Attendance session not found");
            }

            return Ok(response);
        }
    }
}