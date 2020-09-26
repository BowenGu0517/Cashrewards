using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using Cashrewards.Application.InternalServices;
using Cashrewards.Dto;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Commands.CreateMerchant
{
    public class CreateMerchantHandler : IRequestHandler<CreateMerchantCommand, Response>
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public CreateMerchantHandler(
            IGuidGenerator guidGenerator,
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _guidGenerator = guidGenerator;
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var createMerchantRequest = _mapper.Map<MerchantDto>(request);
            createMerchantRequest.UniqueId = _guidGenerator.Generate();

            var createMerchantResult = await _merchantRepository.CreateMerchant(createMerchantRequest);
            
            return createMerchantResult.IsSuccess
                ? new Response(HttpStatusCode.OK)
                : new Response(HttpStatusCode.BadRequest);
        }
    }
}
