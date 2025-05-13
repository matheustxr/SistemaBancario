using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;

namespace SistemaBancario.Application.UseCases.Transfer.GetTransfer
{
    public interface IGetAllTransfersUseCase
    {
        Task<ResponseListTransfersJson> Execute(RequestListTransfersJson request);
    }
}
