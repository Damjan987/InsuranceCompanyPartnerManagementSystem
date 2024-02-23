using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPartnerManagementSystem.WebUI.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string tableName);

        Task<T> GetById(string tableName, string id);

        Task Delete(string tableName, string id);

        Task Add(string tableName, T entity);

        Task AddToSharedTable(string tableName, object entity);

        Task Update(string tableName, T entity);
    }
}
