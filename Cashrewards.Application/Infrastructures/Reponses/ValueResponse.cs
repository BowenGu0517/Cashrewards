using FluentResults;
using System.Net;

namespace Cashrewards.Application.Infrastructures.Reponses
{
    public class ValueResponse<TValue> : Response where TValue : class
    {
        public TValue Value { get; }

        public bool IsFailed => Value is Error;

        public bool IsSucess => !IsFailed;

        public ValueResponse(HttpStatusCode httpStatusCode, TValue value) : base(httpStatusCode)
        {
            Value = value;
        }
    }
}
