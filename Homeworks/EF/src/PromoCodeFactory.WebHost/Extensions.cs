using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.WebHost.Context;
using System;

namespace PromoCodeFactory.WebHost;

public static class Extensions
{
    public async static void InitializeDb(this IApplicationBuilder app, IServiceProvider provider)
    {
        var context = provider.GetService<OtusContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var fakedPreferences = FakeDataFactory.Preferences;
        foreach (var data in fakedPreferences)
            await context.Preferences.AddAsync(data);
        await context.SaveChangesAsync();

        var fakedEmployees = FakeDataFactory.Employees;
        foreach (var data in fakedEmployees)
            await context.Empolyees.AddAsync(data);
        await context.SaveChangesAsync();

        var fakedCustomers = FakeDataFactory.Customers;
        foreach (var data in fakedCustomers)
            await context.Customers.AddAsync(data);
        await context.SaveChangesAsync();
    }
}
