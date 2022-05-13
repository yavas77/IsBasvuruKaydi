using IsBasvuruKaydi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.Abstract
{
    public interface ICvService : IBaseService<Cv>
    {
        Task<List<Cv>> GetAllActiveAsync();
    }
}
