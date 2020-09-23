using Cashrewards.Application.Common.Reponses;
using MediatR;

namespace Cashrewards.Application.Common.Requests
{
    public abstract class BaseRequest : IRequest<Response>
    {
    }
}
