using Cashrewards.Application.Infrastructures.Requests;

namespace Cashrewards.Application.Commands.CreateMerchant
{
    public class CreateMerchantCommand : BaseRequest
    {
        public bool IsActive { get; set; }

        public string Currency { get; set; }

        public string WebsiteUrl { get; set; }

        public string Country { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
