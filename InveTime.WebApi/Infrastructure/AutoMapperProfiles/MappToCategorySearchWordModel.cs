using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToCategorySearchWordModel : Profile
    {
        public MappToCategorySearchWordModel()
        {
            CreateMap<CategorySearchWord, CategorySearchWordModel>()
                .ForMember(mod => mod.CategoryName, source => source.MapFrom(ent => ent.Category.Name))
                .ReverseMap();
        }
    }
}
