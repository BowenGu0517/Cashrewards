using Cashrewards.Application.Common.Reponses;
using Cashrewards.Application.Interfaces;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Queries.GetMerchants
{
    public class GetMerchantsHandler : IRequestHandler<GetMerchantsQuery, Response>
    {
        private readonly IMerchantRepository _merchantRepository;

        public GetMerchantsHandler(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<Response> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var getMerchantsResult = await _merchantRepository.GetMerchants();
            if (getMerchantsResult.IsFailed)
            {
                return new Response(HttpStatusCode.BadRequest);
            }

            var getMerchantsDto = getMerchantsResult.Value;

            throw new NotImplementedException();
        }
    }
}
