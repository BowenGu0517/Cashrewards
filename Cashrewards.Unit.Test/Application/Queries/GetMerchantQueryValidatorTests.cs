using Cashrewards.Application.Queries.GetMerchant;
using FluentValidation.TestHelper;
using Xunit;

namespace Cashrewards.Unit.Test.Application.Queries
{
    public class GetMerchantQueryValidatorTests
    {
        private readonly GetMerchantQueryValidator _validator;
        public GetMerchantQueryValidatorTests()
        {
            _validator = new GetMerchantQueryValidator();
        }

        [Theory]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c896820")]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        [InlineData(" 62178593-efbc-4ba2-9bbd-d2841c896820 ")]
        [InlineData("62178593efbc4ba29bbdd2841c896820")]
        public void ShouldPass_When_InputFormatValid(string uniqueId)
        {
            var query = new GetMerchantQuery
            {
                UniqueId = uniqueId
            };

            var validationResult = _validator.TestValidate(query);

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
            var query = new GetMerchantQuery
            {
                UniqueId = uniqueId
            };

            var validationResult = _validator.TestValidate(query);

            validationResult.ShouldHaveValidationErrorFor(nameof(GetMerchantQuery.UniqueId));
        }
    }
}
