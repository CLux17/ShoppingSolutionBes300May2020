using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using ShoppingApi.Data;
using ShoppingApi.Migrations;
using ShoppingApi.Models;
using System;
using System.Linq;

namespace ShoppingApi
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // // FROM ShoppingItem -> ShoppingListItemResponse
            CreateMap<ShoppingItem, ShoppingListItemResponse>();

            CreateMap<CreateCurbsideOrder, OrderForCurbside>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => string.Join(",", src.Items))); // Will this work? No.


            CreateMap<OrderForCurbside, CurbsideOrder>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Split(',', StringSplitOptions.None).ToList()));

        }
    }
}