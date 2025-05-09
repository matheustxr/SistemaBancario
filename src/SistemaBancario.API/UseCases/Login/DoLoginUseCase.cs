using Habits.Exception.ExceptionBase;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Domain.Repositories.User;
using SistemaBancario.Domain.Security.Cryptography;
using SistemaBancario.Domain.Security.Tokens;

namespace SistemaBancario.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPasswordEncrypter _passwordEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(
            IUserReadOnlyRepository repository,
            IPasswordEncrypter passwordEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _passwordEncripter = passwordEncripter;
            _repository = repository;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passwordEncripter.Verify(request.Password, user.PasswordHash);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();

            }

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
