using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Repositories
{
    public class EmployeeRepository(OtusContext _context) : IRepository<Employee>
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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _context.Empolyees.ToListAsync();
            return result;
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
