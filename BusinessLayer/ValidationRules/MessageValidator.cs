using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcı adresini boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş Geçemezsiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesajı boş Geçemezsiniz");     
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage(" 100 karakterden fazla değer girişi yapılamaz");
           
        }
    }
}
