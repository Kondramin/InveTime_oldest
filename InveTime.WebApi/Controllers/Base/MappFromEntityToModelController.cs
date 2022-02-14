using AutoMapper;
using InveTime.Interfaces.Base.Entity;
using InveTime.Interfaces.Base.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InveTime.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MappFromEntityToModelController<T, TModel> : ControllerBase
        where T : class, IEntity, new()
        where TModel : class, IEntityModel, new()
    {
        private readonly IRepository<T> _Repository;
        private readonly IMapper _Mapper;

        public MappFromEntityToModelController(IRepository<T> repository, IMapper mapper)
        {
            _Repository = repository;
            _Mapper = mapper;
        }


        public virtual TModel GetModel(T item) => _Mapper.Map<TModel>(item);
        public virtual IEnumerable<TModel> GetModels(IEnumerable<T> items) => _Mapper.Map<IEnumerable<TModel>>(items);

        public virtual T GetEntity(TModel item) => _Mapper.Map<T>(item);
        public virtual IEnumerable<T> GetEntities(IEnumerable<TModel> items) => _Mapper.Map<IEnumerable<T>>(items);




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(TModel item)
        {
            var result = await _Repository.AddAsync(GetEntity(item));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }



        [HttpGet("exist/id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> ExistId(int id)
        {
            return await _Repository.ExistIdAsync(id) ? Ok(true) : NotFound(false);
        }



        [HttpPost("exist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> Exist(TModel item)
        {
            return await _Repository.ExistAsync(GetEntity(item)) ? Ok(true) : NotFound(false);
        }



        [HttpGet("items[[{Skip:int}:{Count:int}]]")]
        [HttpGet("items/{Skip:int}/{Count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAfterSkip(int Skip, int Count)
        {
            var result = GetModels(await _Repository.GetAfterSkipAsync(Skip, Count));

            return Ok(result);
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(GetModels(await _Repository.GetAllAsync()));
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var result = GetModel(await _Repository.GetByIdAsync(id));

            return result is null ? NotFound() : Ok(result);
        }



        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<ActionResult> GetItemsCount()
        {
            var result = await _Repository.GetCountAsync();

            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> Update(TModel item)
        {
            if ((item is null) || (!await _Repository.ExistAsync(GetEntity(item)))) return NotFound();

            var result = await _Repository.UpdateAsync(GetEntity(item));

            return AcceptedAtAction(nameof(Get), new { id = result.Id }, result);
        }



        [HttpDelete("id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = GetModel(await _Repository.RemoveByIdAsync(id));

            return result is null ? NotFound() : Ok(result);
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(TModel item)
        {
            var result = await _Repository.RemoveAsync(GetEntity(item));

            return result is null ? NotFound() : Ok(GetModel(result));
        }

    }
}
