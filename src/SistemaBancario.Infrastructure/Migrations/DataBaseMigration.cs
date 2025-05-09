using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Infrastructure.DataAccess;

namespace SistemaBancario.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public async static Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<SistemaBancarioDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
