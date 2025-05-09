using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Domain.Services.LoggdUser
{
    public interface ILoggedUser
    {
        Task<User> Get();
    }
}
