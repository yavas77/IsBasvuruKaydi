using IsBasvuruKaydi.DataAccess.Abstract;
using IsBasvuruKaydi.DataAccess.Concrete.Contexts;
using IsBasvuruKaydi.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfBaseRepository<TEntity> : IBaseDal<TEntity>
        where TEntity : class, IEntity, new()
    {

        #region Add

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var context = new IsBasvuruKaydiContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new IsBasvuruKaydiContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
        #endregion


        #region Select

        public async Task<TEntity> FindByIdAsync(int id)
        {
            using var context = new IsBasvuruKaydiContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new IsBasvuruKaydiContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new IsBasvuruKaydiContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new IsBasvuruKaydiContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        #endregion

        #region Update
        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new IsBasvuruKaydiContext();
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        } 
        #endregion
    }
}
