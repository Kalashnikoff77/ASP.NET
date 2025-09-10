using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>: IRepository<T> where T: BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }


        public async Task<IEnumerable<T>> AddAsync(T employee)
        {
            var dataList = Data.ToList();
            dataList.Add(employee);

            return dataList;
        }


        public async Task<IEnumerable<T>> DeleteAsync(Guid id)
        {
            var dataList = Data.ToList();
            var index = dataList.FindIndex(i => i.Id == id);
            dataList.RemoveAt(index);
            return dataList;
        }
    }
}

