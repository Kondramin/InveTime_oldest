using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class ProductModelController : MappFromEntityToModelController<Product, ProductModel>
    {
        public ProductModelController(IRepository<Product> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
