using Common.Exceptions;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
{
    protected IEnumerable<T> Data { get; set; }

    public InMemoryRepository(IEnumerable<T> data) => Data = data;

    public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult(Data);

    public Task<T> GetByIdAsync(Guid id) => Task.FromResult(Data.FirstOrDefault(x => x.Id == id));

    public async Task<IEnumerable<T>> AddAsync(T employee)
    {
        if (employee == null)
            throw new BadRequestException("Передан пустой параметр!");

        var dataList = Data.ToList();
        dataList.Add(employee);
        return dataList;
    }

    public async Task<IEnumerable<T>> UpdateAsync(T employee)
    {
        if (employee == null)
            throw new BadRequestException("Передан пустой параметр!");

        var dataList = Data.ToList();
        var index = dataList.FindIndex(i => i.Id == employee.Id);
        if (index == -1)
            throw new NotFoundException("Запись в таблице не найдена!");

        dataList[index] = employee;
        return dataList;
    }


    public async Task<IEnumerable<T>> DeleteAsync(Guid id)
    {
        var dataList = Data.ToList();
        var index = dataList.FindIndex(i => i.Id == id);
        if (index == -1)
            throw new NotFoundException("Запись в таблице не найдена!");

        dataList.RemoveAt(index);
        return dataList;
    }
}

