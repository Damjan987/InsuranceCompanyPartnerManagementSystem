using BusinessPartnerManagementSystem.WebUI.Dapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDapperContext _context;

        public GenericRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task Add(string tableName, T entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var _EntityTypeOf = typeof(T);
                var _GetProperties = _EntityTypeOf.GetProperties().Where(x => x.Name != "Id");
                DynamicParameters _DynamicParameters = new DynamicParameters();

                foreach (var property in _GetProperties)
                {
                    var value = property.GetValue(entity);
                    _DynamicParameters.Add("@" + property.Name, value);
                }

                var idProperty = _EntityTypeOf.GetProperty("Id");
                if (idProperty != null)
                {
                    string insertQuery = $"INSERT INTO {tableName} ({string.Join(", ", _GetProperties.Select(p => p.Name))}) "
                                         + $"VALUES ({string.Join(", ", _GetProperties.Select(p => "@" + p.Name))})";
                    await connection.ExecuteAsync(insertQuery, _DynamicParameters);
                } else
                {
                    throw new ArgumentException("Entity must have an 'Id' property.");
                }
            }
        }

        public async Task AddToSharedTable(string tableName, object entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var _EntityTypeOf = typeof(T);
                var _GetProperties = _EntityTypeOf.GetProperties();
                DynamicParameters _DynamicParameters = new DynamicParameters();

                foreach (var property in _GetProperties)
                {
                    var value = property.GetValue(entity);
                    _DynamicParameters.Add("@" + property.Name, value);
                }

                string insertQuery = $"INSERT INTO {tableName} ({string.Join(", ", _GetProperties.Select(p => p.Name))}) "
                                        + $"VALUES ({string.Join(", ", _GetProperties.Select(p => "@" + p.Name))})";
                await connection.ExecuteAsync(insertQuery, _DynamicParameters);
            }
        }

        public async Task Delete(string tableName, string id)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = $"DELETE FROM {tableName} WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<T>> GetAll(string tableName)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = $"SELECT * FROM {tableName} order by CreatedAt desc";
                return await connection.QueryAsync<T>(query);
            }
        }

        public async Task<T> GetById(string tableName, string id)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = $"SELECT * FROM {tableName} WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
            }
        }

        public async Task Update(string tableName, T entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var _EntityTypeOf = typeof(T);
                var _GetProperties = _EntityTypeOf.GetProperties();
                DynamicParameters _DynamicParameters = new DynamicParameters();

                foreach (var property in _GetProperties)
                {
                    var value = property.GetValue(entity);
                    _DynamicParameters.Add("@" + property.Name, value);
                }

                var idProperty = _EntityTypeOf.GetProperty("Id");
                if (idProperty != null)
                {
                    string updateQuery = $"UPDATE {tableName} SET {string.Join(", ", _GetProperties.Where(p => p.Name != "Id").Select(p => p.Name + " = @" + p.Name))} " + $"WHERE Id = @Id";
                    await connection.ExecuteAsync(updateQuery, _DynamicParameters);
                } else
                {
                    throw new ArgumentException("Entity must have an 'Id' property.");
                }
            }
        }
    }
}