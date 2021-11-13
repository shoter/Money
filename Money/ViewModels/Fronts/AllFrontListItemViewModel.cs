using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyBack;
using MoneyBack.StockPrices;

namespace Money.ViewModels.Fronts
{
    public class AllFrontListItemViewModel : FrontListItemViewModel
    {
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public StockPriceType StockPriceType { get; }

        public AllFrontListItemViewModel(Front front) : base(front)
        {
            CompanyName = front.Company.Symbol;
            StartDate = front.StartDate;
            this.StockPriceType = (StockPriceType)front.Company.StockPriceType;

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
