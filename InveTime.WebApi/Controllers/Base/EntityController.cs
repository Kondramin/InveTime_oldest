using InveTime.Interfaces.Base.Entity;
using InveTime.Interfaces.Base.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace InveTime.WebApi.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<T> : ControllerBase
        where T : class, IEntity, new()
    {
        private readonly IRepository<T> _Repository;

        public EntityController(IRepository<T> repository)
        {
            _Repository = repository;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(T item)
        {
            var result = await _Repository.AddAsync(item);

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
        public async Task<IActionResult> Exist(T item)
        {
            return await _Repository.ExistAsync(item) ? Ok(true) : NotFound(false);
        }



        [HttpGet("items[[{Skip:int}:{Count:int}]]")]
        [HttpGet("items/{Skip:int}/{Count:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAfterSkip(int Skip, int Count)
        {
            var result = await _Repository.GetAfterSkipAsync(Skip, Count);

            return Ok(result);
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _Repository.GetAllAsync());
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _Repository.GetByIdAsync(id);

            return result is null ? NotFound() : Ok(result);
        }



        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<ActionResult> GetItemsCount()
        {
            var result = await _Repository.GetCountAsync();

            return Ok(result);
        }



        [HttpGet("page/{PageIndex:int}/{PageSize:int}")]
        [HttpGet("page[[{PageIndex:int}:{PageSize:int}]]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IPage<T>>> GetPage(int PageIndex, int PageSize)
        {
            var result = await _Repository.GetPageAsync(PageIndex, PageSize);
            return result.Items.Any() ? Ok(result) : NotFound(result);
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult> Update(T item)
        {
            if ((item is null) || (!await _Repository.ExistAsync(item))) return NotFound();

            var result = await _Repository.UpdateAsync(item);

            return AcceptedAtAction(nameof(Get), new { id = result.Id }, result);
        }



        [HttpDelete("id/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _Repository.RemoveByIdAsync(id);

            return result is null ? NotFound() : Ok(result);
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(T item)
        {
            var result = await _Repository.RemoveAsync(item);

            return result is null ? NotFound() : Ok(result);
        }

    }
}
