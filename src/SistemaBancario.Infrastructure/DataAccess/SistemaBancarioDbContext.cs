using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Infrastructure.DataAccess
{
    public class SistemaBancarioDbContext : DbContext
    {
        public SistemaBancarioDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transfer> Transfers { get; set; }

        public void Seed()
        {
            if (!Users.Any())
            {
                Users.AddRange(
                    new User { Id = Guid.NewGuid(), Email = "user1@example.com", Name = "User One", PasswordHash = "hashedpassword1" },
                    new User { Id = Guid.NewGuid(), Email = "user2@example.com", Name = "User Two", PasswordHash = "hashedpassword2" }
                );

                SaveChanges();
            }

            if (!Wallets.Any())
            {
                Wallets.AddRange(
                    new Wallet { Id = 1, UserId = Guid.Parse("user1-id"), Balance = 1000 },
                    new Wallet { Id = 2, UserId = Guid.Parse("user2-id"), Balance = 500 }
                );

                SaveChanges();
            }

            if (!Transfers.Any())
            {
                Transfers.AddRange(
                    new Transfer { Id = 1, SenderUserId = Guid.Parse("user1-id"), ReceiverUserId = Guid.Parse("user2-id"), Amount = 200, Date = DateTime.Now, BalanceAfter = 800 },
                    new Transfer { Id = 2, SenderUserId = Guid.Parse("user2-id"), ReceiverUserId = Guid.Parse("user1-id"), Amount = 100, Date = DateTime.Now, BalanceAfter = 600 }
                );

                SaveChanges();
            }
        }
    }
}