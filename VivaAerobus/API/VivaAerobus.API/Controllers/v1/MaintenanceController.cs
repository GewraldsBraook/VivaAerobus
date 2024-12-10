using MediatR;
using Microsoft.AspNetCore.Mvc;
using VivaAerobus.API.Attributes;
using VivaAerobus.API.Controllers.Base;
using VivaAerobus.Aplication.Log.Models.Queries;
using VivaAerobus.Aplication.Log.Models.Queries.Results;

namespace VivaAerobus.API.Controllers.v1
{
    [ApiController]
    [ApiKey]
    [Route("api/v1/[controller]")]
    public class MaintenanceController(ILogger<MaintenanceController> logger, IMediator mediator) : BaseController(logger, mediator)
    {

        /// <summary>
        /// Get all logs 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(LogsResult), 200)]
        [ProducesResponseType(typeof(Nullable), 401)]
        [ProducesResponseType(typeof(Nullable), 500)]
        public async Task<IActionResult> Get()
        {
            return await SendQuery<GetAllLogsQuery, LogsResult>(new GetAllLogsQuery());
        }
    }
}
