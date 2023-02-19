using AutoMapper;
using Mango.Services.Shopping.Cart.Models.Dto;
using Mango.Services.Shopping.Cart.Models;

namespace Mango.Services.Shopping.Cart
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<ProductDto, Product>().ReverseMap();
                    config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                    config.CreateMap<CartDetail, CartDetailDto>().ReverseMap();
                    config.CreateMap<Mango.Services.Shopping.Cart.Models.Cart, CartDto>().ReverseMap();


                });
            return mappingConfig;


        }
    }
}
