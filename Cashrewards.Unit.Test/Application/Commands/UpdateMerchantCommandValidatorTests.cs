using Cashrewards.Application.Commands.UpdateMerchant;
using FluentValidation.TestHelper;
using Xunit;

namespace Cashrewards.Unit.Test.Application.Commands
{
    public class UpdateMerchantCommandValidatorTests
    {
        private readonly UpdateMerchantCommandValidator _validator;

        public UpdateMerchantCommandValidatorTests()
        {
            _validator = new UpdateMerchantCommandValidator();
        }

        [Theory]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c896820", "AUD", "Australia", "www.test.com", 100)]
        [InlineData("00000000-0000-0000-0000-000000000000", " USD ", " America ", "www.test.com", 0)]
        public void ShouldPass_When_InputFormatValid(
            string uniqueId,
            string currency,
            string country,
            string websiteUrl,
            decimal discountPercentage)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = uniqueId,
                Currency = currency,
                Country = country,
                WebsiteUrl = websiteUrl,
                DiscountPercentage = discountPercentage
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c89682")]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c8968200")]
        [InlineData("62178593efbc4ba29bbdd2841c89682")]
        [InlineData("62178593efbc4ba29bbdd2841c8968200")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFail_When_InputUniqueIdInValid(string uniqueId)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = uniqueId,
                Currency = "AUD",
                Country = "Australia",
                WebsiteUrl = "www.test.com",
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(UpdateMerchantCommand.UniqueId));
        }

        [Theory]
        [InlineData("CAD")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFail_When_InputCurrencyInValid(string currency)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                Currency = currency,
                Country = "Australia",
                WebsiteUrl = "www.test.com",
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(UpdateMerchantCommand.Currency));
        }

        [Theory]
        [InlineData("Canada")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFail_When_InputCountryInValid(string country)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                Currency = "AUD",
                Country = country,
                WebsiteUrl = "www.test.com",
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(UpdateMerchantCommand.Country));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]

        public void ShouldFail_When_InputWebsiteUrlInValid(string websiteUrl)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                Currency = "AUD",
                Country = "Australia",
                WebsiteUrl = websiteUrl,
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(UpdateMerchantCommand.WebsiteUrl));
        }

        [Theory]
        [InlineData(100.01)]
        [InlineData(-0.01)]

        public void ShouldFail_When_InputDiscountPercentageInValid(decimal discountPercentage)
        {
            var command = new UpdateMerchantCommand
            {
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                Currency = "AUD",
                Country = "Australia",
                WebsiteUrl = "www.test.com",
                DiscountPercentage = discountPercentage
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(UpdateMerchantCommand.DiscountPercentage));
        }
    }
}
