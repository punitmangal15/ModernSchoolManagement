using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Services
{
    public class SchoolService : ISchoolModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public SchoolService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<SchoolModel>> GetAllSchoolDetails()
        {
            string sp = "sp_GetAllSchools";
            try
            {
                return await dynamicRepository.GetAll<SchoolModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch school details.", ex);
            }
        }

        public async Task<SchoolModel> GetSchoolDetail(long Id)
        {
            string sp = "sp_GetSchoolInformation";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SchoolId", Id);
            try
            {
                return await dynamicRepository.Get<SchoolModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch school detail.", ex);
            }

        }

        public async Task<SchoolModel> AddSchool(SchoolModel schoolModel)
        {
            string sp = "sp_AddSchoolInformation";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SchoolName", schoolModel.Name);
            dynamicParameters.Add("@Address", schoolModel.Address);
            dynamicParameters.Add("@PhoneNumber", schoolModel.PhoneNumber);
            dynamicParameters.Add("@EmailId", schoolModel.EmailId);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<SchoolModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add school.", ex);
            }
        }
        public async Task<SchoolModel> UpdateSchool(SchoolModel schoolModel)
        {
            string sp = "sp_UpdateSchoolInformation";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SchoolId", schoolModel.SchoolId);
            dynamicParameters.Add("@SchoolName", schoolModel.Name);
            dynamicParameters.Add("@Address", schoolModel.Address);
            dynamicParameters.Add("@PhoneNumber", schoolModel.PhoneNumber);
            dynamicParameters.Add("@EmailId", schoolModel.EmailId);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<SchoolModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update school.", ex);
            }
        }
        public async Task<SchoolModel> DeleteSchool(long Id)
        {
            string sp = "sp_DeleteSchoolInformation";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SchoolId", Id);
            try
            {
                return dynamicRepository.Delete<SchoolModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete school.", ex);
            }
        }

    }
}
