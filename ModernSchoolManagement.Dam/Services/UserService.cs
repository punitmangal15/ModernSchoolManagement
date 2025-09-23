using ModernSchoolManagement.Dam.Models;
using ModernSchoolManagement.Dam.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Services
{
    public class UserService : IUserModel
    {
        private readonly IDynamicRepository dynamicRepository;

        public UserService(IDynamicRepository dynamicRepository)
        {
            this.dynamicRepository = dynamicRepository;
        }

        public async Task<IEnumerable<UserModel>> GetUserDetails()
        {
            string query = "select Username,Password_hash as Password from  SC_users";
            try
            {
                return await dynamicRepository.GetAll<UserModel>(query,CommandType.Text);
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
