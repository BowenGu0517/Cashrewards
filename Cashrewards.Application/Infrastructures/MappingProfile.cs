using AutoMapper;
using Cashrewards.Dto;
using Cashrewards.ViewModel;

namespace Cashrewards.Application.Infrastructures
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MerchantDto, MerchantViewModel>();
            CreateMap<MerchantViewModel, MerchantDto>();
        }
    }
}
