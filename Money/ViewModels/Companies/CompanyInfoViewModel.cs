using MoneyBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.ViewModels.Companies
{
    public class CompanyInfoViewModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public CompanyInfoViewModel(Company company)
        {
            Name = company.Name;
            Symbol = company.Symbol;
        }
    }
}
