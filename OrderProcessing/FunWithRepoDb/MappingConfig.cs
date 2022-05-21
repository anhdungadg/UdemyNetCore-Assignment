using AutoMapper;
using FunWithRepoDb.Models;
using FunWithRepoDb.Models.DTOs;


namespace FunWithRepoDb
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });

            return mappingConfig;
        }
    }
}
