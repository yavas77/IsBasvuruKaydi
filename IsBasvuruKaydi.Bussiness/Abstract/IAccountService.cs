using IsBasvuruKaydi.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.Abstract
{
    public interface IAccountService
    {
        Task<SignInResult> SignInAsync(SignInDto signInDto);
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        int UserCount();
    }
}
