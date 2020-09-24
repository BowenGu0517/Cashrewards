using AutoMapper;
using Cashrewards.Application.Infrastructures.Reponses;
using Cashrewards.Application.Interfaces;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Cashrewards.Application.Commands.DeleteMerchant
{
    public class DeleteMerchantHandler : IRequestHandler<DeleteMerchantCommand, Response>
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public DeleteMerchantHandler(
            IMerchantRepository merchantRepository,
            IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var deleteMerchantResult = await _merchantRepository.DeleteMerchant(request.UniqueId);

            return deleteMerchantResult.IsSuccess
                ? new Response(HttpStatusCode.OK)
                : new Response(HttpStatusCode.BadRequest);
        }
    }
}
