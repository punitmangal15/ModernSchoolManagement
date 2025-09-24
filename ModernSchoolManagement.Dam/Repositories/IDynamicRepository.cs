using Dapper;
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

        Task<T> Get<T>(string sp, DynamicParameters? parameters, CommandType commandType);
        T Add<T>(string sp, DynamicParameters? parameters,CommandType commandType);

        T Update<T>(string sp, DynamicParameters? parameters, CommandType commandType);
        T Delete<T>(string sp, DynamicParameters? parameters, CommandType commandType);

        T DeleteAll<T>(string sp, DynamicParameters? parameters, CommandType commandType);
    }
}
