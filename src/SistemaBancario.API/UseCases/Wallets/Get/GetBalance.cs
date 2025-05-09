using AutoMapper;
using SistemaBancario.Communication.Responses;
using SistemaBancario.Domain.Repositories.Wallets;
using SistemaBancario.Domain.Services.LoggdUser;

namespace SistemaBancario.Application.UseCases.Wallets.Get
{
    public class GetBalance : IGetBalance
    {
        private readonly IWalletReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public GetBalance(IWalletReadOnlyRepository repository, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<ResponseWalletBalanceJson> Execute()
        {
            var loggedUser = await _loggedUser.Get();

            var wallet = await _repository.GetByUserId(loggedUser);

            return _mapper.Map<ResponseWalletBalanceJson>(wallet);
        }
    }
}
