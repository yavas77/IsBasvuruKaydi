using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.Entities.DTOs;
using IsBasvuruKaydi.MvcHelpers.Enum;
using IsBasvuruKaydi.MvcHelpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            if (!ModelState.IsValid)
                return View(registerDto);

            var result = await _accountService.RegisterAsync(registerDto);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin").ShowMessage(Status.Ok, "Başarılı", "Kullanıcı başarıyla oluşturuldu.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }


            return View(registerDto);
        }

        public IActionResult Login()
        {
            if (_accountService.UserCount() == 0)
                return RedirectToAction("Register").ShowMessage(Status.Error, "Uyarı!", "Kayıtlı kullanıcı bulunamadı! Devam edebilmek için kullanıcı ekleyiniz."); ;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInDto signInDto)
        {
            if (!ModelState.IsValid)
                return View(signInDto);

            var identityResult = await _accountService.SignInAsync(signInDto);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!"); return View(signInDto);
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
