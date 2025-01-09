using E_Commerce.App.Core.Entities;
using E_Commerce.App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.App.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly StoreDbContext storeDbContext;

        public GenericRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public void Add(T entity)
        {
            entity.CreatedBy = entity.ModifiedBy = Guid.NewGuid();

            entity.CreatedOn = entity.ModifiedOn = DateTime.UtcNow;

            this.storeDbContext.Set<T>().Add(entity);
        }

        public bool Exist(long id)
        {
            return this.storeDbContext.Set<T>().Any(x => x.Id == id);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await this.storeDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<TResult> GetEntityWithSpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this.storeDbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public void Remove(T entity)
        {
            this.storeDbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.storeDbContext.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;

            this.storeDbContext.Set<T>().Attach(entity);

            this.storeDbContext.Entry(entity).State = EntityState.Modified;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(this.storeDbContext.Set<T>().AsQueryable(), specification);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return SpecificationEvaluator<T>.GetQuery<T, TResult>(this.storeDbContext.Set<T>().AsQueryable(), specification);
        }
    }
}
