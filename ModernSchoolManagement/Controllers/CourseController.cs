using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

namespace ModernCourseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class CourseController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseModel _CourseDetails;
        public CourseController(IAuthentication authentication, ILogger<CourseController> logger, ICourseModel CourseModel)
        {
            _authentication = authentication;
            _logger = logger;
            _CourseDetails = CourseModel;

        }
        [HttpGet(Name = "GetAllCourseDetails")]
        [AllowAnonymous]
        public async Task<IEnumerable<CourseModel>> GetAllCourseDetails()
        {
            _logger.LogInformation("Fetching all course details.");
            try
            {
                var courses = await _CourseDetails.GetAllCourseDetails();
                _logger.LogInformation("Successfully fetched {Count} courses.", courses?.Count() ?? 0);
                return courses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all course details.");
                throw;
            }
        }

        [HttpGet(Name = "GetCourseDetail")]
        [AllowAnonymous]
        public async Task<CourseModel> GetCourseDetail(long Id)
        {
            _logger.LogInformation("Fetching course detail for Id: {Id}", Id);
            try
            {
                var course = await _CourseDetails.GetCourseDetail(Id);
                if (course == null)
                {
                    _logger.LogWarning("Course with Id: {Id} not found.", Id);
                }
                else
                {
                    _logger.LogInformation("Successfully fetched course detail for Id: {Id}", Id);
                }
                return course;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching course detail for Id: {Id}", Id);
                throw;
            }
        }

        [HttpPost(Name = "AddCourse")]
        [AllowAnonymous]
        public async Task<CourseModel> AddCourse(CourseModel CourseModel)
        {
            _logger.LogInformation("Adding new course: {CourseName}", CourseModel.CourseName);
            try
            {
                var result = await _CourseDetails.AddCourse(CourseModel);
                _logger.LogInformation("Successfully added course with Id: {Id}", result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding course: {CourseName}", CourseModel.CourseName);
                throw;
            }
        }

        [HttpPost(Name = "UpdateCourse")]
        [AllowAnonymous]
        public async Task<CourseModel> UpdateCourse(CourseModel CourseModel)
        {
            _logger.LogInformation("Updating course with Id: {Id}", CourseModel.Id);
            try
            {
                var result = await _CourseDetails.UpdateCourse(CourseModel);
                _logger.LogInformation("Successfully updated course with Id: {Id}", result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating course with Id: {Id}", CourseModel.Id);
                throw;
            }
        }

        [HttpPost(Name = "DeleteCourse")]
        [AllowAnonymous]
        public async Task<CourseModel> DeleteCourse(long Id)
        {
            _logger.LogInformation("Deleting course with Id: {Id}", Id);
            try
            {
                var result = await _CourseDetails.DeleteCourse(Id);
                _logger.LogInformation("Successfully deleted course with Id: {Id}", Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting course with Id: {Id}", Id);
                throw;
            }
        }

    }
}
