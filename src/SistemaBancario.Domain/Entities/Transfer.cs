namespace SistemaBancario.Domain.Entities
{
    public class Transfer
    {
        public long Id { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid ReceiverUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal BalanceAfter { get; set; }

        public User SenderUser { get; set; } = null!;
        public User ReceiverUser { get; set; } = null!;
    }
}
