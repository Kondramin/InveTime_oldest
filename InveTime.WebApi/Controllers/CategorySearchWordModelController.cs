using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class CategorySearchWordModelController : MappFromEntityToModelController<CategorySearchWord, CategorySearchWordModel>
    {
        public CategorySearchWordModelController(IRepository<CategorySearchWord> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
