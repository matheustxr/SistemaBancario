namespace SistemaBancario.Domain.Repositories.Transfer
{
    public interface ITransferWriteOnlyRepository
    {
        Task Add(Entities.Transfer transfer);
    }
}
