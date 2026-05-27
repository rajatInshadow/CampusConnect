using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnrollmentDto>>> GetAllEnrollments()
        {
            List<EnrollmentDto> enrollments =
                await _enrollmentRepository.GetAllEnrollments();

            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollmentById(int id)
        {
            EnrollmentDto enrollment =
                await _enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<EnrollmentDto>>> CreateEnrollment(
            EnrollmentDto enrollmentDto)
        {
            ApiResponse<EnrollmentDto> enrollment =
                await _enrollmentRepository.CreateEnrollment(enrollmentDto);

            return Ok(enrollment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<EnrollmentDto>>> UpdateEnrollment(
            int id,
            EnrollmentDto enrollmentDto)
        {
            ApiResponse<EnrollmentDto> enrollment =
                await _enrollmentRepository.UpdateEnrollment(id, enrollmentDto);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<EnrollmentDto>>> DeleteEnrollment(int id)
        {
            ApiResponse<EnrollmentDto> enrollment =
                await _enrollmentRepository.DeleteEnrollment(id);

            if (enrollment == null)
            {
                return NotFound("Enrollment not found");
            }

            return Ok(enrollment);
        }
    }
}