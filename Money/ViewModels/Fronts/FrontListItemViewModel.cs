﻿using MoneyBack;
using MoneyBack.Calculators;
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
        public string Company { get; set; }
        public Brush ProfitFontBrush => Profit >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public int HoldedAmount { get; set; }
        public string PriceToSellToHaveProfit => HoldedAmount == 0 ? "" : $"{ProfitBackCalculator.Calculate(HoldedAmount, Profit):0.##}";
        public decimal PriceToSellToHaveProfitValue => HoldedAmount == 0 ? 0 : ProfitBackCalculator.Calculate(HoldedAmount, Profit);
        private decimal? holdedPrice;
        
        public decimal? HoldedPrice
        {
            get => holdedPrice;
            set
            {
                holdedPrice = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Projection");
                NotifyPropertyChanged("ProjectionFontBrush");
                NotifyPropertyChanged("CurrentPriceBrush");
            }
        }


        public Decimal Projection =>
            holdedPrice.HasValue == false || HoldedAmount == 0 ?
            Profit :
            Profit + HoldedAmount * holdedPrice.Value - CommisionCalculator.Calculate(HoldedAmount * holdedPrice.Value);

        public Brush ProjectionFontBrush => Projection >= 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public Brush CurrentPriceBrush => HoldedPrice >= PriceToSellToHaveProfitValue ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        public FrontListItemViewModel(Front front)
        {
            ID = front.ID;
            Name = front.Name;
            Profit = front.Transactions.Sum(t => t.Total) ?? 0m;
            HoldedAmount = front.Transactions.Sum(t => t.AmountChange) ?? 0;
            Company = front.Company?.Symbol;
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
