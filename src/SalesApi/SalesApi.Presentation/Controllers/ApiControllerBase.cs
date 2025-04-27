using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SalesApi.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ILogger<ApiControllerBase> _logger;

        protected ApiControllerBase(ILogger<ApiControllerBase> logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> HandleRequestAsync(Func<Task<IActionResult>> action)
        {
            try
            {
                return await action();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "AutoMapper mapping error.");

                var rootCause = ex.InnerException ?? ex; // Busca a causa real
                var errorDetail = rootCause.Message;

                return BadRequest(new
                {
                    type = "MappingError",
                    error = "Data mapping failed",
                    detail = errorDetail
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception.");

                return StatusCode(500, new
                {
                    type = "ServerError",
                    error = "An unexpected error occurred",
                    detail = ex.Message
                });
            }
        }
    }
}
