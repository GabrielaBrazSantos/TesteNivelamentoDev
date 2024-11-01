using MediatR;
using Questao5.Infrastructure.Database;
using System.Data;

namespace Questao5.Infrastructure.Repositories
{
    public class Repository
    {
        protected readonly Context db;        
        
        public Repository(Context context)
        {
            db = context;            
        }
    }
}
