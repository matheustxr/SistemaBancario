using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Domain.Repositories.Wallets
{
    public interface IWalletReadOnlyRepository
    {
        Task<Wallet?> GetById(long walletId);
        Task<Wallet?> GetByUserId(Entities.User user);
    }
}
