using AutoMapper;
using SistemaBancario.Domain.Repositories.User;
using SistemaBancario.Domain.Repositories.Wallets;
using SistemaBancario.Domain.Repositories;
using SistemaBancario.Domain.Services.LoggdUser;
using SistemaBancario.Communication.Responses;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Exception.ExceptionBase;
using SistemaBancario.Exception;

namespace SistemaBancario.Application.UseCases.Transfer.TransferBalance
{
    public class TransferBalanceUseCase : ITransferBalanceUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserReadOnlyRepository _userReadRepository;
        private readonly IWalletReadOnlyRepository _walletRead;
        private readonly IWalletUpdateOnlyRepository _walletUpdate;
        private readonly IUnityOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransferBalanceUseCase(
            ILoggedUser loggedUser,
            IUserReadOnlyRepository userReadRepository,
            IWalletReadOnlyRepository walletRead,
            IWalletUpdateOnlyRepository walletUpdate,
            IUnityOfWork unitOfWork,
            IMapper mapper)
        {
            _loggedUser = loggedUser;
            _userReadRepository = userReadRepository;
            _walletRead = walletRead;
            _walletUpdate = walletUpdate;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseTransferBalanceJson> Execute(RequestTransferBalanceJson request)
        {
            if (request.Amount <= 0)
                throw new ErrorOnValidationException([ResourceErrorMessages.TRANSFER_MUST_BE_ZERO]);

            var sender = await _loggedUser.Get();
            var receiver = await _userReadRepository.GetUserByEmail(request.ReceiverEmail);

            if (receiver == null)
                throw new NotFoundException(ResourceErrorMessages.RECEIVER_NOT_FOUND);

            if (receiver.Id == sender.Id)
                throw new ErrorOnValidationException([ResourceErrorMessages.TRANSFER_TO_SELF_NOT_ALLOWED]);

            var senderWallet = await _walletRead.GetByUserId(sender);

            var receiverWallet = await _walletRead.GetByUserId(receiver);

            if (senderWallet.Balance < request.Amount)
                throw new ErrorOnValidationException([ResourceErrorMessages.INSUFFICIENT_BALANCE]);

            senderWallet.Balance -= request.Amount;
            receiverWallet.Balance += request.Amount;

            _walletUpdate.Update(senderWallet);
            _walletUpdate.Update(receiverWallet);
            await _unitOfWork.Commit();

            return new ResponseTransferBalanceJson
            {
                SenderNewBalance = senderWallet.Balance,
                ReceiverEmail = receiver.Email,
                TransferredAmount = request.Amount
            };
        }
    }
}
