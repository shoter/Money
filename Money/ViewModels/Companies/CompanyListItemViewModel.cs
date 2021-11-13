using MoneyBack.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.ViewModels.Companies
{
    public class CompanyListItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int StockPriceType { get; set; }

        public string Symbol { get; set; }
        public int FrontsCount { get; set; }

        public int Broker { get; set; }

        public string BrokerName => ((StockBroker)Broker).ToString();
    }
}
