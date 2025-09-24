using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernSchoolManagement.Dam.Repositories
{
    public class DynamicRepository : IDynamicRepository
    {
        private IConnectionFactory connectionFactory;
        private readonly string connectionString;
        public DynamicRepository(IConnectionFactory connectionFactory, IConfiguration connection)
        {
            this.connectionFactory = connectionFactory;
            connectionString = connection.GetConnectionString("SqlConnection").ToString().Trim();

        }

        
        public async Task<IEnumerable<T>> GetAll<T>(string query, CommandType commandType)
        {
            using (IDbConnection connection = connectionFactory.GetConnection(connectionString))
            {
                return  connection.QueryAsync<T>(query, commandType).Result;
            }
        }

        public async Task<T> Get<T>(string sp,DynamicParameters? parameters, CommandType commandType)
        {
            using (IDbConnection connection = connectionFactory.GetConnection(connectionString))
            {
                return connection.QueryAsync<T>(sp, parameters, null, null, commandType).Result.FirstOrDefault();
            }
        }

        public T Add<T>(string sp, DynamicParameters? parameters, CommandType commandType)
        {
            using (IDbConnection connection = connectionFactory.GetConnection(connectionString))
            {
                return connection.QueryAsync<T>(sp, parameters, null, null, commandType).Result.FirstOrDefault();
            }
        }
        

        public T Update<T>(string sp, DynamicParameters? parameters, CommandType commandType)
        {
            using (IDbConnection connection = connectionFactory.GetConnection(connectionString))
            {
                return connection.QueryAsync<T>(sp, parameters, null, null, commandType).Result.FirstOrDefault();
            }
        }

        public T Delete<T>(string sp, DynamicParameters? parameters, CommandType commandType)
        {
            using (IDbConnection connection = connectionFactory.GetConnection(connectionString))
            {
                return connection.QueryAsync<T>(sp, parameters, null, null, commandType).Result.FirstOrDefault();
            }
        }

        public T DeleteAll<T>(string sp, DynamicParameters? parameters, CommandType commandType)
        {
            throw new NotImplementedException();
        }
    }
}
