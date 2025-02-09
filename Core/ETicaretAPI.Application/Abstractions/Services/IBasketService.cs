﻿using ETicaretAPI.Application.DTOs.Basket;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {

        Task AddItemToBasketAsync(AddItemToBasketRequest request);


        Task RemoveBasketItemAsync(RemoveBasketItemRequest request);

        Task UpdateBasketItemQuantityAsync(UpdateBasketItemQuantityRequest request);

        Task<Basket> GetBasketItemsAsync();

        Task EmptyUsersBasket();

    }
}
