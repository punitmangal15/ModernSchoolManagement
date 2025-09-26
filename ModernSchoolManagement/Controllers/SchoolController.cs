using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Dam.Models;

namespace ModernSchoolManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class SchoolController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<SchoolController> _logger;
        private readonly ISchoolModel _schoolDetails;
        public SchoolController(IAuthentication authentication, ILogger<SchoolController> logger, ISchoolModel schoolModel)
        {
            _authentication = authentication;
            _logger = logger;
            _schoolDetails = schoolModel;

        }
        [HttpGet(Name = "GetAllSchoolDetails")]
        [AllowAnonymous]
        public async Task<IEnumerable<SchoolModel>> GetAllSchoolDetails()
        {
            _logger.LogInformation("Fetching all school details.");
            try
            {
                var schools = await _schoolDetails.GetAllSchoolDetails();
                _logger.LogInformation("Fetched {Count} schools.", schools?.Count() ?? 0);
                return schools;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all school details.");
                throw;
            }
        }

        [HttpGet(Name = "GetSchoolDetail")]
        [AllowAnonymous]
        public async Task<SchoolModel> GetSchoolDetail(long Id)
        {
            _logger.LogInformation("Fetching details for school with Id: {Id}", Id);
            try
            {
                var school = await _schoolDetails.GetSchoolDetail(Id);
                if (school == null)
                {
                    _logger.LogWarning("No school found with Id: {Id}", Id);
                }
                else
                {
                    _logger.LogInformation("Fetched details for school with Id: {Id}", Id);
                }
                return school;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching school details for Id: {Id}", Id);
                throw;
            }
        }

        [HttpPost(Name = "AddSchool")]
        [AllowAnonymous]
        public async Task<SchoolModel> AddSchool(SchoolModel schoolModel)
        {
            _logger.LogInformation("Adding new school: {@SchoolModel}", schoolModel);
            try
            {
                var result = await _schoolDetails.AddSchool(schoolModel);
                _logger.LogInformation("Added school with Id: {Id}", result?.SchoolId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding school: {@SchoolModel}", schoolModel);
                throw;
            }
        }

        [HttpPost(Name = "UpdateSchool")]
        [AllowAnonymous]
        public async Task<SchoolModel> UpdateSchool(SchoolModel schoolModel)
        {
            _logger.LogInformation("Updating school with Id: {Id}", schoolModel.SchoolId);
            try
            {
                var result = await _schoolDetails.UpdateSchool(schoolModel);
                _logger.LogInformation("Updated school with Id: {Id}", result?.SchoolId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating school with Id: {Id}", schoolModel.SchoolId);
                throw;
            }
        }

        [HttpPost(Name = "DeleteSchool")]
        [AllowAnonymous]
        public async Task<SchoolModel> DeleteSchool(long Id)
        {
            _logger.LogInformation("Deleting school with Id: {Id}", Id);
            try
            {
                var result = await _schoolDetails.DeleteSchool(Id);
                _logger.LogInformation("Deleted school with Id: {Id}", result?.SchoolId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting school with Id: {Id}", Id);
                throw;
            }
        }

    }
}
