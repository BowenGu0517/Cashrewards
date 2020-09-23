using Cashrewards.Dto;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cashrewards.Application.Interfaces
{
    public interface IMerchantRepository
    {
        Task<Result<IEnumerable<MerchantDto>>> GetMerchants();

        Task<Result<MerchantDto>> GetMerchant(string uniqueId);

        Task<Result> CreateMerchant(MerchantDto merchantDto);

        Task<Result> UpdateMerchant(MerchantDto merchantDto);

        Task<Result> DeleteMerchant(string uniqueId);
    }
}
