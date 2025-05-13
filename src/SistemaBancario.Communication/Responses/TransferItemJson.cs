namespace SistemaBancario.Communication.Responses
{
    public class TransferItemJson
    {
        public DateTime Date { get; set; }
        public string ReceiverEmail { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
