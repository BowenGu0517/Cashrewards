namespace Cashrewards.Domain
{
    public class Merchant
    {
        public string UniqueId { get; set; }

        public bool IsActive { get; set; }

        public CurrencyEnums Currency { get; set; }

        public string WebsiteUrl { get; set; }
        
        public string Country { get; set; }

        public decimal DiscountPercentage { get; set; }
    }
}
