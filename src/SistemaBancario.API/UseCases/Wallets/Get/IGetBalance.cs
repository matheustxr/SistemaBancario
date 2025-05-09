using SistemaBancario.Communication.Responses;

namespace SistemaBancario.Application.UseCases.Wallets.Get
{
    public interface IGetBalance
    {
        Task<ResponseWalletBalanceJson> Execute();
    }
}
