using Cashrewards.Application.Commands.CreateMerchant;
using FluentValidation.TestHelper;
using Xunit;

namespace Cashrewards.Unit.Test.Application.Commands
{
    public class CreateMerchantCommandValidatorTests
    {
        private readonly CreateMerchantCommandValidator _validator;

        public CreateMerchantCommandValidatorTests()
        {
            _validator = new CreateMerchantCommandValidator();
        }

        [Theory]
        [InlineData("AUD", "Australia", "www.test.com", 100)]
        [InlineData(" USD ", " America ", "www.test.com", 0)]
        public void ShouldPass_When_InputFormatValid(
            string currency,
            string country,
            string websiteUrl,
            decimal discountPercentage)
        {
            var command = new CreateMerchantCommand
            {
                Currency = currency,
                Country = country,
                WebsiteUrl = websiteUrl,
                DiscountPercentage = discountPercentage
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("CAD")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFail_When_InputCurrencyInValid(string currency)
        {
            var command = new CreateMerchantCommand
            {
                Currency = currency,
                Country = "Australia",
                WebsiteUrl = "www.test.com",
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(CreateMerchantCommand.Currency));
        }

        [Theory]
        [InlineData("Canada")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFail_When_InputCountryInValid(string country)
        {
            var command = new CreateMerchantCommand
            {
                Currency = "AUD",
                Country = country,
                WebsiteUrl = "www.test.com",
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(CreateMerchantCommand.Country));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]

        public void ShouldFail_When_InputWebsiteUrlInValid(string websiteUrl)
        {
            var command = new CreateMerchantCommand
            {
                Currency = "AUD",
                Country = "Australia",
                WebsiteUrl = websiteUrl,
                DiscountPercentage = 10
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(CreateMerchantCommand.WebsiteUrl));
        }

        [Theory]
        [InlineData(100.01)]
        [InlineData(-0.01)]

        public void ShouldFail_When_InputDiscountPercentageInValid(decimal discountPercentage)
        {
            var command = new CreateMerchantCommand
            {
                Currency = "AUD",
                Country = "Australia",
                WebsiteUrl = "www.test.com",
                DiscountPercentage = discountPercentage
            };

            var validationResult = _validator.TestValidate(command);

            validationResult.ShouldHaveValidationErrorFor(nameof(CreateMerchantCommand.DiscountPercentage));
        }
    }
}
