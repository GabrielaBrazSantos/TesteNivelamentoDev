

namespace Questao5.Infrastructure.Interfaces.Generic
{
    public interface IBase<T> where T : class
    {
        public Task Add(T Entity);                
        public Task<T> GetById(string Id);
        public Task<List<T>> List();
    }
}
