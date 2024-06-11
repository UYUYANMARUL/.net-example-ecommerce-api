using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidation() 
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");



        }
    }
}
