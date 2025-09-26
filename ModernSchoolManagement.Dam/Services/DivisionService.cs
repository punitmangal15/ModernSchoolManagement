using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class DivisionService : IDivisionModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public DivisionService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<DivisionModel>> GetAllDivisionDetails()
        {
            string sp = "dbo.sp_GetAllDivision";
            try
            {
                return await dynamicRepository.GetAll<DivisionModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch division details.", ex);
            }
        }

        public async Task<DivisionModel> GetDivisionDetail(long Id)
        {
            string sp = "dbo.sp_GetDivision";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DivisionId", Id);
            try
            {
                return await dynamicRepository.Get<DivisionModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch division detail.", ex);
            }

        }

        public async Task<DivisionModel> AddDivision(DivisionModel DivisionModel)
        {
            string sp = "dbo.sp_AddDivision";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClassId", DivisionModel.ClassId);
            dynamicParameters.Add("@DivisionName", DivisionModel.Name);
            dynamicParameters.Add("@Description", DivisionModel.Description);
            dynamicParameters.Add("@Is_Active", DivisionModel.Is_Active);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<DivisionModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add division.", ex);
            }
        }
        public async Task<DivisionModel> UpdateDivision(DivisionModel DivisionModel)
        {
            string sp = "dbo.sp_UpdateDivision";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DivisionId", DivisionModel.Id);
            dynamicParameters.Add("@ClassId", DivisionModel.ClassId);
            dynamicParameters.Add("@DivisionName", DivisionModel.Name);
            dynamicParameters.Add("@Description", DivisionModel.Description);
            dynamicParameters.Add("@Is_Active", DivisionModel.Is_Active);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<DivisionModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update division.", ex);
            }
        }
        public async Task<DivisionModel> DeleteDivision(long Id)
        {
            string sp = "dbo.sp_DeleteDivision";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DivisionId", Id);
            try
            {
                return dynamicRepository.Delete<DivisionModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete division.", ex);
            }
        }

    }
}
