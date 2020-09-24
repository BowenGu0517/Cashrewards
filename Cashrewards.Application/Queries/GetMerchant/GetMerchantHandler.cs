using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Queries.GetMerchant
{
    public class GetMerchantHandler : IRequestHandler<GetMerchantQuery, Response>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public GetMerchantHandler(
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var getMerchantResult = await _merchantRepository.GetMerchant(request.UniqueId);
            if (getMerchantResult.IsFailed)
            {
                return new Response(HttpStatusCode.BadRequest);
            }

            var merchantDto = getMerchantResult.Value;
            var merchantViewModel = _mapper.Map<MerchantDto>(merchantDto);

            return new ValueResponse<MerchantDto>(HttpStatusCode.BadRequest, merchantViewModel);
        }
    }
}
