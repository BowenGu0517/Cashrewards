using FluentValidation;

namespace Cashrewards.Application.Infrastructures.Requests
{
    public class BaseRequestValidator<T> : AbstractValidator<T> where T : BaseRequest
    {
        protected const string ERROR_MESSAGE = "Invalid format: '{PropertyName}'";

        public BaseRequestValidator()
        {
            CascadeMode = CascadeMode.Stop;
        }
    }
}
