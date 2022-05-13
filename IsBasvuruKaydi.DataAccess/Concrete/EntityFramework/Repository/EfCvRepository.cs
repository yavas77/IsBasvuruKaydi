using IsBasvuruKaydi.DataAccess.Abstract;
using IsBasvuruKaydi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCvRepository : EfBaseRepository<Cv>, ICvDal
    {

    }
}
