using AutoMapper;
using IsBasvuruKaydi.Entities.Concrete;
using IsBasvuruKaydi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.WebUI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddCvDTO, Cv>().ReverseMap();
            CreateMap<ListCvDTO, Cv>().ReverseMap();
            
        }
    }
}
