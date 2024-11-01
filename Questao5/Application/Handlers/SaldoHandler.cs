using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Services;

namespace Questao5.Application.Handlers
{
    public class SaldoHandler : IHandler<SaldoRequest>
    {        
        private readonly IMovimentoService _movimentoService;
        public SaldoHandler(IMovimentoService movimentoService)
        {
            _movimentoService = movimentoService;            
        }

        public async Task<RequestResult> Handle(SaldoRequest command)
        {          
            return await _movimentoService.GetSaldo(command);            
        }
    }
}
