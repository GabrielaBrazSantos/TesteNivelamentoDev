using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using System.Net;

namespace Questao5.Application.Handlers
{
    public class IdempotenciaHandler:IHandler<IdempotenciaRequest>
    {
        private readonly IIdempotenciaService _services;
        public IdempotenciaHandler(IIdempotenciaService services)
        {
            _services = services;
        }

        public async Task<RequestResult> Handle(IdempotenciaRequest command)
        {
            if(!command.IsValid) 
            {
                return new RequestResult().BadRequest("Campo Requisição obrigtório.", command);
            }

            return await _services.GetById(command.Requisicao);            
        }
    }
}
