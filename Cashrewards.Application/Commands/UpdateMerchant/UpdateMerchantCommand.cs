using Cashrewards.Application.Common.Requests;

namespace Cashrewards.Application.Commands.UpdateMerchant
{
    public class UpdateMerchantCommand : BaseRequest
    {
        public string UniqueId { get; set; }

        public bool IsActive { get; set; }

        public string Currency { get; set; }

        public string WebsiteUrl { get; set; }

        public string Country { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
