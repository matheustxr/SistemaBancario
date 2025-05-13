using AutoMapper;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;
using SistemaBancario.Domain.Repositories.Transfer;
using SistemaBancario.Domain.Services.LoggdUser;

namespace SistemaBancario.Application.UseCases.Transfer.GetTransfer
{
    public class GetAllTransfersUseCase : IGetAllTransfersUseCase
    {
        private readonly ITransferReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        private readonly IMapper _mapper;

        public GetAllTransfersUseCase(
            ITransferReadOnlyRepository repository,
            ILoggedUser loggedUser,
            IMapper mapper)
        {
            _repository = repository;
            _loggedUser = loggedUser;
            _mapper = mapper;
        }

        public async Task<ResponseListTransfersJson> Execute(RequestListTransfersJson request)
        {
            var user = await _loggedUser.Get();

            var transfers = await _repository.GetByUserIdAndPeriodAsync(user.Id, request.StartDate, request.EndDate);

            var mappedTransfers = _mapper.Map<List<TransferItemJson>>(transfers);

            return new ResponseListTransfersJson
            {
                Transfers = mappedTransfers
            };
        }
    }
}
