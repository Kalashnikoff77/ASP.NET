using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task CreateAsync<TRequest>(TRequest request) where TRequest : class;

        Task EditAsync<TRequest>(Guid id, TRequest request) where TRequest : class;

        Task DeleteAsync(Guid id);
    }
}