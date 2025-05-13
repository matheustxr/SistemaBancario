using SistemaBancario.Communication.Responses;

namespace SistemaBancario.Application.UseCases.Wallets.Get
{
    public interface IGetBalanceUseCase
    {
        Task<ResponseWalletBalanceJson> Execute();
    }
}
