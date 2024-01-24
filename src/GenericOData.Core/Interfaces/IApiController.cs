using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

namespace GenericOData.Core.Interfaces
{
    public interface IApiController<T> where T : class
    {
        public Task<IActionResult> Post([FromBody] T entity);
        public Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<T> entity);
        public Task<IActionResult> Put([FromODataUri] int key, [FromBody] T entity);
        public IActionResult Get();
        public Task<IActionResult> Get([FromODataUri] int key);
    }
}
