using MoneyBack.Calculators;
using MoneyBack.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.ViewModels.Transactions
{
    public class AddTransactionViewModel : INotifyPropertyChanged
    {
        public TransactionTypeEnum TransactionTypeEnum { get; set; } = TransactionTypeEnum.Buy;

        public string TransactionType
        {
            get => TransactionTypeEnum.ToString();
            set
            {
                TransactionTypeEnum transaction;
                Enum.TryParse(value, out transaction);
                TransactionTypeEnum = transaction;
                OnPropertyChanged("Comission");
                OnPropertyChanged("Profit");
            }
        }
        public DateTime Date { get; set; } = DateTime.Now;

        private int? amount;
        private decimal? price;

        public event PropertyChangedEventHandler PropertyChanged;

        public int? Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged("Comission");
                OnPropertyChanged("Profit");
            }
        }

        public decimal? Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Comission");
                OnPropertyChanged("Profit");
            }
        }

        public AddTransactionViewModel(StockBroker broker)
        {
            this.Broker = broker;
        }

        public StockBroker Broker { get; set; }

        public decimal Comission
        {
            get
            {
                var calculator = CalculatorProvider.Provide(Broker);
                return calculator.Calculate((Price ?? 0m) * (Amount ?? 0));
            }
        }

        public decimal Profit => (TransactionTypeEnum == TransactionTypeEnum.Buy ? -1m : 1m) * (Amount ?? 0) * (Price ?? 0m) - Comission;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
