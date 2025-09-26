using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

namespace ModernDivisionManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class DivisionController : Controller
    {

        private readonly IAuthentication _authentication;
        private readonly ILogger<DivisionController> _logger;
        private readonly IDivisionModel _divisionDetails;
        public DivisionController(IAuthentication authentication, ILogger<DivisionController> logger, IDivisionModel divisionModel)
        {
            _authentication = authentication;
            _logger = logger;
            _divisionDetails = divisionModel;

        }
        [HttpGet(Name = "GetAllDivisionDetails")]
        [AllowAnonymous]
        public async Task<IEnumerable<DivisionModel>> GetAllDivisionDetails()
        {
            _logger.LogInformation("Fetching all division details.");
            try
            {
                var divisions = await _divisionDetails.GetAllDivisionDetails();
                _logger.LogInformation("Fetched {Count} divisions.", divisions?.Count() ?? 0);
                return divisions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all division details.");
                throw;
            }
        }

        [HttpGet(Name = "GetDivisionDetail")]
        [AllowAnonymous]
        public async Task<DivisionModel> GetDivisionDetail(long Id)
        {
            _logger.LogInformation("Fetching division detail for Id: {Id}", Id);
            try
            {
                var division = await _divisionDetails.GetDivisionDetail(Id);
                if (division == null)
                {
                    _logger.LogWarning("Division with Id: {Id} not found.", Id);
                }
                else
                {
                    _logger.LogInformation("Fetched division detail for Id: {Id}", Id);
                }
                return division;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching division detail for Id: {Id}", Id);
                throw;
            }
        }

        [HttpPost(Name = "AddDivision")]
        [AllowAnonymous]
        public async Task<DivisionModel> AddDivision(DivisionModel DivisionModel)
        {
            _logger.LogInformation("Adding new division: {Name}", DivisionModel.Name);
            try
            {
                var result = await _divisionDetails.AddDivision(DivisionModel);
                _logger.LogInformation("Added division with Id: {Id}", result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding division: {Name}", DivisionModel.Name);
                throw;
            }
        }

        [HttpPost(Name = "UpdateDivision")]
        [AllowAnonymous]
        public async Task<DivisionModel> UpdateDivision(DivisionModel DivisionModel)
        {
            _logger.LogInformation("Updating division with Id: {Id}", DivisionModel.Id);
            try
            {
                var result = await _divisionDetails.UpdateDivision(DivisionModel);
                _logger.LogInformation("Updated division with Id: {Id}", result.Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating division with Id: {Id}", DivisionModel.Id);
                throw;
            }
        }

        [HttpPost(Name = "DeleteDivision")]
        [AllowAnonymous]
        public async Task<DivisionModel> DeleteDivision(long Id)
        {
            _logger.LogInformation("Deleting division with Id: {Id}", Id);
            try
            {
                var result = await _divisionDetails.DeleteDivision(Id);
                _logger.LogInformation("Deleted division with Id: {Id}", Id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting division with Id: {Id}", Id);
                throw;
            }
        }

    }
}
