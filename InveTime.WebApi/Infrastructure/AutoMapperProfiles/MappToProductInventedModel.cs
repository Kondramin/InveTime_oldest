using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToProductInventedModel : Profile
    {
        public MappToProductInventedModel()
        {
            CreateMap<ProductInvented, ProductInventedModel>()
                .ForMember(mod => mod.ProductInfo, source => source.MapFrom(ent => ent.ProductInfo))
                .ReverseMap();
        }
    }
}
