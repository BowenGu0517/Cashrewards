using System.Net;

namespace Cashrewards.Application.Infrastructures.Reponses
{
    public class Response
    {
        public HttpStatusCode HttpStatusCode { get; }

        public bool IsSuccessfulResponse => (int)HttpStatusCode / 100 == 2;

        public Response(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
