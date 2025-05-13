using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;

namespace SistemaBancario.Application.UseCases.Wallets.AddBalance
{
    public interface IAddBalanceUseCase
    {
        Task<ResponseWalletBalanceJson> Execute(RequestAddBalanceJson request);
    }
}
