using Common.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Repositories
{
    public class CompanyRepository : RepositoryBase<Company, MoneyEntities>, ICompanyRepository
    {
        public CompanyRepository(MoneyEntities context) : base(context)
        {
        }
    }
}
