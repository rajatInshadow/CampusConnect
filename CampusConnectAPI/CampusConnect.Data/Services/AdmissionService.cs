using CampusConnect.Application.Interfaces;
using CampusConnect.Model;
using CampusConnect.Model.Dtos;
using CampusConnect.Utils.Common.ApiResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Data.Services
{
    public class AdmissionService : IAdmissionRepository
    {
        private readonly DbConnectContext _dbConnectContext;
        public AdmissionService(DbConnectContext dbConnectContext) { 
            _dbConnectContext = dbConnectContext;
        }
        public async Task<ApiResponse<AdmissionDto>> CreateAdmission(AdmissionDto admissionDto)
        {
            Admission admission = new Admission()
            {
                AdmissionId = admissionDto.AdmissionId,
                AcademicYear = admissionDto.AcademicYear,
                StudentId = admissionDto.StudentId,
                AdmissionDate = admissionDto.AdmissionDate,
                Status = admissionDto.Status
            };

               await _dbConnectContext.Admission.AddAsync(admission);
               await _dbConnectContext.SaveChangesAsync();

            AdmissionDto admissionEntity = new AdmissionDto()
            {
                AdmissionId = admissionDto.AdmissionId,
                StudentId = admissionDto.StudentId,
                AdmissionDate = admissionDto.AdmissionDate,
                Status = admissionDto.Status
            };

            return new ApiResponse<AdmissionDto>()
            {
                Success = true,
                Message = "Admission created",
                Data = admissionEntity
            };
        }

        public async Task<ApiResponse<AdmissionDto>> DeleteAdmission(int id)
        {
            Admission entity = await _dbConnectContext.Admission.FindAsync(id);

            if (entity == null) return null;

             _dbConnectContext.Admission.Remove(entity);
            await _dbConnectContext.SaveChangesAsync();

            return new ApiResponse<AdmissionDto>()
            {
                Success = true,
               Message = "Delete successfully",
               Data = null
            };
        }

        public async Task<AdmissionDto> GetAdmissionById(int id)
        {
            Admission admission = await _dbConnectContext.Admission.FirstOrDefaultAsync(x=>x.AdmissionId == id);

            AdmissionDto admissionDto = new AdmissionDto()
            {
                StudentId = admission.StudentId,
                AcademicYear = admission.AcademicYear,
                AdmissionDate = admission.AdmissionDate,
                AdmissionId = admission.AdmissionId,
                Status = admission.Status,

            };

            return admissionDto;
        }

        public async Task<List<AdmissionDto>> GetAllAdmissions()
        {
            return await _dbConnectContext.Admission.Select(x => new AdmissionDto
            {
                AdmissionId = x.AdmissionId,
                StudentId = x.StudentId,
                AcademicYear = x.AcademicYear,
                AdmissionDate = x.AdmissionDate,
                Status = x.Status,

            }).ToListAsync();
        }

        public async Task<ApiResponse<AdmissionDto>> UpdateAdmission(int id,AdmissionDto admissionDto)
        {
            Admission entity = await _dbConnectContext.Admission.FindAsync(id);

            if (entity == null) {
                return null;
            }

           entity.AdmissionDate = admissionDto.AdmissionDate;
            entity.Status = admissionDto.Status;
            entity.AcademicYear = admissionDto.AcademicYear;
            entity.StudentId = admissionDto.StudentId;

            await _dbConnectContext.SaveChangesAsync();

            return new ApiResponse<AdmissionDto>
            {
                Success = true,
                Message = "Update successfully",
                Data = admissionDto
            };

        }   
    }
}
