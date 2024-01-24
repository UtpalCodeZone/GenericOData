using GenericOData.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Primitives;

namespace GenericOData.Api.Controllers.v1
{
    [Authorize]
    public class CrudBaseController<T> : ControllerBase, IApiController<T>
        where T : class
    {
        private readonly IRepository<T> _repository;

        public CrudBaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            Request.Headers.TryGetValue("Prefer", out StringValues headerValue);
            var result = await _repository.AddAsync(entity);
            if (headerValue == "return=representation")
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<T> entity)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            Request.Headers.TryGetValue("Prefer", out StringValues headerValue);
            var result = await _repository.PatchAsync(key, entity);

            if (headerValue == "return=representation")
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            Request.Headers.TryGetValue("Prefer", out StringValues headerValue);
            var result = await _repository.UpdateAsync(key, entity);

            if (headerValue == "return=representation")
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAll();

            if (result == null)
            {
                return NoContent();
            }
            else if (result.Count() <= 2000)
            {
                return Ok(result);
            }
            else
            {
                return Ok(result.ToList());
            }
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromODataUri] int key)
        {
            var result = await _repository.GetByIdAsync(key);

            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromODataUri] int key)
        {
            await _repository.DeleteAsync(key);
            return NoContent();
        }
    }
}
