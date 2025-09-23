using ModernSchoolManagement.Dam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IUserModel
    {
        Task<IEnumerable<UserModel>> GetUserDetails();
    }
}
