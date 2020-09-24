using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Commands.UpdateMerchant
{
    public class UpdateMerchantHandler : IRequestHandler<UpdateMerchantCommand, Response>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public UpdateMerchantHandler(
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            var updateMerchantRequest = _mapper.Map<MerchantDto>(request);
            var updateMerchantResult = await _merchantRepository.UpdateMerchant(updateMerchantRequest);

            return updateMerchantResult.IsSuccess
                ? new Response(HttpStatusCode.OK)
                : new Response(HttpStatusCode.BadRequest);
        }
    }
}
