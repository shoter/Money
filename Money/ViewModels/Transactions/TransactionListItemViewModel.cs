using MoneyBack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Money.ViewModels.Transactions
{
    public class TransactionListItemViewModel
    {
        public decimal Price { get; set; }
        public decimal Commision { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public Brush TransactionTypeFontBrush =>
            TransactionType == TransactionTypeEnum.Buy ? new SolidColorBrush(Colors.Green)
                                                       : new SolidColorBrush(Colors.Red);
        public decimal Profit { get; set; }
        public Brush ProfitFontBrush =>
            Profit > 0m ? new SolidColorBrush(Colors.Green)
                        : new SolidColorBrush(Colors.Red);




    }
}
