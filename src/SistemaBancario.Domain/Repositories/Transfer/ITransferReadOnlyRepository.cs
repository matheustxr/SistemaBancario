namespace SistemaBancario.Domain.Repositories.Transfer
{
    public interface ITransferReadOnlyRepository
    {
        Task<IEnumerable<Entities.Transfer>> GetByUserIdAndPeriodAsync(
            Guid userId,
            DateTime? startDate,
            DateTime? endDate);
    }
}
