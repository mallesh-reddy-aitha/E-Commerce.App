using E_Commerce.App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.App.Repository.Base
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        void Add(T entity);

        Task<int> CountAsync(ISpecification<T> specification);

        bool Exist(long id);

        Task<T> GetByIdAsync(long id);

        Task<T> GetEntityWithSpecification(ISpecification<T> specification);

        Task<TResult> GetEntityWithSpecification<TResult>(ISpecification<T, TResult> specification);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification);

        void Remove(T entity);

        Task<bool> SaveAllAsync();

        void Update(T entity);
    }
}
