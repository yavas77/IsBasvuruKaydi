using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.DataAccess.Abstract;
using IsBasvuruKaydi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.Concrete
{
    public class CvManager : BaseManager<Cv>, ICvService
    {
        private readonly IBaseDal<Cv> _baseDal;
        private readonly ICvDal _cvDal;

        public CvManager(IBaseDal<Cv> baseDal, ICvDal cvDal) : base(baseDal)
        {
            _baseDal = baseDal;
            _cvDal = cvDal;
        }

        public Task<List<Cv>> GetAllActiveAsync()
        {
            return _cvDal.GetAllAsync(x => x.IsActive == true);
        }
    }
}
