using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbTransaction transaction = null;
        private bool disposedVal = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposedVal)
            {
                if (disposing)
                { }
                disposedVal = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }

        public IDbTransaction Transaction
        {
            get {
                return transaction;
            }
        }
        public IDbConnection GetConnection(string connectionString)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
