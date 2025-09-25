using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModernSchoolManagement.Authentication;
using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;

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
        public async Task<IEnumerable<AcademicYearModel>> GetAllAcademicYearDetails()
        {
            return await _academicYearDetails.GetAllAcademicYearDetails();
            //return Ok(users);
        }

        [HttpGet(Name = "GetAcademicYearDetail")]
        [AllowAnonymous]
        public Task<AcademicYearModel> GetAcademicYearDetail(long Id)
        {
            return _academicYearDetails.GetAcademicYearDetail(Id);
            //return Ok(users);
        }

        [HttpPost(Name = "AddAcademicYear")]
        [AllowAnonymous]
        public Task<AcademicYearModel> AddAcademicYear(AcademicYearModel AcademicYearModel)
        {
            return _academicYearDetails.AddAcademicYear(AcademicYearModel);
            //return Ok(users);
        }

        [HttpPost(Name = "UpdateAcademicYear")]
        [AllowAnonymous]
        public Task<AcademicYearModel> UpdateAcademicYear(AcademicYearModel AcademicYearModel)
        {
            return _academicYearDetails.UpdateAcademicYear(AcademicYearModel);
            //return Ok(users);
        }

        [HttpPost(Name = "DeleteAcademicYear")]
        [AllowAnonymous]
        public Task<AcademicYearModel> DeleteAcademicYear(long Id)
        {
            return _academicYearDetails.DeleteAcademicYear(Id);
            //return Ok(users);
        }
    }
}
