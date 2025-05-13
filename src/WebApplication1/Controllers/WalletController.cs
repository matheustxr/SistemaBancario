using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Application.UseCases.Wallets.AddBalance;
using SistemaBancario.Application.UseCases.Wallets.Get;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;

namespace SistemaBancario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseWalletBalanceJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBalance([FromServices] IGetBalanceUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response == null)
                return NoContent();

            return Ok(response);
        }

        [HttpPost("add-balance")]
        [ProducesResponseType(typeof(ResponseWalletBalanceJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddBalance(
        [FromBody] RequestAddBalanceJson request,
        [FromServices] IAddBalanceUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
