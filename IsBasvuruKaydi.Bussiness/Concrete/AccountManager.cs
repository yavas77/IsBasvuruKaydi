using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.Entities.Concrete;
using IsBasvuruKaydi.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _loginManager;
        private readonly RoleManager<Role> _roleManager;

        public AccountManager(UserManager<User> userManager, SignInManager<User> loginManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                PasswordHash = registerDto.Password
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            return result;
        }

        public async Task<SignInResult> SignInAsync(SignInDto signInDto)
        {
            var user = await _userManager.FindByNameAsync(signInDto.Email);

            var result = await _loginManager.PasswordSignInAsync(signInDto.Email, signInDto.Password, false, false);
            return result;
        }

        public int UserCount()
        {
            var user =  _userManager.Users.ToList();
            return user.Count();
        }
    }
}
