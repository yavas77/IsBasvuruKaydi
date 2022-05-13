using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Entities.DTOs
{
    public class SignInDto
    {
        [Display(Name = "Kullanıcı Adı ")]
        public string Email { get; set; }

        [Display(Name = "Şifre ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
