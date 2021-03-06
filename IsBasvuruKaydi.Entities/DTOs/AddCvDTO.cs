using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Entities.DTOs
{
    public class AddCvDTO
    {
        [Display(Name = "Ad Soyad :")]
        public string AdSoyad { get; set; }
        [Display(Name = "Telefon :")]
        public string Telefon { get; set; }
        [Display(Name = "Mail Adres :")]
        public string Mail { get; set; }
        [Display(Name = "Adres :")]
        public string Adres { get; set; }
        [Display(Name = "Fotoğraf :")]
        public string Fotograf { get; set; }
        [Display(Name = "Hobileriniz :")]
        public string Hobiler { get; set; }
        [Display(Name = "Referanslarınız :")]
        public string Referanslar { get; set; }
        [Display(Name = "Deneyimleriniz :")]
        public string Deneyimler { get; set; }
    }
}
