using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToProductModel : Profile
    {
        public MappToProductModel()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(mod => mod.CategoryName, source => source.MapFrom(ent => ent.Category.Name))
                .ReverseMap();
        }
    }
}
