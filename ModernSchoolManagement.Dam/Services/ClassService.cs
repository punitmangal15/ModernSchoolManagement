using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class ClassService : IClassModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public ClassService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<ClassModel>> GetAllClassDetails()
        {
            string sp = "dbo.sp_GetAllClass";
            try
            {
                return await dynamicRepository.GetAll<ClassModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ClassModel> GetClassDetail(long Id)
        {
            string sp = "dbo.sp_GetClass";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClassId", Id);
            try
            {
                return await dynamicRepository.Get<ClassModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<ClassModel> AddClass(ClassModel ClassModel)
        {
            string sp = "dbo.sp_AddClass";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@ClassId", ClassModel.Id);
            dynamicParameters.Add("@ClassName", ClassModel.Name);
            dynamicParameters.Add("@Description", ClassModel.Description);
            dynamicParameters.Add("@Attachment", ClassModel.Attachment);
            dynamicParameters.Add("@Is_Active", ClassModel.Is_Active);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<ClassModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ClassModel> UpdateClass(ClassModel ClassModel)
        {
            string sp = "dbo.sp_UpdateClass";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClassId", ClassModel.Id);
            dynamicParameters.Add("@ClassName", ClassModel.Name);
            dynamicParameters.Add("@Description", ClassModel.Description);
            dynamicParameters.Add("@Attachment", ClassModel.Attachment);
            dynamicParameters.Add("@Is_Active", ClassModel.Is_Active);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<ClassModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ClassModel> DeleteClass(long Id)
        {
            string sp = "dbo.sp_DeleteClass";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ClassId", Id);
            try
            {
                return dynamicRepository.Delete<ClassModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
