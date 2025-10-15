using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PreferencesController(IRepository<Preference> _repo) 
{
    /// <summary>
    /// Получить список всех предпочтений
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<PreferencesResponse>> GetAllAsync()
    {
        var result = await _repo.GetAllAsync();

        var preferences = result
            .Select(x =>
                new PreferencesResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                });

        return preferences;
    }
}
