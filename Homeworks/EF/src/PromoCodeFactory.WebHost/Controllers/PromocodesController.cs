using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController(IRepository<PromoCode> _repoPromo, IRepository<Customer> _repoCustomer, IRepository<Employee> _repoEmpolyee, IRepository<Preference> _repoPreference) : ControllerBase
    {
        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            //TODO: Получить все промокоды 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            // Метод должен сохранять новый промокод в базе данных
            // и находить клиентов с переданным предпочтением и добавлять им данный промокод. 

            //var employee = (await _repoEmpolyee.GetAllAsync())
            //    .Where(x => x.FirstName == request.PartnerName)
            //    .FirstOrDefault() ?? throw new Exception("Employee не найден!");

            //var preference = (await _repoPreference.GetAllAsync())
            //    .Where(x => x.Name == request.Preference)
            //    .FirstOrDefault() ?? throw new Exception("Предпочтение не найдено!");

            //var newPromoCode = new CreateOrEditPromoCodeRequest
            //{
            //    BeginDate = DateTime.Now,
            //    Code = request.PromoCode,
            //    EndDate = DateTime.Now.AddDays(30),
            //    PartnerManager = employee,
            //    PartnerName = request.PartnerName,
            //    Preference = preference,
            //    ServiceInfo = request.ServiceInfo,
            //};
            //await _repoPromo.CreateAsync(request);

            //var customers = (await _repoCustomer.GetAllAsync())
            //    .Where(x => x.Preferences == preference);

            //foreach (var customer in customers)
            //{
            //    customer.PromoCode = newPromoCode;
            //    _repoCustomer.EditAsync(customer.Id);
            //}

            //TODO: Создать промокод и выдать его клиентам с указанным предпочтением
            throw new NotImplementedException();
        }
    }
}