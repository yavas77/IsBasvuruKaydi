using FluentValidation;
using IsBasvuruKaydi.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.Bussiness.ValidationRules.FluentValidation.AccountValidotors
{
    public class SignInValidator : AbstractValidator<SignInDto>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email boş geçilemez!")
                .MaximumLength(150)
                .WithMessage("Email en fazla 150 karakter olabilir!");

            RuleFor(p => p.Password)
               .NotEmpty()
               .WithMessage("Şifre boş bırakılamaz!")
               .MaximumLength(30)
               .WithMessage("Şifre en fazla 30 karakter olabilir!");

        }
    }
}