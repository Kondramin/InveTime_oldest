using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class MarketModelController : MappFromEntityToModelController<Market, MarketModel>
    {
        public MarketModelController(IRepository<Market> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
