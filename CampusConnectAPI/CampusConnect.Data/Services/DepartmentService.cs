using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class DepartmentService : IDepartmentRepository
    {
        private readonly DbConnectContext _dbcontext;
        public DepartmentService(DbConnectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<DepartmentDto> AddDepartment(DepartmentDto department)
        {
            var isDepartmentExists = await _dbcontext.Department.FirstOrDefaultAsync(x => x.DepartmentName == department.DepartmentName);
            if (isDepartmentExists != null)
            {
                return null;
            }

            Department newDepartment = new Department()
            {
                DepartmentName = department.DepartmentName,
                DepartmentCode = department.DepartmentCode,
            };

            _dbcontext.Department.Add(newDepartment);
            await _dbcontext.SaveChangesAsync();

            DepartmentDto newDepartmentDto = new DepartmentDto()
            {
                DepartmentId = newDepartment.DepartmentId,
                DepartmentName = newDepartment.DepartmentName,
                DepartmentCode = newDepartment.DepartmentCode,
            };

            return newDepartmentDto;
        }

        public async Task<DepartmentDto> DeleteDepartment(int id)

        {
            Department department = await _dbcontext.Department.FindAsync(id);

            if (department == null) return null;

            _dbcontext.Department.Remove(department);
            await _dbcontext.SaveChangesAsync();

            return new DepartmentDto()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                DepartmentCode = department.DepartmentCode,
            };


        }

        public async Task<List<DepartmentDto>> GetAllDepartment()
        {
            List<DepartmentDto> departmentList = await _dbcontext.Department.Select(x => new DepartmentDto
            {
                DepartmentId = x.DepartmentId,
                DepartmentName = x.DepartmentName,
                DepartmentCode = x.DepartmentCode
            }).ToListAsync();

            return departmentList;
            
        }

        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            Department department = await _dbcontext.Department.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if(department == null)
            {
                return null;
            }
            DepartmentDto departmentDto = new DepartmentDto(){
                DepartmentId = department.DepartmentId,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName
            };

            return departmentDto;
        }

        public async Task<DepartmentDto> UpdateDepartment(int id, DepartmentDto department)
        {

            Department existingDepartment = await _dbcontext.Department
                                                .FirstOrDefaultAsync(x => x.DepartmentId == id);

            if (existingDepartment == null) return null;

            existingDepartment.DepartmentName = department.DepartmentName;
            existingDepartment.DepartmentCode = department.DepartmentCode;

            await _dbcontext.SaveChangesAsync();

            DepartmentDto updatedDepartment = new DepartmentDto()
            {
                DepartmentId = existingDepartment.DepartmentId,
                DepartmentCode = existingDepartment.DepartmentCode,
                DepartmentName = existingDepartment.DepartmentName,
            };

            return updatedDepartment;
        }
    }
}
