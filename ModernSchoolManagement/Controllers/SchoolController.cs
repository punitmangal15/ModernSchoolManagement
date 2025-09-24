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
            return await _schoolDetails.GetAllSchoolDetails();
            //return Ok(users);
        }

        [HttpGet(Name = "GetSchoolDetail")]
        [AllowAnonymous]
        public Task<SchoolModel> GetSchoolDetail(long Id)
        {
            return _schoolDetails.GetSchoolDetail(Id);
            //return Ok(users);
        }

        [HttpPost(Name = "AddSchool")]
        [AllowAnonymous]
        public Task<SchoolModel> AddSchool(SchoolModel schoolModel)
        {
            return _schoolDetails.AddSchool(schoolModel);
            //return Ok(users);
        }

        [HttpPost(Name = "UpdateSchool")]
        [AllowAnonymous]
        public Task<SchoolModel> UpdateSchool(SchoolModel schoolModel)
        {
            return _schoolDetails.UpdateSchool(schoolModel);
            //return Ok(users);
        }

        [HttpPost(Name = "DeleteSchool")]
        [AllowAnonymous]
        public Task<SchoolModel> DeleteSchool(long Id)
        {
            return _schoolDetails.DeleteSchool(Id);
            //return Ok(users);
        }
    }
}
