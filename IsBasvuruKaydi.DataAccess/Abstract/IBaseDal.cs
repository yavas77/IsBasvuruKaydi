using IsBasvuruKaydi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.DataAccess.Abstract
{
    public interface IBaseDal<TEntity>
        where TEntity : class, IEntity, new()
    {

        #region Select
        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindByIdAsync(int id);
        #endregion


        #region Add
        Task<TEntity> AddAsync(TEntity entity);
        #endregion

        #region Update
        Task UpdateAsync(TEntity entity);
        #endregion

        #region Delete
        Task DeleteAsync(TEntity entity); 
        #endregion

    }
}
