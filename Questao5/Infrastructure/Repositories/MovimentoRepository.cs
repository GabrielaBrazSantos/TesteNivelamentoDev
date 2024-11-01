using Questao5.Domain.Enumerators;
using Questao5.Entities;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Interfaces;


namespace Questao5.Infrastructure.Repositories
{
    public class MovimentoRepository : Repository, IMovimento
    {
        public MovimentoRepository(Context db) : base(db)
        {

        }

        public async Task Add(Movimento Entity)
        {
            await db.Movimento.AddAsync(Entity);
            await db.SaveChangesAsync();            
        }

        public ContaCorrente GetContaCorrente(int numero)
        {
            return db.ContaCorrente.SingleOrDefault(x => x.Numero == numero);
        }


        public double GetSaldo(string IdContaCorrente)
        {
            double creditos = db.Movimento.Where(x => x.IdContaCorrente == IdContaCorrente 
                              && x.TipoMovimento == TipoMovimentoEnum.CREDITO).Sum(y=> y.Valor);

            double debitos = db.Movimento.Where(x => x.IdContaCorrente == IdContaCorrente
                              && x.TipoMovimento == TipoMovimentoEnum.DEBITO).Sum(y => y.Valor);

            return creditos - debitos;
        }

    }
}
