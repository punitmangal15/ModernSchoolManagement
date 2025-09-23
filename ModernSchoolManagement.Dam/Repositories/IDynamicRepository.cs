using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IDynamicRepository
    {
        Task<IEnumerable<T>> GetAll<T>(string query,CommandType commandType); 
    }
}
