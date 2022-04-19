using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriteValidator:AbstractValidator<Writer>
    {
        public WriteValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adını Boş Geçemezsiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Yazar ünvanını Boş Geçemezsiniz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Yazar soy adını Boş Geçemezsiniz");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında kısmını Boş Geçemezsiniz");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage(" 50 karakterden fazla değer girişi yapılamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage(" 50 karakterden fazla değer girişi yapılamaz");
        }

    }
}
