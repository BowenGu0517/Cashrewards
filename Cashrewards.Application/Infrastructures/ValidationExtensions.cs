using Cashrewards.Application.Infrastructures.Types;
using System;

namespace Cashrewards.Application.Infrastructures
{
    public static class ValidationExtensions
    {
        public static bool IsValidUniqueId(this string uniqueId)
        {
            return Guid.TryParse(uniqueId, out _);
        }

        public static bool IsValidCurrency(this string currency)
        {
            return Enum.TryParse(currency, true, out CurrencyEnum _);
        }

        public static bool IsValidCountry(this string country)
        {
            return Enum.TryParse(country, true, out CountryEnum _);
        }

        public static bool IsValidWebsiteUrl(this string websiteUrl)
        {
            return !string.IsNullOrWhiteSpace(websiteUrl);
        }

        public static bool IsValidDiscountPercentage(this decimal percentage)
        {
            return percentage >= decimal.Zero && percentage <= 100.00m;
        }
    }
}
