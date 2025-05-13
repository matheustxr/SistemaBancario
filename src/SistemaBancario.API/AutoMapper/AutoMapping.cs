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

            CreateMap<Transfer, TransferItemJson>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.ReceiverEmail, opt => opt.MapFrom(src => src.ReceiverUser.Email))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.BalanceAfter, opt => opt.MapFrom(src => src.BalanceAfter));
        }
    }
}
