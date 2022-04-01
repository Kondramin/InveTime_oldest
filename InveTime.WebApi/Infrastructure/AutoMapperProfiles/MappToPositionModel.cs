using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToPositionModel : Profile
    {
        public MappToPositionModel()
        {
            CreateMap<Position, PositionModel>()
                .ReverseMap();
        }
    }
}
