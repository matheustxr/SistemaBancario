using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Domain.Repositories.User;

namespace SistemaBancario.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly SistemaBancarioDbContext _dbContext;
        public UserRepository(SistemaBancarioDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

    }
}
