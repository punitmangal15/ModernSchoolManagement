using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public interface IConnectionFactory : IDisposable
    {
        IDbTransaction  Transaction { get; }
        IDbConnection GetConnection(string connectionString);
    }
}
