using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class ProductInventedModelController : MappFromEntityToModelController<ProductInvented, ProductInventedModel>
    {
        public ProductInventedModelController(IRepository<ProductInvented> repository, IMapper mapper) : base (repository, mapper) { }
    }
}
