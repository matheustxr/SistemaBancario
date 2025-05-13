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
    }
}