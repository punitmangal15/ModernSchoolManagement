using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class SubjectService : ISubjectModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public SubjectService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<SubjectModel>> GetAllSubjectDetails()
        {
            string sp = "dbo.sp_GetAllSubject";
            try
            {
                return await dynamicRepository.GetAll<SubjectModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch subject details.", ex);
            }
        }

        public async Task<SubjectModel> GetSubjectDetail(long Id)
        {
            string sp = "dbo.sp_GetSubject";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SubjectId", Id);
            try
            {
                return await dynamicRepository.Get<SubjectModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch subject detail.", ex);
            }

        }

        public async Task<SubjectModel> AddSubject(SubjectModel SubjectModel)
        {
            string sp = "dbo.sp_AddSubject";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SubjectName", SubjectModel.SubjectName);
            dynamicParameters.Add("@Description", SubjectModel.Description);
            dynamicParameters.Add("@Attachment", SubjectModel.Attachment);
            dynamicParameters.Add("@Is_Active", SubjectModel.Is_Active);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<SubjectModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add subject.", ex);
            }
        }
        public async Task<SubjectModel> UpdateSubject(SubjectModel SubjectModel)
        {
            string sp = "dbo.sp_UpdateSubject";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SubjectId", SubjectModel.Id);
            dynamicParameters.Add("@SubjectName", SubjectModel.SubjectName);
            dynamicParameters.Add("@Description", SubjectModel.Description);
            dynamicParameters.Add("@Attachment", SubjectModel.Attachment);
            dynamicParameters.Add("@Is_Active", SubjectModel.Is_Active);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<SubjectModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update subject.", ex);
            }
        }
        public async Task<SubjectModel> DeleteSubject(long Id)
        {
            string sp = "dbo.sp_DeleteSubject";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@SubjectId", Id);
            try
            {
                return dynamicRepository.Delete<SubjectModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete subject.", ex);
            }
        }

    }
}
