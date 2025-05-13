using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Domain.Repositories.User;
using SistemaBancario.Domain.Repositories;
using SistemaBancario.Domain.Security.Cryptography;
using SistemaBancario.Domain.Security.Tokens;
using SistemaBancario.Domain.Services.LoggdUser;
using SistemaBancario.Infrastructure.DataAccess.Repositories;
using SistemaBancario.Infrastructure.DataAccess;
using SistemaBancario.Infrastructure.Sevices.LoggedUser;
using SistemaBancario.Infrastructure.Security.Tokens;
using SistemaBancario.Infrastructure.Extensions;
using SistemaBancario.Domain.Repositories.Wallets;
using SistemaBancario.Domain.Repositories.Transfer;

namespace SistemaBancario.Infrastructure
{
    public static class DepedencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();
            services.AddScoped<ILoggedUser, LoggedUser>();

            AddToken(services, configuration);
            AddRepositories(services);

            if (configuration.IsTestEnvironment() == false)
            {
                AddDbContext(services, configuration);
            }
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

            services.AddScoped<IWalletReadOnlyRepository, WalletRepository>();
            services.AddScoped<IWalletWriteOnlyRepository, WalletRepository>();
            services.AddScoped<IWalletUpdateOnlyRepository, WalletRepository>();

            services.AddScoped<ITransferReadOnlyRepository, TransferRepository>();
            services.AddScoped<ITransferWriteOnlyRepository, TransferRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<SistemaBancarioDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
