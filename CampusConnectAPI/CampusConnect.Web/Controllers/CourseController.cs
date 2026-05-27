using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courserepo;
        public CourseController(ICourseRepository courseRepository)
        {
            _courserepo = courseRepository;

        }

        [HttpGet]
        [Route("GetAllCourse")]
        public async Task<List<CourseDto>> GetAllCourse()
        {
            List<CourseDto> courseList = await _courserepo.GetAllCourses();

            return courseList;
        }

        [HttpGet]
        [Route("GetCourseById")]
        public async Task<CourseDto> GetAllCourseById(int id)
        {
            CourseDto courseList = await _courserepo.GetCourseById(id);

            return courseList;
        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<CourseDto> CreateCourse(CourseDto courseDto)
        {
            CourseDto course = await _courserepo.CreateCourse(courseDto);

            return courseDto;
        }

        [HttpPut]
        [Route("UpdateCourse")]
        public async Task<CourseDto> UpdateCourse(CourseDto courseDto)
        {
            CourseDto updatedcourse = await _courserepo.UpdateCourse(courseDto);

            return updatedcourse;
        }

        [HttpDelete]
        [Route("DeleteCourse")]
        public async Task<ApiResponse<CourseDto>> DeleteCourse(int Id)
        {
            ApiResponse<CourseDto> response = await _courserepo.DeleteCourse(Id);

            return response;
        }

    }
}
