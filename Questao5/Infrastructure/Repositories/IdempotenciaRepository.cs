using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Questao5.Entities;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Interfaces;
using Questao5.Infrastructure.Interfaces.Generic;
using System.Data;
using System.Data.Common;

namespace Questao5.Infrastructure.Repositories
{
    public class IdempotenciaRepository : Repository, IIdempotencia
    {

        public IdempotenciaRepository(Context db) : base(db)
        {
           
        }
        
        async Task IBase<Idempotencia>.Add(Idempotencia Entity)
        {
            await db.Idempotencia.AddAsync(Entity);
            await db.SaveChangesAsync();          
        }

        async Task<Idempotencia> IBase<Idempotencia>.GetById(string Id)
        {                        
            return await db.Idempotencia.SingleOrDefaultAsync(x => x.Requisicao == Id);
        }

        Task<List<Idempotencia>> IBase<Idempotencia>.List()
        {
            throw new NotImplementedException();
        }

    }
}
