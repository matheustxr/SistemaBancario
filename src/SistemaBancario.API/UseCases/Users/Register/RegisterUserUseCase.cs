using AutoMapper;
using FluentValidation.Results;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Domain.Repositories;
using SistemaBancario.Domain.Repositories.User;
using SistemaBancario.Domain.Repositories.Wallets;
using SistemaBancario.Domain.Security.Cryptography;
using SistemaBancario.Domain.Security.Tokens;
using SistemaBancario.Exception;
using SistemaBancario.Exception.ExceptionBase;

namespace SistemaBancario.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncrypter _passwordEncripter;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IWalletWriteOnlyRepository _walletWriteOnlyRepository;
        private readonly IAccessTokenGenerator _tokenGenerator;
        private readonly IUnityOfWork _unitOfWork;

        public RegisterUserUseCase(
            IMapper mapper,
            IPasswordEncrypter passwordEncripter,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IWalletWriteOnlyRepository walletWriteOnlyRepository,
            IAccessTokenGenerator tokenGenerator,
            IUnityOfWork unitOfWork)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _walletWriteOnlyRepository = walletWriteOnlyRepository;
            _tokenGenerator = tokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);

            user.PasswordHash = _passwordEncripter.Encrypt(request.Password);

            await _userWriteOnlyRepository.Add(user);

            var wallet = new Wallet
            {
                UserId = user.Id,
                Balance = 0 
            };

            await _walletWriteOnlyRepository.Add(wallet);

            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }
         
        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
