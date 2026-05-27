using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetAllCourses();
        Task<CourseDto> GetCourseById(int Id);
        Task<CourseDto> CreateCourse(CourseDto course);
        Task<CourseDto> UpdateCourse(CourseDto course);
        Task<ApiResponse<CourseDto>> DeleteCourse(int Id);



    }
}
