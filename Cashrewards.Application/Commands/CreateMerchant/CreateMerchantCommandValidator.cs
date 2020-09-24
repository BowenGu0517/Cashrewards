using Cashrewards.Application.Infrastructures;
using Cashrewards.Application.Infrastructures.Requests;
using FluentValidation;

namespace Cashrewards.Application.Commands.CreateMerchant
{
    public class CreateMerchantCommandValidator : BaseRequestValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidator()
        {
            RuleFor(c => c.Currency)
                .Must(c => c.IsValidCurrency())
                .WithMessage(ERROR_MESSAGE);

            RuleFor(c => c.Country)
                .Must(c => c.IsValidCountry())
                .WithMessage(ERROR_MESSAGE);

            RuleFor(c => c.WebsiteUrl)
                .Must(w => w.IsValidWebsiteUrl())
                .WithMessage(ERROR_MESSAGE);

            RuleFor(c => c.DiscountPercentage)
                .Must(d => d.IsValidDiscountPercentage())
                .WithMessage(ERROR_MESSAGE);
        }
    }
}
