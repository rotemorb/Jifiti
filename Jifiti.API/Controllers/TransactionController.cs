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
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok(result);
        }

        [HttpGet("GetCards")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards(string appId)
        {
            List<Card>? result;
            string stringResponse;
            try
            {
                stringResponse = await _transactionsService.GetCards(appId);

                result = JsonSerializer.Deserialize<List<Card>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok(result);
        }

        [HttpGet("GetTransactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(string appId)
        {
            List<Transaction>? result;
            string stringResponse;
            try
            {
                stringResponse = await _transactionsService.GetTransactions(appId);

                result = JsonSerializer.Deserialize<List<Transaction>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

            return Ok(result);
        }
    }
}