using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Repositories
{
    public class MoneyRepositoryBase<TEntity, TContext> : RepositoryBase<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()

    {
        public static event Action<TEntity> NewEntityEvent;
        public MoneyRepositoryBase(TContext context) : base(context)
        {
        }
        public override void Add(TEntity entity)
        {
            base.Add(entity);
            NewEntityEvent?.Invoke(entity);
        }
    }
}
