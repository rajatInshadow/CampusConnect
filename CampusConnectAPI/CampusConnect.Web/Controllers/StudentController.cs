using CampusConnect.Application.Interfaces;
using CampusConnect.Data;
using CampusConnect.Model.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudent()
        {

            List<StudentDto> studentDtos = await _studentRepository.GetAllStudent();

            return Ok(studentDtos);

        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentDto student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var isStudentEmailExist = await _studentRepository.GetStudentByEmail(student.Email);
            var isStudentPhoneExist = await _studentRepository.GetStudentByPhone(student.Phone);

            if (isStudentEmailExist != null || isStudentPhoneExist != null)
            {
                return isStudentEmailExist != null ? Conflict(new
                {
                    message = "Email is already in use"
                }) : Conflict(new { message = "Phone number is already in use" });
            }

            StudentDto studentDto = new StudentDto();

            studentDto = await _studentRepository.AddStudent(student);

            return Ok(studentDto);
        }


        [HttpPost]
        [Route("updateStudent")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(int Id, StudentDto student)
        {
            if (student == null)
            {

                return BadRequest("data is missing");
            }
            else
            {
              var updatedStudent =  await _studentRepository.UpdateStudent(Id,student);
                return Ok(updatedStudent);
            }

        }


        [HttpDelete]
        public async Task<ActionResult<StudentDto>> DeleteStudent(int Id)
        {
            
             await _studentRepository.DeleteStudent(Id);
            return Ok("Record deleted Successfully");
        }
    }
}
