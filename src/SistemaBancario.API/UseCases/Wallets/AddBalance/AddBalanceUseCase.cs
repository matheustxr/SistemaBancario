using AutoMapper;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;
using SistemaBancario.Domain.Repositories.Wallets;
using SistemaBancario.Domain.Repositories;
using SistemaBancario.Domain.Services.LoggdUser;
using SistemaBancario.Exception.ExceptionBase;

namespace SistemaBancario.Application.UseCases.Wallets.AddBalance
{
    public class AddBalanceUseCase : IAddBalanceUseCase
    {
        private readonly IWalletReadOnlyRepository _walletRead;
        private readonly IWalletUpdateOnlyRepository _walletUpdate;
        private readonly ILoggedUser _loggedUser;
        private readonly IUnityOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddBalanceUseCase(
            IWalletReadOnlyRepository walletRead,
            IWalletUpdateOnlyRepository walletUpdate,
            ILoggedUser loggedUser,
            IUnityOfWork unitOfWork,
            IMapper mapper)
        {
            _walletRead = walletRead;
            _walletUpdate = walletUpdate;
            _loggedUser = loggedUser;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseWalletBalanceJson> Execute(RequestAddBalanceJson request)
        {
            var user = await _loggedUser.Get();
            var wallet = await _walletRead.GetByUserId(user);

            wallet.Balance += request.Amount;

            _walletUpdate.Update(wallet);

            await _unitOfWork.Commit();

            return _mapper.Map<ResponseWalletBalanceJson>(wallet);
        }
    }
}
