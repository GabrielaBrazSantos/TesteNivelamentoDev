using Questao5.Application.Commands.Responses;

namespace Questao5.Domain.Interfaces.Generic
{
    public interface IService<T>
    {
        public Task<RequestResult> Add(T Objeto);
        public Task<RequestResult> GetById(string Id);
        public Task<List<RequestResult>> List();
    }
}
