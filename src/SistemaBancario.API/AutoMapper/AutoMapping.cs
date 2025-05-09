using AutoMapper;
using SistemaBancario.Communication.Requests;
using SistemaBancario.Communication.Responses;
using SistemaBancario.Domain.Entities;

namespace SistemaBancario.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestEntity();
            EntityResponse();
        }

        private void RequestEntity()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.PasswordHash, config => config.Ignore());
        }

        private void EntityResponse()
        {
            CreateMap<User, ResponseUserProfileJson>();

            CreateMap<Wallet, ResponseWalletBalanceJson>();
        }
    }
}
