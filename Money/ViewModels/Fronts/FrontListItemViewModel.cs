using MoneyBack;
using MoneyBack.Calculators;
using MoneyBack.Currencies;
using MoneyBack.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Money.ViewModels.Fronts
{
    public class FrontListItemViewModel : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Profit { get; set; }
        public string ProfitText => Currency.FormatPrice(Profit);
        public string Company { get; set; }
        public Brush ProfitFontBrush => Profit >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public int HoldedAmount { get; set; }

        public StockBroker Broker { get; set; }
        public string PriceToSellToHaveProfit => HoldedAmount == 0 ? "" : $"{Currency.FormatPrice(ProfitBackCalculator.Calculate(HoldedAmount, Profit))}";

        public decimal PriceToSellToHaveProfitValue => HoldedAmount == 0 ? 0 : ProfitBackCalculator.Calculate(HoldedAmount, Profit);

        public string PriceToSellToHaveProfitValueText => Currency.FormatPrice(PriceToSellToHaveProfitValue);


        private decimal? holdedPrice;

        public ICurrency Currency { get; set; }
        
        public decimal? HoldedPrice
        {
            get => holdedPrice;
            set
            {
                holdedPrice = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Projection");
                NotifyPropertyChanged("ProjectionText");
                NotifyPropertyChanged("HoldedPriceText");
                NotifyPropertyChanged("ProjectionFontBrush");
                NotifyPropertyChanged("CurrentPriceBrush");
            }
        }

        public string HoldedPriceText => Currency.FormatPrice(HoldedPrice);


        public Decimal Projection
        {
            get
            {
                if (HoldedPrice.HasValue == false || HoldedAmount == 0)
                {
                    return Profit;
                }

                ICommisionCalculator calculator = CalculatorProvider.Provide(Broker);

                return Profit + holdedPrice.Value * HoldedAmount - calculator.Calculate(HoldedAmount * HoldedPrice.Value);
            }
        }

        public string ProjectionText => Currency.FormatPrice(Projection);

        public Brush ProjectionFontBrush => Projection >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public Brush CurrentPriceBrush => HoldedPrice >= PriceToSellToHaveProfitValue ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public FrontListItemViewModel(Front front)
        {
            ID = front.ID;
            Name = front.Name;
            Profit = front.Transactions.Sum(t => t.Total) ?? 0m;
            HoldedAmount = front.Transactions.Sum(t => t.AmountChange) ?? 0;
            Company = front.Company?.Symbol;
            this.Broker = (StockBroker)front.Company.Broker;
            this.Currency = CurrencyProvider.ProvideCurrency((StockBroker)front.Company.Broker);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
