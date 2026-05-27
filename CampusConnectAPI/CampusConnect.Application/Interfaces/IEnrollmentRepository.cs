using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;

namespace CampusConnect.Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<List<EnrollmentDto>> GetAllEnrollments();

        Task<EnrollmentDto> GetEnrollmentById(int id);

        Task<ApiResponse<EnrollmentDto>> CreateEnrollment(EnrollmentDto enrollmentDto);

        Task<ApiResponse<EnrollmentDto>> UpdateEnrollment(int id, EnrollmentDto enrollmentDto);

        Task<ApiResponse<EnrollmentDto>> DeleteEnrollment(int id);
    }
}