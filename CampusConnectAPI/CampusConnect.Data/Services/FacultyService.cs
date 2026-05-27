using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class FacultyService : IFacultyRepository
    {
        private readonly DbConnectContext _dbContext;

        public FacultyService(DbConnectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FacultyDto>> GetAllFaculties()
        {
            return await _dbContext.Faculty
                .Select(f => new FacultyDto
                {
                    FacultyId = f.FacultyId,
                    Name = f.Name,
                    Email = f.Email,
                    Phone = f.Phone,
                    DepartmentId = f.DepartmentId,
                    FacultyCode = f.FacultyCode
                })
                .ToListAsync();
        }

        public async Task<FacultyDto> GetFacultyById(int id)
        {
            Faculty faculty = await _dbContext.Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == id);

            if (faculty == null)
            {
                return null;
            }

            return new FacultyDto
            {
                FacultyId = faculty.FacultyId,
                Name = faculty.Name,
                Email = faculty.Email,
                Phone = faculty.Phone,
                DepartmentId = faculty.DepartmentId,
                FacultyCode = faculty.FacultyCode
            };
        }

        public async Task<ApiResponse<FacultyDto>> CreateFaculty(FacultyDto facultyDto)
        {
            Faculty faculty = new Faculty
            {
                Name = facultyDto.Name,
                Email = facultyDto.Email,
                Phone = facultyDto.Phone,
                DepartmentId = facultyDto.DepartmentId,
                FacultyCode = facultyDto.FacultyCode
            };

            await _dbContext.Faculty.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();

            facultyDto.FacultyId = faculty.FacultyId;

            return new ApiResponse<FacultyDto>
            {
                Success = true,
                Message = "Faculty created successfully",
                Data = facultyDto
            };
        }

        public async Task<ApiResponse<FacultyDto>> UpdateFaculty(int id, FacultyDto facultyDto)
        {
            Faculty faculty = await _dbContext.Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == id);

            if (faculty == null)
            {
                return null;
            }

            faculty.Name = facultyDto.Name;
            faculty.Email = facultyDto.Email;
            faculty.Phone = facultyDto.Phone;
            faculty.DepartmentId = facultyDto.DepartmentId;
            faculty.FacultyCode = facultyDto.FacultyCode;

            _dbContext.Faculty.Update(faculty);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse<FacultyDto>
            {
                Success = true,
                Message = "Faculty updated successfully",
                Data = facultyDto
            };
        }

        public async Task<ApiResponse<FacultyDto>> DeleteFaculty(int id)
        {
            Faculty faculty = await _dbContext.Faculty
                .FirstOrDefaultAsync(f => f.FacultyId == id);

            if (faculty == null)
            {
                return null;
            }

            _dbContext.Faculty.Remove(faculty);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse<FacultyDto>
            {
                Success = true,
                Message = "Faculty deleted successfully"
            };
        }
    }
}