namespace SistemaBancario.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
