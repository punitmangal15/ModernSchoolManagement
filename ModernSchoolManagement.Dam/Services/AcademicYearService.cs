using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class AcademicYearService : IAcademicYearModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public AcademicYearService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<AcademicYearModel>> GetAllAcademicYearDetails()
        {
            string sp = "dbo.sp_GetAllAcademicYear";
            try
            {
                return await dynamicRepository.GetAll<AcademicYearModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AcademicYearModel> GetAcademicYearDetail(long Id)
        {
            string sp = "dbo.sp_GetAcademicYear";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AcademicYearId", Id);
            try
            {
                return await dynamicRepository.Get<AcademicYearModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<AcademicYearModel> AddAcademicYear(AcademicYearModel AcademicYearModel)
        {
            string sp = "dbo.sp_AddAcademicYear";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AcademicYearName", AcademicYearModel.AcademicName);
            dynamicParameters.Add("@Startdate", AcademicYearModel.startdate);
            dynamicParameters.Add("@Enddate", AcademicYearModel.enddate);
            dynamicParameters.Add("@Is_Active", AcademicYearModel.Is_Active);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<AcademicYearModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<AcademicYearModel> UpdateAcademicYear(AcademicYearModel AcademicYearModel)
        {
            string sp = "dbo.sp_UpdateAcademicYear";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AcademicYearId", AcademicYearModel.Id);
            dynamicParameters.Add("@AcademicYearName", AcademicYearModel.AcademicName);
            dynamicParameters.Add("@Startdate", AcademicYearModel.startdate);
            dynamicParameters.Add("@Enddate", AcademicYearModel.enddate);
            dynamicParameters.Add("@Is_Active", AcademicYearModel.Is_Active);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<AcademicYearModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<AcademicYearModel> DeleteAcademicYear(long Id)
        {
            string sp = "dbo.sp_DeleteAcademicYear";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AcademicYearId", Id);
            try
            {
                return dynamicRepository.Delete<AcademicYearModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
