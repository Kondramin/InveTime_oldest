using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToEmployeeModel : Profile
    {
        public MappToEmployeeModel()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(mod => mod.MarketName, source => source.MapFrom(ent => ent.Market.Name))
                .ForMember(mod => mod.Position, source => source.MapFrom(ent => ent.Position))
                .ReverseMap();
        }
    }
}
