using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class CourseService : ICourseRepository
    {
        private readonly DbConnectContext _dbContext;
        public CourseService(DbConnectContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CourseDto> CreateCourse(CourseDto course)
        {
            //Course isCourseExits = await _dbContext.Course.FindAsync(course.CourseID);

            //if (isCourseExits == null) return null;

            Course newCourse = new Course()
            {
                CourseID = course.CourseID,
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                DepartmentID = course.DepartmentID
            };

            _dbContext.AddAsync(newCourse);
            await _dbContext.SaveChangesAsync();

            return course;
        }

        public async Task<ApiResponse<CourseDto>> DeleteCourse(int Id)
        {
            Course isCourseExits = await _dbContext.Course.FindAsync(Id);

            if (isCourseExits == null)
            {
                ApiResponse<CourseDto> response = new ApiResponse<CourseDto>
                {
                    Success = false,
                    Message = "Course Does not exists",
                    Data = null
                };
            }


           _dbContext.Course.Remove(isCourseExits);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse<CourseDto>
            {
                Success = true,
                Message = "Course deleted successfully",
                Data = null
            };
            

        }

        public async Task<List<CourseDto>> GetAllCourses()
        {
            List<CourseDto> courseList = await _dbContext.Course.Select(x=> new CourseDto()
            {
                CourseID = x.CourseID,
                CourseCode = x.CourseCode,
                CourseName = x.CourseName,
                DepartmentID = x.DepartmentID
            }).ToListAsync();

           
            return courseList;
        }

        public async Task<CourseDto> GetCourseById(int Id)
        {
            Course? course = await _dbContext.Course.FindAsync(Id);

            if (course == null)
            {
                return null;
            }

            CourseDto courseDto = new CourseDto()
            {
                CourseID = course.CourseID,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                DepartmentID = course.DepartmentID
            };

            return courseDto;
        }

        public async Task<CourseDto> UpdateCourse(CourseDto course)
        {
            Course? existingcourse = await _dbContext.Course.FindAsync(course.CourseID);

            if (course == null)
            {
                return null;
            }


            existingcourse.CourseID = course.CourseID;
            existingcourse.CourseCode = course.CourseCode;
            existingcourse.CourseCode = course.CourseName;
            existingcourse.DepartmentID = course.DepartmentID;

            await _dbContext.SaveChangesAsync();

            CourseDto courseDto = new CourseDto()
            {
                CourseID = existingcourse.CourseID,
                CourseCode = existingcourse.CourseCode,
                CourseName = existingcourse.CourseName,
                DepartmentID = existingcourse.DepartmentID

            };
            

            return courseDto;
        }
    }
}
