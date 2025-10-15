using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.WebHost.Context;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Repositories;

public class CustomerRepository(OtusContext _context) : IRepository<Customer>
{
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = await _context.Customers
            .Select(x =>
                new Customer()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName
                }).ToListAsync();

        return customers;
    }

    public async Task<Customer> GetByIdAsync(Guid id)
    {
        var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        var customer = new Customer();

        if (result != null)
        {
            customer = new Customer
            {
                Id = result.Id,
                FirstName = result.FirstName,
                Email = result.Email,
                LastName = result.LastName,
            };
        }
        return customer;
    }

    public async Task CreateAsync<TRequest>(TRequest request) where TRequest : class
    {
        var req = request as CreateOrEditCustomerRequest;

        var preferences = await _context.Preferences
            .Where(x => req.PreferenceIds.Contains(x.Id))
            .ToListAsync();

        var customer = new Customer
        {
            Email = req.Email,
            FirstName = req.FirstName,
            LastName = req.LastName,
            Id = Guid.NewGuid(),
            Preferences = preferences
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync<TRequest>(Guid id, TRequest request) where TRequest : class
    {
        var req = request as CreateOrEditCustomerRequest;

        var preferences = FakeDataFactory.Preferences
            .Where(x => req.PreferenceIds.Contains(x.Id))
            .ToList();

        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        customer.Email = req.Email;
        customer.FirstName = req.FirstName;
        customer.LastName = req.LastName;
        customer.Preferences = preferences;

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customer != null)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }


}
