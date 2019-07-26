using Common.Tasks;
using Money.ViewModels.Fronts;
using Money.ViewModels.Transactions;
using MoneyBack;
using MoneyBack.Bankier;
using MoneyBack.Enums;
using MoneyBack.Repositories;
using MoneyBack.Requests;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Money
{
    /// <summary>
    /// Interaction logic for Front.xaml
    /// </summary>
    public partial class FrontView : UserControl
    {
        public ObservableCollection<TransactionListItemViewModel> TransactionsViewModel { get; set; }
        public FrontInformationViewModel FrontInfoViewModel { get; set; }
        public AddTransactionViewModel AddViewModel { get; set; }

        private readonly int frontID;
        private readonly string companySymbol;

        public FrontView(int frontID)
        {
            this.frontID = frontID;
            InitializeComponent();

            List<string> transactionTypes = new List<string>();
            transactionTypes.Add("Buy");
            transactionTypes.Add("Sell");

            TransactionTypeCombo.ItemsSource = transactionTypes;

            var transactionRepository = Global.Kernel.Get<ITransactionRepository>();
            var frontRepository = Global.Kernel.Get<IFrontRepository>();

            var front = frontRepository.GetById(frontID);

            companySymbol = front.Company.Symbol;

            FrontInfoViewModel = new FrontInformationViewModel(front);

            FrontInformations.DataContext = FrontInfoViewModel;

            TransactionsViewModel = new ObservableCollection<TransactionListItemViewModel>(transactionRepository.Where(t => t.FrontID == frontID)
                .OrderBy(t => t.Date)
                .Select(t => new TransactionListItemViewModel()
                {
                    Amount = t.Amount,
                    Commision = t.Commision,
                    Price = t.Price,
                    TransactionType = (TransactionTypeEnum)t.TypeID,
                    Profit = t.Total.Value,
                    Date = t.Date
                }).ToList());

            TransactionList.ItemsSource = TransactionsViewModel;
            NewTransaction.DataContext = AddViewModel = new AddTransactionViewModel();

            GetInformationAboutFront().RunAsync();
        }

        public async Task GetInformationAboutFront()
        {
            try
            {
                var bankierService = Global.Kernel.Get<IBankierConnection>();
                var data = await bankierService.GetData(companySymbol, true, true);



                lock (FrontInfoViewModel)
                {
                    FrontInfoViewModel.HoldedPrice = (decimal)data.ActualPrice;
                }
            }
            catch (Exception)
            {
                int a = 5;
                //:(
            }
          
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (AddViewModel.Price.HasValue == false || AddViewModel.Price <= 0 ||
                AddViewModel.Amount.HasValue == false || AddViewModel.Amount <= 0)
            {
                MessageBox.Show("Wrong values", "Wrong values");
                return;
            }

            var transaction = new Transaction()
            {
                Amount = (int)AddViewModel.Amount,
                Commision = AddViewModel.Comission,
                Date = AddViewModel.Date,
                FrontID = frontID,
                Price = (decimal)AddViewModel.Price,
                TypeID = (int)AddViewModel.TransactionTypeEnum
            };

            var repo = Global.Kernel.Get<ITransactionRepository>();
            repo.Add(transaction);
            repo.SaveChanges();

            TransactionsViewModel.Add(new TransactionListItemViewModel()
            {
                Amount = transaction.Amount,
                Commision = transaction.Commision,
                Price = transaction.Price,
                TransactionType = (TransactionTypeEnum)transaction.TypeID,
                Profit = transaction.Total.Value,
                Date = transaction.Date
            });

            NewTransaction.DataContext = AddViewModel = new AddTransactionViewModel();
        }
    }
}
