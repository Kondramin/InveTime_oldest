using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToInventoryModel : Profile
    {
        public MappToInventoryModel()
        {
            CreateMap<Inventory, InventoryModel>()
                .ForMember(mod => mod.EventStaff, source => source.MapFrom(ent => ent.EventStaff))
                .ReverseMap();
        }
    }
}
