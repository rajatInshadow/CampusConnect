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

        [HttpGet("{Id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int Id)
        {
            StudentDto student = await _studentRepository.GetStudentById(Id);
            if(student == null)
            {
                return NotFound("student does not exits");
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("GetStudentByEmail")]
        public async Task<ActionResult<StudentDto>> GetStudentByEmail(string email)
        {
            StudentDto student = await _studentRepository.GetStudentByEmail(email);
            if (student == null)
            {
                return NotFound("student does not exits");
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("GetStudentByPhone")]
        public async Task<ActionResult<StudentDto>> GetStudentByPhone(string phone)
        {
            StudentDto student = await _studentRepository.GetStudentByPhone(phone);
            if (student == null)
            {
                return NotFound("student does not exits");
            }
            return Ok(student);
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


        [HttpPut("{Id}")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(int Id, StudentDto student)
        {
            if (student == null)
            {

                return BadRequest("data is missing");
            }
            else
            {
              var updatedStudent =  await _studentRepository.UpdateStudent(Id,student);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudent);
            }

        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult<StudentDto>> DeleteStudent(int Id)
        {
            
             await _studentRepository.DeleteStudent(Id);
            return Ok("Record deleted Successfully");
        }
    }
}
