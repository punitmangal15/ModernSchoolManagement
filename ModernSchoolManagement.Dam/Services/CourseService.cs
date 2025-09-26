using Dapper;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Data;
namespace ModernSchoolManagement.Dam.Services
{
    public class CourseService : ICourseModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public CourseService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<CourseModel>> GetAllCourseDetails()
        {
            string sp = "dbo.sp_GetAllCourse";
            try
            {
                return await dynamicRepository.GetAll<CourseModel>(sp, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch course details.", ex);
            }
        }

        public async Task<CourseModel> GetCourseDetail(long Id)
        {
            string sp = "dbo.sp_GetCourse";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CourseId", Id);
            try
            {
                return await dynamicRepository.Get<CourseModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch course detail.", ex);
            }

        }

        public async Task<CourseModel> AddCourse(CourseModel CourseModel)
        {
            string sp = "dbo.sp_AddCourse";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CourseName", CourseModel.CourseName);
            dynamicParameters.Add("@Description", CourseModel.Description);
            dynamicParameters.Add("@AcademicYearId", CourseModel.AcademicYearId);
            dynamicParameters.Add("@Is_Active", CourseModel.Is_Active);
            dynamicParameters.Add("@CreatedBy", "dummy");
            try
            {
                return dynamicRepository.Add<CourseModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add course detail.", ex);
            }
        }
        public async Task<CourseModel> UpdateCourse(CourseModel CourseModel)
        {
            string sp = "dbo.sp_UpdateCourse";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CourseId", CourseModel.Id);
            dynamicParameters.Add("@CourseName", CourseModel.CourseName);
            dynamicParameters.Add("@Description", CourseModel.Description);
            dynamicParameters.Add("@AcademicYearId", CourseModel.AcademicYearId);
            dynamicParameters.Add("@Is_Active", CourseModel.Is_Active);
            dynamicParameters.Add("@ModifiedBy", "dummy");
            try
            {
                return dynamicRepository.Update<CourseModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update course detail.", ex);
            }
        }
        public async Task<CourseModel> DeleteCourse(long Id)
        {
            string sp = "dbo.sp_DeleteCourse";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CourseId", Id);
            try
            {
                return dynamicRepository.Delete<CourseModel>(sp, dynamicParameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete course detail.", ex);
            }
        }

    }
}
