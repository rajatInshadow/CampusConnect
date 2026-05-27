using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface IFacultyRepository
    {
        Task<List<FacultyDto>> GetAllFaculties();

        Task<FacultyDto> GetFacultyById(int id);

        Task<ApiResponse<FacultyDto>> CreateFaculty(FacultyDto facultyDto);

        Task<ApiResponse<FacultyDto>> UpdateFaculty(int id, FacultyDto facultyDto);

        Task<ApiResponse<FacultyDto>> DeleteFaculty(int id);
    }
}
