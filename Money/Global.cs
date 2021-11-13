using MoneyBack.Bankier;
using MoneyBack.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class Global
    {
        public static IKernel Kernel { get; private set; }

        static Global()
        {
            ConfigureContainer();
        }
        private static void ConfigureContainer()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<ICompanyRepository>().To<CompanyRepository>().InTransientScope();
            Kernel.Bind<ITransactionRepository>().To<TransactionRepository>().InTransientScope();
            Kernel.Bind<IFrontRepository>().To<FrontRepository>().InTransientScope();
            Kernel.Bind<IBankierConnection>().To<BankierConnection>().InTransientScope();
        }
    }
}
