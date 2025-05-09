using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Repositories;

namespace SistemaBancario.Infrastructure.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly SistemaBancarioDbContext _dbContext;

        public UnityOfWork(SistemaBancarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Erro ao salvar no banco: " + ex.InnerException?.Message);
                throw;
            }
        }
    }
}
