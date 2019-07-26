using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Repositories
{
    public class FrontRepository : MoneyRepositoryBase<Front, MoneyEntities>, IFrontRepository
    {
        public FrontRepository(MoneyEntities context) : base(context)
        {
        }

    }
}
