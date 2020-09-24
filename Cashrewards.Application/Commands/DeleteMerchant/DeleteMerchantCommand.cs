using Cashrewards.Application.Infrastructures.Requests;

namespace Cashrewards.Application.Commands.DeleteMerchant
{
    public class DeleteMerchantCommand : BaseRequest
    {
        public string UniqueId { get; set; }
    }
}
