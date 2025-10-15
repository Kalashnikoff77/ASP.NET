using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers;

/// <summary>
/// Клиенты
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController(IRepository<Customer> _repo) : ControllerBase
{
    /// <summary>
    /// Получить список всех клиентов
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<CustomerShortResponse>> GetCustomersAsync()
    {
        var result = await _repo.GetAllAsync();

        var customersModelList = result
            .Select(x =>
                new CustomerShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName
                });

        return customersModelList;
    }

    /// <summary>
    /// Получить одного клиента по Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<CustomerResponse> GetCustomerAsync(Guid id)
    {
        var result = await _repo.GetByIdAsync(id);

        var customer = new CustomerResponse();

        if (result != null)
        {
            customer = new CustomerResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                Email = result.Email,
                LastName = result.LastName,
            };
        }
        return customer;
    }

    /// <summary>
    /// Добвавить нового клиента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
    {
        await _repo.CreateAsync(request);
        return Ok();
    }

    /// <summary>
    /// Редактирование клиента
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> EditCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
    {
        await _repo.EditAsync(id, request);
        return Ok();
    }

    /// <summary>
    /// Удаление клиента
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        await _repo.DeleteAsync(id);
        return Ok();
    }
}