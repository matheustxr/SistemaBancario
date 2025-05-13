using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Domain.Repositories.Transfer;

namespace SistemaBancario.Infrastructure.DataAccess.Repositories
{
    public class TransferRepository : ITransferReadOnlyRepository, ITransferWriteOnlyRepository
    {
        private readonly SistemaBancarioDbContext _dbContext;

        public TransferRepository(SistemaBancarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Transfer transfer)
        {
            await _dbContext.Transfers.AddAsync(transfer);
        }

        public async Task<IEnumerable<Transfer>> GetByUserIdAndPeriodAsync(Guid userId, DateTime? startDate, DateTime? endDate)
        {
            var query = _dbContext.Transfers
                .AsNoTracking()
                .Where(t => t.SenderUserId == userId || t.ReceiverUserId == userId);

            if (startDate.HasValue)
            {
                query = query.Where(t => t.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(t => t.Date <= endDate.Value);
            }

            return await query
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }
    }
}
