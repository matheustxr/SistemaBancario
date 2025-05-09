using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Domain.Security.Tokens
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
