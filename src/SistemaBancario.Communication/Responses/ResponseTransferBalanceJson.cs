namespace SistemaBancario.Communication.Responses
{
    public class ResponseTransferBalanceJson
    {
        public decimal SenderNewBalance { get; set; }
        public string ReceiverEmail { get; set; }
        public decimal TransferredAmount { get; set; }
    }
}
