using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class CategoryModelController : MappFromEntityToModelController<Category, CategoryModel>
    {
        public CategoryModelController(IRepository<Category> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
