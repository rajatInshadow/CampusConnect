using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Application.Interfaces
{
    public interface IAdmissionRepository
    {
        Task<List<AdmissionDto>> GetAllAdmissions();
        Task<AdmissionDto> GetAdmissionById(int id);
        Task<ApiResponse<AdmissionDto>> CreateAdmission(AdmissionDto admissionDto);
        Task<ApiResponse<AdmissionDto>> UpdateAdmission(int id,AdmissionDto admissionDto);
        Task<ApiResponse<AdmissionDto>> DeleteAdmission(int id);

    }
}
