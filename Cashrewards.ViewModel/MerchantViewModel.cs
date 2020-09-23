namespace Cashrewards.ViewModel
{
    public class MerchantViewModel
    {
        public string UniqueId { get; set; }

        public bool IsActive { get; set; }

        public string Currency { get; set; }

        public string WebsiteUrl { get; set; }

        public string Country { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
