using AutoMapper;
using Cashrewards.Application.Commands.CreateMerchant;
using Cashrewards.Application.Commands.UpdateMerchant;
using Cashrewards.Dto;
using Cashrewards.ViewModel;

namespace Cashrewards.Application.Infrastructures
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MerchantDto, MerchantViewModel>();
            CreateMap<CreateMerchantCommand, MerchantDto>();
            CreateMap<UpdateMerchantCommand, MerchantDto>();
        }
    }
}
