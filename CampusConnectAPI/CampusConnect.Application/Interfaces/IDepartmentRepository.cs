using CampusConnect.Model.Dtos;

namespace CampusConnect.Application.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetAllDepartment();
        Task<DepartmentDto> AddDepartment(DepartmentDto department);
        Task<DepartmentDto> UpdateDepartment(int id, DepartmentDto department);
        Task<DepartmentDto> GetDepartmentById(int id);
        Task<DepartmentDto> DeleteDepartment(int id);
    }
}
