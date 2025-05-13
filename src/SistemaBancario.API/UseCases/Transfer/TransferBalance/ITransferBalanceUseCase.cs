using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;

namespace SistemaBancario.Application.UseCases.Transfer.TransferBalance
{
    public interface ITransferBalanceUseCase
    {
        Task<ResponseTransferBalanceJson> Execute(RequestTransferBalanceJson request);
    }
}
