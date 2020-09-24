using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Commands.CreateMerchant
{
    public class CreateMerchantHandler : IRequestHandler<CreateMerchantCommand, Response>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public CreateMerchantHandler(
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var createMerchantRequest = _mapper.Map<MerchantDto>(request);
            createMerchantRequest.UniqueId = Guid.NewGuid().ToString();

            var createMerchantResult = await _merchantRepository.CreateMerchant(createMerchantRequest);
            
            return createMerchantResult.IsSuccess
                ? new Response(HttpStatusCode.OK)
                : new Response(HttpStatusCode.BadRequest);
        }
    }
}
