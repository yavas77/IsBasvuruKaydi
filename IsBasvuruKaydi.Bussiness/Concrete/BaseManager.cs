using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.DataAccess.Abstract;
using IsBasvuruKaydi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.Concrete
{
    public class BaseManager<TEntity> : IBaseService<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly IBaseDal<TEntity> _baseDal;

        public BaseManager(IBaseDal<TEntity> baseDal)
        {
            _baseDal = baseDal;
        }

        #region Add
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _baseDal.AddAsync(entity);
            return entity;
        }
        #endregion

        #region Select

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _baseDal.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _baseDal.GetAllAsync();
        }
        #endregion

        #region Delete
        public async Task RemoveAsync(TEntity entity)
        {
            await _baseDal.DeleteAsync(entity);
        }
        #endregion

        #region Update
        public async Task UpdateAsync(TEntity entity)
        {
            await _baseDal.UpdateAsync(entity);
        } 
        #endregion
    }
}
