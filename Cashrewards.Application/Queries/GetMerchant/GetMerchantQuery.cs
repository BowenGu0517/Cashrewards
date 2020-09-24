using Cashrewards.Application.Infrastructures.Requests;

namespace Cashrewards.Application.Queries.GetMerchant
{
    public class GetMerchantQuery : BaseRequest
    {
        public string UniqueId { get; set; }
    }
}
