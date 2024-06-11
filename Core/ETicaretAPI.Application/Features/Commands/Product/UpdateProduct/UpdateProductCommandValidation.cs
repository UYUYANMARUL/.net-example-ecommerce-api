using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Repositories;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommandRequest>
    {
        readonly IProductReadRepository _productReadRepository;



        public UpdateProductCommandValidation(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            var ProductId = new List<Guid>();
            var products = _productReadRepository.GetAll(false);
            foreach (var product in products)
            {
                ProductId.Add(product.Id);
            }

            RuleFor(p => p.Id).Must(x => ProductId.Contains(x)).WithMessage("Veri Tabanında Girdiğiniz Id Ile Ilgılı Verı bulunamadı Başka Bir Id Girin Ve Gırdıgınız Idnin Dogru Oldugundan Emın Olun");

            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage("Lütfen Ürün Adını Boş Geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

        }
    }
}

