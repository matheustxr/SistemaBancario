namespace SistemaBancario.Communication.Requests
{
    public class RequestTransferBalanceJson
    {
        public string ReceiverEmail { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
