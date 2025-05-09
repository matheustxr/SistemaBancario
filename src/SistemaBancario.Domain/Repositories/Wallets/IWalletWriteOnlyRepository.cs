using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Domain.Repositories.Wallets
{
    public interface IWalletWriteOnlyRepository
    {
        Task Add(Wallet wallet);
    }
}
