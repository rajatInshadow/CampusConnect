using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceRecordController : ControllerBase
    {
        private readonly IAttendanceRecordRepository _attendanceRecordRepository;

        public AttendanceRecordController(
            IAttendanceRecordRepository attendanceRecordRepository)
        {
            _attendanceRecordRepository = attendanceRecordRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttendanceRecordDto>>>
            GetAllAttendanceRecords()
        {
            List<AttendanceRecordDto> attendanceRecords =
                await _attendanceRecordRepository.GetAllAttendanceRecords();

            return Ok(attendanceRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceRecordDto>>
            GetAttendanceRecordById(int id)
        {
            AttendanceRecordDto attendanceRecord =
                await _attendanceRecordRepository.GetAttendanceRecordById(id);

            if (attendanceRecord == null)
            {
                return NotFound("Attendance record not found");
            }

            return Ok(attendanceRecord);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<AttendanceRecordDto>>>
            CreateAttendanceRecord(AttendanceRecordDto attendanceRecordDto)
        {
            ApiResponse<AttendanceRecordDto> response =
                await _attendanceRecordRepository
                .CreateAttendanceRecord(attendanceRecordDto);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<AttendanceRecordDto>>>
            UpdateAttendanceRecord(
                int id,
                AttendanceRecordDto attendanceRecordDto)
        {
            ApiResponse<AttendanceRecordDto> response =
                await _attendanceRecordRepository
                .UpdateAttendanceRecord(id, attendanceRecordDto);

            if (response == null)
            {
                return NotFound("Attendance record not found");
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<AttendanceRecordDto>>>
            DeleteAttendanceRecord(int id)
        {
            ApiResponse<AttendanceRecordDto> response =
                await _attendanceRecordRepository
                .DeleteAttendanceRecord(id);

            if (response == null)
            {
                return NotFound("Attendance record not found");
            }

            return Ok(response);
        }
    }
}