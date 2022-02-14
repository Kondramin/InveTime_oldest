using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class EmployeeModelController : MappFromEntityToModelController<Employee, EmployeeModel>
    {
        public EmployeeModelController(IRepository<Employee> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
