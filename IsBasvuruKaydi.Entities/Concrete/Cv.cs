using IsBasvuruKaydi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Entities.Concrete
{
    public class Cv : Loggable, IEntity
    {
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string Fotograf { get; set; }
        public string Hobiler { get; set; }
        public string Referanslar { get; set; }
        public string Deneyimler { get; set; }
        public bool Goruntuleme { get; set; }

        public Cv()
        {
            Goruntuleme = false;
        }
    }
}
