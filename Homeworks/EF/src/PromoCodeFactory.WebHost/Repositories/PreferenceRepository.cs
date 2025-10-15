using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Repositories;

public class PreferenceRepository(OtusContext _context) : IRepository<Preference>
{
    public async Task<IEnumerable<Preference>> GetAllAsync()
    {
        var customers = await _context.Preferences.ToListAsync();
        return customers;
    }

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

    public Task<Preference> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
