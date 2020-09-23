using Cashrewards.Application.Common.Requests;

namespace Cashrewards.Application.Commands.DeleteMerchant
{
    public class DeleteMerchantCommand : BaseRequest
    {
        public string UniqueId { get; set; }
    }
}
