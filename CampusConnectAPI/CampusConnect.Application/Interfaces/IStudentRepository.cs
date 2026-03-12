using CampusConnect.Model.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAllStudent();
        Task<StudentDto> AddStudent(StudentDto student);
        Task<StudentDto> UpdateStudent(int id, StudentDto student);
        Task DeleteStudent(int id);
        Task<StudentDto> GetStudentById(int id);
        Task<StudentDto> GetStudentByEmail(string email);
        Task<StudentDto> GetStudentByPhone(string phone);
    }
}
