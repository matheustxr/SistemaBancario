using SistemaBancario.Communication.Requests;

namespace SistemaBancario.Application.UseCases.Login
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
    }
}
