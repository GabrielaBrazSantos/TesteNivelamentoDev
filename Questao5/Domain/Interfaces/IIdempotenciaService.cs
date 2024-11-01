using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Domain.Interfaces
{
    public interface IIdempotenciaService
    {
        public Task<RequestResult> Add(IdempotenciaRequest Objeto);
        public Task<RequestResult> GetById(string Id);        
    }
}
