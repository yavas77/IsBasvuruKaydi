using AutoMapper;
using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.Entities.Concrete;
using IsBasvuruKaydi.Entities.DTOs;
using IsBasvuruKaydi.MvcHelpers.Enum;
using IsBasvuruKaydi.MvcHelpers.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.WebUI.Controllers
{
    public class BasvuruController : Controller
    {
        private readonly ICvService _cvService;
        private readonly IMapper _mapper;

        public BasvuruController(ICvService cvService, IMapper mapper)
        {
            _cvService = cvService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(AddCvDTO addCvDTO, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(addCvDTO).ShowMessage(Status.Error, "Hata", "Eksik veya hatalı bilgiler mevcut!");
            }

            //Resim ekleme ekleme işlemleri
            #region Resim İşlemleri
            if (file == null)
            {
                return View().ShowMessage(Status.Error, "Hata", "Lütfen resim seçiniz!");
            }

            string imageExtension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid() + imageExtension;

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{imageName}");

            using var stream = new FileStream(path, FileMode.Create);


            await file.CopyToAsync(stream);


            addCvDTO.Fotograf = imageName; 
            #endregion

            var basvuru = _mapper.Map<Cv>(addCvDTO);

            await _cvService.AddAsync(basvuru);
            return RedirectToAction("Ekle").ShowMessage(Status.Ok, "Başarılı", "Başvurunuz başarıyla alındı. En kısa süre içinde dönüş yapılacaktır.");
        }
    }
}
