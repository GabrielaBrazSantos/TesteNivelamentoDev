using Newtonsoft.Json;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    public class MovimentoHandler : IHandler<MovimentoRequest>
    {
        private readonly IIdempotenciaService _IdempotenciaServices;
        private readonly IMovimentoService _movimentoService;
        public MovimentoHandler( IMovimentoService movimentoService, IIdempotenciaService idempotenciaServices)
        {            
            _movimentoService = movimentoService;
            _IdempotenciaServices = idempotenciaServices;
        }

        public async Task<RequestResult> Handle(MovimentoRequest command)
        {            

            var requisicao = await _IdempotenciaServices.GetById(command.Requisicao);
            if (requisicao.StatusCode == StatusCodes.Status200OK)
            {
                return requisicao;
            }
            
            var requestResult = await _movimentoService.Add(command);
            if (requestResult.StatusCode == StatusCodes.Status200OK)
            {
                return await _IdempotenciaServices.Add(new IdempotenciaRequest() { Requisicao = command.Requisicao, Resultado = requestResult.Data.ToString() });
            }
            else
            {
                return requestResult;
            }
        }
    }
}
