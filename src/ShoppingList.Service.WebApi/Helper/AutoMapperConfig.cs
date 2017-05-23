using AutoMapper;
using ShoppingList.Domain.Model;
using ShoppingList.Service.WebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Service.WebApi.Helper
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>();
            });
        }
    }
}