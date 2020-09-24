using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using Cashrewards.ViewModel;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Queries.GetMerchants
{
    public class GetMerchantsHandler : IRequestHandler<GetMerchantsQuery, Response>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public GetMerchantsHandler(
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var getMerchantsResult = await _merchantRepository.GetMerchants();
            if (getMerchantsResult.IsFailed)
            {
                return new Response(HttpStatusCode.BadRequest);
            }

            var merchantsDto = getMerchantsResult.Value;
            var merchantsViewModel = _mapper.Map<IEnumerable<MerchantViewModel>>(merchantsDto);

            return new ValueResponse<IEnumerable<MerchantViewModel>>(HttpStatusCode.OK, merchantsViewModel);
        }
    }
}
