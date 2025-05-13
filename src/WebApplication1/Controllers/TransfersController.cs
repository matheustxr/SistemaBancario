using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.UseCases.Transfer.GetTransfer;
using SistemaBancario.Application.UseCases.Transfer.TransferBalance;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;

namespace SistemaBancario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseListTransfersJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransfers(
        [FromServices] IGetAllTransfersUseCase useCase,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
        {
            var request = new RequestListTransfersJson
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await useCase.Execute(request);

            return Ok(result);
        }
        


        [HttpPost("transfer")]
        [ProducesResponseType(typeof(ResponseTransferBalanceJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Transfer(
        [FromBody] RequestTransferBalanceJson request,
        [FromServices] ITransferBalanceUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
