using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IBaseRepository<T>
    {
        Task<T> GetById(Guid Id);
        Task<T> Create(T entity);
        Task<IEnumerable<T>> ListAll();
        Task<IEnumerable<T>> ListPaginated(int pageSize, int page);
        Task<int> Count();
        Task<bool> Update(T entity);
        Task<bool> Update(T entity, Guid updatedBy, string? LastUpdatedByName, string? LastUpdatedByEmail);
        Task<bool> Update(T entity, Guid updatedBy);
        Task<bool> Delete(T entity);
        Task<bool> Delete(T entity, Guid updatedBy);
        Task<bool> Delete(T entity, Guid updatedBy, string? LastUpdatedByName, string? LastUpdatedByEmail);
    }
}
