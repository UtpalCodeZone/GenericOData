using GenericOData.Application.Models.V1.DataModels;
using GenericOData.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericOData.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class osController : CrudBaseController<o>
    {
        public osController(IRepository<o> repository) : base(repository)
        {
        }
    }
}
