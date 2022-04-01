using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;

namespace InveTime.WebApi.Infrastructure.AutoMapperProfiles
{
    public class MappToCategoryModel : Profile
    {
        public MappToCategoryModel()
        {
            CreateMap<Category, CategoryModel>()
                .ReverseMap();
        }
    }
}
