using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Data.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly DbConnectContext _db;
        public StudentService(DbConnectContext db)
        {
            _db = db;
        }
        public async Task<List<StudentDto>> GetAllStudent()
        {
            //List<Student> students = await _db.Students.FindAsync().ToListAsync();


            //return students.ToList();
            return await _db.Student
       .Select(s => new StudentDto
       {
           StudentID = s.StudentID,
           Name = s.Name,
           Email = s.Email,
           Phone = s.Phone,
           RegistrationDate = s.RegistrationDate
       })
       .ToListAsync();
        }

        public async Task<StudentDto> AddStudent(StudentDto student)
        {
            Student Entity = new Student{
                Email = student.Email,
                Name = student.Name,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                DOB = student.DOB

            };

            await _db.AddAsync(Entity);
            await _db.SaveChangesAsync();

            StudentDto newStudent = new StudentDto
            {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                RegistrationDate = student.RegistrationDate,
                DOB = student.DOB
            };



            return newStudent;
        }


        public async Task<StudentDto> GetStudentById(int id)
        {
            var getStudent = await _db.Student.Where(x => x.StudentID == id)
                .Select(x => new StudentDto
                {
                    StudentID = x.StudentID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    RegistrationDate = x.RegistrationDate
                })
                .FirstOrDefaultAsync();

            if (getStudent == null)
            {
                return null;
            }



            return getStudent;
        }


        public async Task<StudentDto> GetStudentByEmail(string email)
        {
            var getStudent = await _db.Student.Where(x => x.Email == email)
                .Select(x => new StudentDto
                {
                    StudentID = x.StudentID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    RegistrationDate = x.RegistrationDate
                })
                .FirstOrDefaultAsync();

            if (getStudent == null)
            {
                return null;
            }



            return getStudent;
        }



        public async Task<StudentDto> GetStudentByPhone(string phone)
        {
            var getStudent = await _db.Student.Where(x => x.Phone == phone)
                .Select(x => new StudentDto
                {
                    StudentID = x.StudentID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    RegistrationDate = x.RegistrationDate
                })
                .FirstOrDefaultAsync();

            if (getStudent == null)
            {
                return null;
            }



            return getStudent;
        }



    }
}
