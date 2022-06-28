using AutoMapper;
using MM.geekShopping.Product.WebApi.Data.ValueObjects;
namespace MM.geekShopping.Product.WebApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, MM.GeekShopping.Model.Product.WebApi.Model.Product>();
                config.CreateMap<MM.GeekShopping.Model.Product.WebApi.Model.Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
