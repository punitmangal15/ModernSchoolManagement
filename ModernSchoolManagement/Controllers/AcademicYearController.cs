using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System.Text.Json.Serialization;

namespace ModernAcademicYearManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class AcademicYearController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<AcademicYearController> _logger;
        private readonly IAcademicYearModel _academicYearDetails;
        public AcademicYearController(IAuthentication authentication, ILogger<AcademicYearController> logger, IAcademicYearModel academicYearModel)
        {
            _authentication = authentication;
            _logger = logger;
            _academicYearDetails = academicYearModel;

        }
       
        [HttpGet(Name = "GetAllAcademicYearDetails")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAcademicYearDetails()
        {
            _logger.LogInformation("Fetching all academic year details started.");

            try
            {
                var academicYears = await _academicYearDetails.GetAllAcademicYearDetails();
                _logger.LogInformation("Successfully fetched {Count} academic year records.", academicYears?.Count() ?? 0);
                return Ok(academicYears);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching academic year details.");
                return StatusCode(500, "An error occurred while retrieving academic year details.");
            }
        }

        [HttpGet(Name = "GetAcademicYearDetail")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAcademicYearDetail(long Id)
        {
            _logger.LogInformation("Fetching academic year detail for Id: {Id} started.", Id);

            try
            {
                var academicYear = await _academicYearDetails.GetAcademicYearDetail(Id);
                if (academicYear == null)
                {
                    _logger.LogWarning("Academic year with Id: {Id} not found.", Id);
                    return NotFound($"Academic year with Id {Id} not found.");
                }
                _logger.LogInformation("Successfully fetched academic year detail for Id: {Id}.", Id);
                return Ok(academicYear);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching academic year detail for Id: {Id}.", Id);
                return StatusCode(500, "An error occurred while retrieving academic year detail.");
            }
        }

        [HttpPost(Name = "AddAcademicYear")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAcademicYear(AcademicYearModel AcademicYearModel)
        {
            _logger.LogInformation("Adding new academic year started.");

            try
            {
                var result = await _academicYearDetails.AddAcademicYear(AcademicYearModel);
                _logger.LogInformation("Successfully added academic year with Id: {Id}.", result?.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding academic year.");
                return StatusCode(500, "An error occurred while adding academic year.");
            }
        }

        [HttpPost(Name = "UpdateAcademicYear")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAcademicYear(AcademicYearModel AcademicYearModel)
        {
            _logger.LogInformation("Updating academic year with Id: {Id} started.", AcademicYearModel.Id);

            try
            {
                var result = await _academicYearDetails.UpdateAcademicYear(AcademicYearModel);
                if (result == null)
                {
                    _logger.LogWarning("Academic year with Id: {Id} not found for update.", AcademicYearModel.Id);
                    return NotFound($"Academic year with Id {AcademicYearModel.Id} not found.");
                }
                _logger.LogInformation("Successfully updated academic year with Id: {Id}.", AcademicYearModel.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating academic year with Id: {Id}.", AcademicYearModel.Id);
                return StatusCode(500, "An error occurred while updating academic year.");
            }
        }

        [HttpPost(Name = "DeleteAcademicYear")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAcademicYear(long Id)
        {
            _logger.LogInformation("Deleting academic year with Id: {Id} started.", Id);

            try
            {
                var result = await _academicYearDetails.DeleteAcademicYear(Id);
                if (result == null)
                {
                    _logger.LogWarning("Academic year with Id: {Id} not found for deletion.", Id);
                    return NotFound($"Academic year with Id {Id} not found.");
                }
                _logger.LogInformation("Successfully deleted academic year with Id: {Id}.", Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting academic year with Id: {Id}.", Id);
                return StatusCode(500, "An error occurred while deleting academic year.");
            }
        }
    }
}
