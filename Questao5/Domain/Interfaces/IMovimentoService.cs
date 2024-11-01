using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoService
    {
        public Task<RequestResult> Add(MovimentoRequest Command);

        public Task<RequestResult> GetSaldo(SaldoRequest Command);
    }
}
