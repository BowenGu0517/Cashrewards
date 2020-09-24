using Cashrewards.Application.Infrastructures.Reponses;
using Microsoft.AspNetCore.Mvc;

namespace Cashrewards.Host.Infrastructure
{
    public static class ResponseExtensions
    {
        public static ActionResult ToActionResult(this Response response)
        {
            return new StatusCodeResult((int)response.HttpStatusCode);
        }

        public static ActionResult<TValue> ToActionResult<TValue>(this Response response) where TValue : class
        {
            switch(response)
            {
                case ValueResponse<TValue> valueReponse:
                    return new ObjectResult(valueReponse.Value)
                    {
                        StatusCode = (int)valueReponse.HttpStatusCode
                    };

                default:
                    return new StatusCodeResult((int)response.HttpStatusCode);
            }
        }
    }
}
