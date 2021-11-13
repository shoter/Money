using MoneyBack;
using MoneyBack.Calculators;
using MoneyBack.Currencies;
using MoneyBack.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Money.ViewModels.Fronts
{
    public class FrontInformationViewModel : INotifyPropertyChanged
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public decimal Profit { get; set; }

        public string ProfitText => Currency.FormatPrice(Profit);
        public StockBroker Broker { get; set; }

        public Brush ProfitFontBrush => Profit > 0m ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public int HoldedAmount { get; set; }
        private decimal? holdedPrice;
        public decimal? HoldedPrice
        {
            get => holdedPrice;
            set
            {
                holdedPrice = value;
                NotifyPropertyChanged("Forecast");
                NotifyPropertyChanged("HoldedPriceText");
                NotifyPropertyChanged("ForecastFontBrush");
            }
        }

        public string HoldedPriceText => Currency.FormatPrice(HoldedPrice);

        public decimal Forecast
        {
            get
            {
                if (HoldedPrice.HasValue == false || HoldedAmount == 0)
                {
                    return Profit;
                }

                ICommisionCalculator calculator = CalculatorProvider.Provide(Broker);

                return Profit + HoldedPrice.Value * HoldedAmount - calculator.Calculate(HoldedPrice.Value);
            }
        }

        public string ForecastText => Currency.FormatPrice(Forecast);

        public Brush ForeacstFontBrush => Forecast >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);

        public ICurrency Currency { get; set; }

        public FrontInformationViewModel(Front front)
        {
            StartDate = front.StartDate.ToShortDateString();
            EndDate = front.EndDate?.ToShortDateString();
            Profit = front.Transactions.Select(t => t.Total).Sum() ?? 0m;
            HoldedAmount = front.Transactions.Select(t => t.AmountChange).Sum() ?? 0;
            this.Broker = (StockBroker)front.Company.Broker;
            this.Currency = CurrencyProvider.ProvideCurrency((StockBroker)front.Company.Broker);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
