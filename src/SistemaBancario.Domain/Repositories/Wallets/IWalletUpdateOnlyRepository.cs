using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Domain.Repositories.Wallets
{
    public interface IWalletUpdateOnlyRepository
    {
        void Update(Wallet wallet);
    }
}
