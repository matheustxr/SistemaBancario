using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Domain.Repositories.Wallets;

namespace SistemaBancario.Infrastructure.DataAccess.Repositories
{
    public class WalletRepository : IWalletReadOnlyRepository, IWalletWriteOnlyRepository, IWalletUpdateOnlyRepository
    {
        private readonly SistemaBancarioDbContext _dbContext;
        public WalletRepository(SistemaBancarioDbContext dbContext) => _dbContext = dbContext;

        public async Task<Wallet?> GetById(long walletId)
        {
            return await _dbContext.Wallets
                .AsNoTracking() 
                .FirstOrDefaultAsync(wallet => wallet.Id == walletId);
        }

        public async Task<Wallet?> GetByUserId(User user)
        {
            return await _dbContext.Wallets
                .AsNoTracking() 
                .FirstOrDefaultAsync(wallet => wallet.UserId == user.Id);
        }

        public async Task Add(Wallet wallet)
        {
            await _dbContext.Wallets.AddAsync(wallet);
        }

        public void Update(Wallet wallet)
        {
            _dbContext.Wallets.Update(wallet);
        }
    }
}
