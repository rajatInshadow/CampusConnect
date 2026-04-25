using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentrepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentrepository = departmentRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            // Logic to retrieve departments from the database
            List<DepartmentDto> departmentList = await _departmentrepository.GetAllDepartment();
            return departmentList == null ? NotFound("Department deos not exits") : Ok(departmentList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            // Logic to retrieve a department by its ID from the database
            DepartmentDto departmentDto = await _departmentrepository.GetDepartmentById(id);
            return departmentDto == null ? NotFound("Department deos not exits") : Ok(departmentDto);
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentDto department)
        {
            // Logic to create a new department in the database
            DepartmentDto newDepartment = await _departmentrepository.AddDepartment(department);

            if (newDepartment == null)
            {
                return NotFound("department already exists");
            }

            return Ok(newDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDto department)
        {
            DepartmentDto departmentDto = await _departmentrepository.UpdateDepartment(id, department);
            return departmentDto == null ? NotFound("Department deos not exits") : Ok(departmentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            // Logic to delete a department from the database

            DepartmentDto departmentDto = await _departmentrepository.DeleteDepartment(id);
            return departmentDto == null ? NotFound("Department deos not exits") : StatusCode(200, "Department deleted successfully");
        }


    }
}
