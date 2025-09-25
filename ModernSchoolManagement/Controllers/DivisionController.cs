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
            return await _divisionDetails.GetAllDivisionDetails();
            //return Ok(users);
        }

        [HttpGet(Name = "GetDivisionDetail")]
        [AllowAnonymous]
        public Task<DivisionModel> GetDivisionDetail(long Id)
        {
            return _divisionDetails.GetDivisionDetail(Id);
            //return Ok(users);
        }

        [HttpPost(Name = "AddDivision")]
        [AllowAnonymous]
        public Task<DivisionModel> AddDivision(DivisionModel DivisionModel)
        {
            return _divisionDetails.AddDivision(DivisionModel);
            //return Ok(users);
        }

        [HttpPost(Name = "UpdateDivision")]
        [AllowAnonymous]
        public Task<DivisionModel> UpdateDivision(DivisionModel DivisionModel)
        {
            return _divisionDetails.UpdateDivision(DivisionModel);
            //return Ok(users);
        }

        [HttpPost(Name = "DeleteDivision")]
        [AllowAnonymous]
        public Task<DivisionModel> DeleteDivision(long Id)
        {
            return _divisionDetails.DeleteDivision(Id);
            //return Ok(users);
        }
    }
}
