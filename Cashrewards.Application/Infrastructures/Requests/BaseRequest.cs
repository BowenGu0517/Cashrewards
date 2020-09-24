using Cashrewards.Application.Infrastructures.Reponses;
using MediatR;

namespace Cashrewards.Application.Infrastructures.Requests
{
    public abstract class BaseRequest : IRequest<Response>
    {
    }
}
