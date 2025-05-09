namespace SistemaBancario.Domain.Entities
{
    public class Wallet
    {
        public long Id { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
