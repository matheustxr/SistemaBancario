namespace SistemaBancario.Communication.Responses
{
    public class ResponseListTransfersJson
    {
        public List<TransferItemJson> Transfers { get; set; } = new();
    }
}
