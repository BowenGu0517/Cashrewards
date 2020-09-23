using System;

namespace Cashrewards.Dto
{
    public class MerchantDto
    {
        public int Id { get; set; }

        public string UniqueId { get; set; }

        public bool IsActive { get; set; }

        public string Currency { get; set; }

        public string WebsiteUrl { get; set; }

        public string Country { get; set; }

        public decimal DiscountPercentage { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
    }
}
