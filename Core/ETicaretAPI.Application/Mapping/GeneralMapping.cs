
using AutoMapper;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs.Basket;

using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Application.Features.Commands.AppUser.CreateUser;
using ETicaretAPI.Application.Features.Commands.Basket.AddItemToBasket;
using ETicaretAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using ETicaretAPI.Application.Features.Commands.Basket.UpdateBasketItemQuantity;
using ETicaretAPI.Application.Features.Commands.Category.CreateCategory;
using ETicaretAPI.Application.Features.Commands.Order.AddOrderToOrderBlock;
using ETicaretAPI.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI.Application.Features.Commands.Order.SetPriceToOrder;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.Specs.CreateSpec;
using ETicaretAPI.Application.Features.Commands.Specs.DeleteSpec;
using ETicaretAPI.Application.Features.Queries.Category.GetAllCategory;
using ETicaretAPI.Application.Features.Queries.Category.GetSearchCategory;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetSearchProduct;
using ETicaretAPI.Application.Features.Queries.Spec.GetAllSpec;
using ETicaretAPI.Application.Features.Queries.Spec.GetSpecList;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            AllowNullCollections = false;
            CreateMap<Product, CreateProductRequest>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<SpecName, CreateSpecRequest>().ReverseMap();
            CreateMap<SpecName, GetAllSpecResponse>().ReverseMap();
            CreateMap<Category, CategoryReadDto>().ReverseMap();
            
            CreateMap<CreateUserCommandRequest, CreateUserRequest>().ReverseMap();
            CreateMap<CreateUserRequest, CreateUserCommandRequest>().ReverseMap();
            CreateMap<CreateCategoryRequest, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<GetAllProductRequest, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<GetSearchProductRequest, GetSearchProductQueryRequest>().ReverseMap();
            CreateMap<GetSearchProductResponse, GetSearchProductQueryResponse>().ReverseMap();
            CreateMap<GetSearchCategoryRequest, GetSearchCategoryQueryRequest>().ReverseMap();
            CreateMap<GetSearchCategoryResponse, GetSearchCategoryQueryResponse>().ReverseMap();
            CreateMap<CreateProductRequest, CreateProductCommandRequest>().ReverseMap();
            CreateMap<UpdateProductRequest, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<CreateSpecRequest, CreateSpecCommandRequest>().ReverseMap();
            CreateMap<DeleteSpecRequest, DeleteSpecCommandRequest>().ReverseMap();
            CreateMap<GetAllSpecResponse, GetAllSpecQueryResponse>().ReverseMap();
            CreateMap<AddItemToBasketRequest,AddItemToBasketCommandRequest>().ReverseMap();
            CreateMap<RemoveBasketItemRequest, RemoveBasketItemCommandRequest>().ReverseMap();
            CreateMap<UpdateBasketItemQuantityRequest,UpdateBasketItemQuantityCommandRequest> ().ReverseMap();
            CreateMap<AddOrderCommandRequest, AddOrderToOrderBlockRequest>().ReverseMap();
            CreateMap<CreateOrderCommandRequest, CreateOrderRequest>().ReverseMap(); 
            CreateMap<SetPriceToOrderCommandRequest, SetPriceToOrderRequest>().ReverseMap();

            CreateMap<GetAllProductResponse, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<GetSpecListRequest,GetSpecListQueryRequest>().ReverseMap();
            CreateMap<GetSpecListResponse, GetSpecListQueryResponse>().ReverseMap();
            
        }



    }
}
