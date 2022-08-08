using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Jifiti.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        ITransactionsService _transactionsService;
        public TransactionsController(ITransactionsService service)
        {
            _transactionsService = service;
        }

        [HttpGet("GetPersons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            List<Person>? result;
            string stringResponse;
            try
            {
                stringResponse = await _transactionsService.GetPersons();

                result = JsonSerializer.Deserialize<List<Person>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}