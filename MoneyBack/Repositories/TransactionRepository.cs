using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction, MoneyEntities>, ITransactionRepository
    {
        public TransactionRepository(MoneyEntities context) : base(context)
        {
        }
    }
}
