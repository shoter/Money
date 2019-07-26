using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyBack;

namespace Money.ViewModels.Fronts
{
    public class AllFrontListItemViewModel : FrontListItemViewModel
    {
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AllFrontListItemViewModel(Front front) : base(front)
        {
            CompanyName = front.Company.Symbol;
            StartDate = front.StartDate;

            var last = front.Transactions
                .OrderByDescending(f => f.Date)
                .FirstOrDefault();

            if (last != null)
                EndDate = last.Date;
            else
                EndDate = StartDate;
        }
    }
}
