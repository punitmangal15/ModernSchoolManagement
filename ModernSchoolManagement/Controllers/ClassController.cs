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
        public async Task<IEnumerable<ClassModel>> GetAllClassDetails()
        {
            return await _classDetails.GetAllClassDetails();
            //return Ok(users);
        }

        [HttpGet(Name = "GetClassDetail")]
        [AllowAnonymous]
        public Task<ClassModel> GetClassDetail(long Id)
        {
            return _classDetails.GetClassDetail(Id);
            //return Ok(users);
        }

        [HttpPost(Name = "AddClass")]
        [AllowAnonymous]
        public Task<ClassModel> AddClass(ClassModel classModel)
        {
            return _classDetails.AddClass(classModel);
            //return Ok(users);
        }

        [HttpPost(Name = "UpdateClass")]
        [AllowAnonymous]
        public Task<ClassModel> UpdateClass(ClassModel classModel)
        {
            return _classDetails.UpdateClass(classModel);
            //return Ok(users);
        }

        [HttpPost(Name = "DeleteClass")]
        [AllowAnonymous]
        public Task<ClassModel> DeleteClass(long Id)
        {
            return _classDetails.DeleteClass(Id);
            //return Ok(users);
        }
    }
}
