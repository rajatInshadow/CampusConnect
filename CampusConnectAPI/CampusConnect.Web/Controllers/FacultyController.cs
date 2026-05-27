using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> GetAllFaculties()
        {
            List<FacultyDto> faculties = await _facultyRepository.GetAllFaculties();

            return Ok(faculties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {
            FacultyDto faculty = await _facultyRepository.GetFacultyById(id);

            if (faculty == null)
            {
                return NotFound("Faculty not found");
            }

            return Ok(faculty);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<FacultyDto>>> CreateFaculty(FacultyDto facultyDto)
        {
            ApiResponse<FacultyDto> faculty =
                await _facultyRepository.CreateFaculty(facultyDto);

            return Ok(faculty);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<FacultyDto>>> UpdateFaculty(
            int id,
            FacultyDto facultyDto)
        {
            ApiResponse<FacultyDto> faculty =
                await _facultyRepository.UpdateFaculty(id, facultyDto);

            if (faculty == null)
            {
                return NotFound("Faculty not found");
            }

            return Ok(faculty);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<FacultyDto>>> DeleteFaculty(int id)
        {
            ApiResponse<FacultyDto> faculty =
                await _facultyRepository.DeleteFaculty(id);

            if (faculty == null)
            {
                return NotFound("Faculty not found");
            }

            return Ok(faculty);
        }
    }
}