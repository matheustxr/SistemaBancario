using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Application.AutoMapper;
using SistemaBancario.Application.UseCases.Login;
using SistemaBancario.Application.UseCases.Transfer.GetTransfer;
using SistemaBancario.Application.UseCases.Transfer.TransferBalance;
using SistemaBancario.Application.UseCases.Users.Register;
using SistemaBancario.Application.UseCases.Wallets.AddBalance;
using SistemaBancario.Application.UseCases.Wallets.Get;

namespace SistemaBancario.Application
{
    public static class DepedencyInjectionExtension
    {
        public static void AddAplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();

            services.AddScoped<IGetBalanceUseCase, GetBalanceUseCase>();
            services.AddScoped<IAddBalanceUseCase, AddBalanceUseCase>();

            services.AddScoped<ITransferBalanceUseCase, TransferBalanceUseCase>();
            services.AddScoped<IGetAllTransfersUseCase, GetAllTransfersUseCase>();
        }
    }
}
