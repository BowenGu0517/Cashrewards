using Cashrewards.Application.Infrastructures;
using Cashrewards.Application.Infrastructures.Requests;
using FluentValidation;

namespace Cashrewards.Application.Queries.GetMerchant
{
    public class GetMerchantQueryValidator : BaseRequestValidator<GetMerchantQuery>
    {
        public GetMerchantQueryValidator()
        {
            RuleFor(q => q.UniqueId)
                .Must(u => u.IsValidUniqueId())
                .WithMessage(ERROR_MESSAGE);
        }
    }
}
