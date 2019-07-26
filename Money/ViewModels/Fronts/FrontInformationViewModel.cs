using MoneyBack;
using MoneyBack.Calculators;
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
                NotifyPropertyChanged("ForecastFontBrush");
            }
        }

        public decimal Forecast => HoldedPrice.HasValue == false || HoldedAmount == 0 ?
            Profit :
            Profit + HoldedPrice.Value * HoldedAmount - CommisionCalculator.Calculate(HoldedPrice.Value);

        public Brush ForeacstFontBrush => Forecast >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);

        public FrontInformationViewModel(Front front)
        {
            StartDate = front.StartDate.ToShortDateString();
            EndDate = front.EndDate?.ToShortDateString();
            Profit = front.Transactions.Select(t => t.Total).Sum() ?? 0m;
            HoldedAmount = front.Transactions.Select(t => t.AmountChange).Sum() ?? 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
