using Questao5.Entities;

namespace Questao5.Infrastructure.Interfaces
{
    public interface IMovimento 
    {
        public Task Add(Movimento Entity);

        public ContaCorrente GetContaCorrente(int numero);

        public double GetSaldo(string IdContaCorrente);

    }
}
