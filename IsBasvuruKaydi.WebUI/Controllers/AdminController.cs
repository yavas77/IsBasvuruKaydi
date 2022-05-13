using AutoMapper;
using IsBasvuruKaydi.Bussiness.Abstract;
using IsBasvuruKaydi.Entities.DTOs;
using IsBasvuruKaydi.MvcHelpers.Enum;
using IsBasvuruKaydi.MvcHelpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICvService _cvService;
        private readonly IMapper _mapper;

        public AdminController(ICvService cvService, IMapper mapper)
        {
            _cvService = cvService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cvList = _mapper.Map<List<ListCvDTO>>(await _cvService.GetAllActiveAsync());

            return View(cvList);
        }

        [HttpPost]
        public async Task<JsonResult> CvDelete(CvDeleteDTO cvDeleteDTO)
        {
            if (cvDeleteDTO == null)
            {
                return Json(new JResult
                {
                    Status = Status.BadRequest,
                    Message = "Silinmek istenen kişi bulunamadı!"
                });
            }

            if (await _cvService.FindByIdAsync(cvDeleteDTO.Id) == null)
            {
                return Json(new JResult
                {
                    Status = Status.NotFound,
                    Message = "Silinmek istenen kişi bulunamadı!"
                });
            }

            var category = await _cvService.FindByIdAsync(cvDeleteDTO.Id);
            category.IsActive = false;

            await _cvService.UpdateAsync(category);


            return Json(new JResult
            {
                Status = Status.Ok,
                Message = "Kişi başarıyla silindi."
            });





        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id.Value == 0)
            {
                return RedirectToAction("Index").ShowMessage(Status.Error, "Hata!", "Hatalı istekte bulundunuz!");
            }
            var cv = _mapper.Map<ListCvDTO>(await _cvService.FindByIdAsync(id.Value));

            return View(cv);
        }
    }
}
