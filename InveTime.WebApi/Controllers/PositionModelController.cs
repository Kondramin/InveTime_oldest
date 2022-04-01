﻿using AutoMapper;
using InveTime.DataEntities.Entities;
using InveTime.Domain.Domains;
using InveTime.Interfaces.Base.Repository;
using InveTime.WebApi.Controllers.Base;

namespace InveTime.WebApi.Controllers
{
    public class PositionModelController : MappFromEntityToModelController<Position, PositionModel>
    {
        public PositionModelController(IRepository<Position> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
