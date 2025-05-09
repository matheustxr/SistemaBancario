namespace SistemaBancario.Domain.Security.Tokens
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
