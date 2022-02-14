using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class InventoryModelController : MappFromEntityToModelController<Inventory, InventoryModel>
    {
        public InventoryModelController(IRepository<Inventory> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
