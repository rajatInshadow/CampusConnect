using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class EnrollmentService : IEnrollmentRepository
    {
        private readonly DbConnectContext _dbContext;

        public EnrollmentService(DbConnectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EnrollmentDto>> GetAllEnrollments()
        {
            return await _dbContext.Enrollment
                .Select(e => new EnrollmentDto
                {
                    EnrollmentId = e.EnrollmentId,
                    StudentId = e.StudentId,
                    CourseId = e.CourseId,
                    EnrollmentDate = e.EnrollmentDate
                })
                .ToListAsync();
        }

        public async Task<EnrollmentDto> GetEnrollmentById(int id)
        {
            Enrollment enrollment = await _dbContext.Enrollment
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
            {
                return null;
            }

            return new EnrollmentDto
            {
                EnrollmentId = enrollment.EnrollmentId,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = enrollment.EnrollmentDate
            };
        }

        public async Task<ApiResponse<EnrollmentDto>> CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            Enrollment enrollment = new Enrollment
            {
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId,
                EnrollmentDate = enrollmentDto.EnrollmentDate
            };

            await _dbContext.Enrollment.AddAsync(enrollment);
            await _dbContext.SaveChangesAsync();

            enrollmentDto.EnrollmentId = enrollment.EnrollmentId;

            return new ApiResponse<EnrollmentDto>
            {
                Success = true,
                Message = "Enrollment created successfully",
                Data = enrollmentDto
            };
        }

        public async Task<ApiResponse<EnrollmentDto>> UpdateEnrollment(int id, EnrollmentDto enrollmentDto)
        {
            Enrollment enrollment = await _dbContext.Enrollment
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
            {
                return null;
            }

            enrollment.StudentId = enrollmentDto.StudentId;
            enrollment.CourseId = enrollmentDto.CourseId;
            enrollment.EnrollmentDate = enrollmentDto.EnrollmentDate;

            _dbContext.Enrollment.Update(enrollment);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse<EnrollmentDto>
            {
                Success = true,
                Message = "Enrollment updated successfully",
                Data = enrollmentDto
            };
        }

        public async Task<ApiResponse<EnrollmentDto>> DeleteEnrollment(int id)
        {
            Enrollment enrollment = await _dbContext.Enrollment
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
            {
                return null;
            }

            _dbContext.Enrollment.Remove(enrollment);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse<EnrollmentDto>
            {
                Success = true,
                Message = "Enrollment deleted successfully"
            };
        }
    }
}