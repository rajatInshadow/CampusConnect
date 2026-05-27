using CampusConnect.Application.Interfaces;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnect.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionRepository _admissionRepository;
        public AdmissionController(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;

        }

        [HttpGet]
        [Route("GetAllAdmission")]
        public async Task<ActionResult<List<AdmissionDto>>> Get()
        {

            List<AdmissionDto> admissionList = await _admissionRepository.GetAllAdmissions();
            return Ok(admissionList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdmissionDto>> GetAdmissionById(int id)
        {

            AdmissionDto admission = await _admissionRepository.GetAdmissionById(id);
            if (admission == null)
            {
                return NotFound("Admission does not exist");
            }
            return Ok(admission);
        }

        [HttpPost]
        [Route("CreateAdmission")]
        public async Task<ActionResult<ApiResponse<AdmissionDto>>> CreateAdmission(AdmissionDto admission)
        {

            ApiResponse<AdmissionDto> newAdmission = await _admissionRepository.CreateAdmission(admission);
            if (newAdmission == null)
            {
                return NotFound("Admission does not exist");
            }
            return Ok(newAdmission);
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<ApiResponse<AdmissionDto>>> UpdateAdmission(int Id, AdmissionDto admission)
        {

            ApiResponse<AdmissionDto> updatedAdmission = await _admissionRepository.UpdateAdmission(Id, admission);
            if (updatedAdmission == null)
            {
                return NotFound("Admission does not exist");
            }
            return Ok(updatedAdmission);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ApiResponse<AdmissionDto>>> DeleteAdmission(int Id)
        {

            ApiResponse<AdmissionDto> DeletedAdmission = await _admissionRepository.DeleteAdmission(Id);
            if (DeletedAdmission == null)
            {
                return NotFound("Admission does not exist");
            }
            return Ok(DeletedAdmission);
        }
    }
}
