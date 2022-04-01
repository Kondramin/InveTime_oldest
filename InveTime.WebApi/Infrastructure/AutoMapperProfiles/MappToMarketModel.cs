using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToMarketModel : Profile
    {
        public MappToMarketModel()
        {
            CreateMap<Market, MarketModel>()
                .ForMember(mod => mod.Staff, source => source.MapFrom(ent => ent.Staff))
                .ReverseMap();
        }
    }
}
