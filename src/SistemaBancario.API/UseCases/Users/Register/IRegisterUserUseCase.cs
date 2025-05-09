using SistemaBancario.Communication.Requests;

namespace SistemaBancario.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
    }
}
