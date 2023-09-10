using AquaStoreAPI.Dtos;
using AutoMapper;
using Core.Entities;

namespace AquaStoreAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductCategory, x => x.MapFrom(n => n.ProductCategory.Name))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        }
    }
}
