using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

namespace ModernClassManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class ClassController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<ClassController> _logger;
        private readonly IClassModel _classDetails;
        public ClassController(IAuthentication authentication, ILogger<ClassController> logger, IClassModel classModel)
        {
            _authentication = authentication;
            _logger = logger;
            _classDetails = classModel;

        }
       
        [HttpGet(Name = "GetAllClassDetails")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllClassDetails()
        {
            _logger.LogInformation("Fetching all class details started.");

            try
            {
                var classes = await _classDetails.GetAllClassDetails();
                _logger.LogInformation("Successfully fetched {Count} class records.", classes?.Count() ?? 0);
                return Ok(classes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching class details.");
                return StatusCode(500, "An error occurred while retrieving class details.");
            }
        }

        [HttpGet(Name = "GetClassDetail")]
        [AllowAnonymous]
        public async Task<IActionResult> GetClassDetail(long Id)
        {
            _logger.LogInformation("Fetching class detail for Id: {Id} started.", Id);

            try
            {
                var classDetail = await _classDetails.GetClassDetail(Id);
                if (classDetail == null)
                {
                    _logger.LogWarning("Class with Id: {Id} not found.", Id);
                    return NotFound($"Class with Id {Id} not found.");
                }
                _logger.LogInformation("Successfully fetched class detail for Id: {Id}.", Id);
                return Ok(classDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching class detail for Id: {Id}.", Id);
                return StatusCode(500, "An error occurred while retrieving class detail.");
            }
        }

        [HttpPost(Name = "AddClass")]
        [AllowAnonymous]
        public async Task<IActionResult> AddClass(ClassModel classModel)
        {
            _logger.LogInformation("Adding new class started.");

            try
            {
                var result = await _classDetails.AddClass(classModel);
                _logger.LogInformation("Successfully added class with Id: {Id}.", result?.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding class.");
                return StatusCode(500, "An error occurred while adding class.");
            }
        }

        [HttpPost(Name = "UpdateClass")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateClass(ClassModel classModel)
        {
            _logger.LogInformation("Updating class with Id: {Id} started.", classModel.Id);

            try
            {
                var result = await _classDetails.UpdateClass(classModel);
                if (result == null)
                {
                    _logger.LogWarning("Class with Id: {Id} not found for update.", classModel.Id);
                    return NotFound($"Class with Id {classModel.Id} not found.");
                }
                _logger.LogInformation("Successfully updated class with Id: {Id}.", classModel.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating class with Id: {Id}.", classModel.Id);
                return StatusCode(500, "An error occurred while updating class.");
            }
        }

        [HttpPost(Name = "DeleteClass")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteClass(long Id)
        {
            _logger.LogInformation("Deleting class with Id: {Id} started.", Id);

            try
            {
                var result = await _classDetails.DeleteClass(Id);
                if (result == null)
                {
                    _logger.LogWarning("Class with Id: {Id} not found for deletion.", Id);
                    return NotFound($"Class with Id {Id} not found.");
                }
                _logger.LogInformation("Successfully deleted class with Id: {Id}.", Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting class with Id: {Id}.", Id);
                return StatusCode(500, "An error occurred while deleting class.");
            }
        }

    }
}
