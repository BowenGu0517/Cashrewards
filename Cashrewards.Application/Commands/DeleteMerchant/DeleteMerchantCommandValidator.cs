using Cashrewards.Application.Infrastructures;
using Cashrewards.Application.Infrastructures.Requests;
using FluentValidation;

namespace Cashrewards.Application.Commands.DeleteMerchant
{
    public class DeleteMerchantCommandValidator : BaseRequestValidator<DeleteMerchantCommand>
    {
        public DeleteMerchantCommandValidator()
        {
            RuleFor(c => c.UniqueId)
                .Must(u => u.IsValidUniqueId())
                .WithMessage(ERROR_MESSAGE);
        }
    }
}
