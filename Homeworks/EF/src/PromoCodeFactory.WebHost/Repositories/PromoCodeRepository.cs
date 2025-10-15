using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Repositories
{
    public class PromoCodeRepository(OtusContext _context) : IRepository<PromoCode>
    {
        public Task CreateAsync<TRequest>(TRequest request) where TRequest : class
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync<TRequest>(Guid id, TRequest request) where TRequest : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PromoCode>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PromoCode> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
