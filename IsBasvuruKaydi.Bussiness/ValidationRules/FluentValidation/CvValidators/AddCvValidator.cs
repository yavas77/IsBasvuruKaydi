using FluentValidation;
using IsBasvuruKaydi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.ValidationRules.FluentValidation.CvValidators
{
    public class AddCvValidator : AbstractValidator<AddCvDTO>
    {
        public AddCvValidator()
        {
          
            RuleFor(x => x.AdSoyad)
                .NotEmpty()
                .WithMessage("Ad alanı boş geçilemez!");

            RuleFor(x => x.Mail)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez!")
                .MaximumLength(150)
                .WithMessage("Email en fazla 150 karakter olabilir!")
                .Must(p => p != null && Regex.IsMatch(p, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                .WithMessage("Eposta uygun biçimde girilmemiş!");

            RuleFor(p => p.Telefon)
                .NotEmpty()
                .WithMessage("Telefon boş bırakılamaz!")
                .MaximumLength(10)
                .WithMessage("Telefon başında '0' olmadan giriniz ve en fazla 10 karakter olabilir!");

            RuleFor(p => p.Hobiler)
              .NotEmpty()
              .WithMessage("Hobi alanı boş bırakılamaz!");

            RuleFor(p => p.Adres)
              .NotEmpty()
              .WithMessage("Adres alanı boş bırakılamaz!");

            RuleFor(p => p.Fotograf)
              .NotEmpty()
              .WithMessage("Fotoğraf yüklemeniz gerekmektedir!");
        }
    }
}
