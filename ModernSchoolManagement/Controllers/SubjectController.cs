using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

namespace ModernSubjectManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class SubjectController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<SubjectController> _logger;
        private readonly ISubjectModel _SubjectDetails;
        public SubjectController(IAuthentication authentication, ILogger<SubjectController> logger, ISubjectModel SubjectModel)
        {
            _authentication = authentication;
            _logger = logger;
            _SubjectDetails = SubjectModel;

        }
        [HttpGet(Name = "GetAllSubjectDetails")]
        [AllowAnonymous]
        public async Task<IEnumerable<SubjectModel>> GetAllSubjectDetails()
        {
            _logger.LogInformation("Fetching all subject details.");
            try
            {
                var subjects = await _SubjectDetails.GetAllSubjectDetails();
                _logger.LogInformation("Fetched {Count} subjects.", subjects?.Count() ?? 0);
                return subjects;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all subject details.");
                throw;
            }
        }

        [HttpGet(Name = "GetSubjectDetail")]
        [AllowAnonymous]
        public async Task<SubjectModel> GetSubjectDetail(long Id)
        {
            _logger.LogInformation("Fetching details for subject with Id: {Id}", Id);
            try
            {
                var subject = await _SubjectDetails.GetSubjectDetail(Id);
                if (subject == null)
                {
                    _logger.LogWarning("No subject found with Id: {Id}", Id);
                }
                else
                {
                    _logger.LogInformation("Fetched details for subject with Id: {Id}", Id);
                }
                return subject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching subject details for Id: {Id}", Id);
                throw;
            }
        }

        [HttpPost(Name = "AddSubject")]
        [AllowAnonymous]
        public async Task<SubjectModel> AddSubject(SubjectModel SubjectModel)
        {
            _logger.LogInformation("Adding new subject: {@SubjectModel}", SubjectModel);
            try
            {
                var result = await _SubjectDetails.AddSubject(SubjectModel);
                _logger.LogInformation("Added subject with Id: {Id}", result?.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding subject: {@SubjectModel}", SubjectModel);
                throw;
            }
        }

        [HttpPost(Name = "UpdateSubject")]
        [AllowAnonymous]
        public async Task<SubjectModel> UpdateSubject(SubjectModel SubjectModel)
        {
            _logger.LogInformation("Updating subject with Id: {Id}", SubjectModel.Id);
            try
            {
                var result = await _SubjectDetails.UpdateSubject(SubjectModel);
                _logger.LogInformation("Updated subject with Id: {Id}", result?.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating subject with Id: {Id}", SubjectModel.Id);
                throw;
            }
        }

        [HttpPost(Name = "DeleteSubject")]
        [AllowAnonymous]
        public async Task<SubjectModel> DeleteSubject(long Id)
        {
            _logger.LogInformation("Deleting subject with Id: {Id}", Id);
            try
            {
                var result = await _SubjectDetails.DeleteSubject(Id);
                _logger.LogInformation("Deleted subject with Id: {Id}", result?.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting subject with Id: {Id}", Id);
                throw;
            }
        }

    }
}
