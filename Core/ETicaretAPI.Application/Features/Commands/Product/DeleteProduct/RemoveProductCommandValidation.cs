using ETicaretAPI.Application.Repositories;
using FluentValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandValidation : AbstractValidator<RemoveProductCommandRequest>
    {
        readonly IProductReadRepository _productReadRepository;



        public RemoveProductCommandValidation(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            var ProductId = new List<Guid>();
            var products = _productReadRepository.GetAll(false);
            foreach (var product in products)
            {
                ProductId.Add(product.Id);
            }
            
            RuleFor(p => p.Id).Must(x => ProductId.Contains(x)).WithMessage("Veri Tabanında Girdiğiniz Id Ile Ilgılı Verı bulunamadı Başka Bir Id Girin Ve Gırdıgınız Idnin Dogru Oldugundan Emın Olun");

        }
    }
}

    