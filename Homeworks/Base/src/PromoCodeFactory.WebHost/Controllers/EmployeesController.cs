using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController(IRepository<Employee> _employeeRepository) : ControllerBase
    {
        //private readonly IRepository<Employee> _employeeRepository;

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x =>
                new EmployeeShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                }).ToList();

            return Ok(employeesModelList);
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                throw new NotFoundException("Запись не найдена!");

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Roles = employee.Roles.Select(x => new RoleItemResponse()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return Ok(employeeModel);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Employee employee)
        {
            if (employee == null)
                throw new BadRequestException("Передан пустой параметр!");

            // Обновление записи в БД
            var item = await _employeeRepository.GetByIdAsync(employee.Id);
            if (item == null)
                throw new NotFoundException("Запись не найдена!");

            await _employeeRepository.UpdateAsync(employee);

            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> AddAsync(Employee employee)
        {
            // Добавление записи в БД
            var result = await _employeeRepository.AddAsync(employee);
            return Ok(result);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            // Удаление записи из БД
            var result = await _employeeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}