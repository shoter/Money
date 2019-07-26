using Common.Commands;
using Common.Tasks;
using Money.ViewModels.Companies;
using Money.ViewModels.Fronts;
using MoneyBack;
using MoneyBack.Bankier;
using MoneyBack.Repositories;
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
    /// Interaction logic for CompanyInfo.xaml
    /// </summary>
    public partial class CompanyInfo : UserControl
    {
        private int companyID;
        private string companySymbol;
        public ObservableCollection<FrontListItemViewModel> Fronts;

        public CompanyInfo(int companyID)
        {
            InitializeComponent();
            this.companyID = companyID;

            var companyRepository = Global.Kernel.Get<ICompanyRepository>();

            var company = companyRepository.GetById(companyID);
            companySymbol = company.Symbol;

            Fronts = new ObservableCollection<FrontListItemViewModel>(company.Fronts
                .ToList()
                .OrderBy(f => f.EndDate)
                .OrderBy(f => f.EndDate.HasValue)
                .Select(f => new FrontListItemViewModel(f)));

            FrontsGrid.ItemsSource = Fronts;

            FrontRepository.NewEntityEvent += NewFrontEvent;
            CompanyInfoPanel.DataContext = new CompanyInfoViewModel(company);
            ShowFront = new ActionCommand<FrontListItemViewModel>(null, showFront);

            GetInformationAboutFront().RunAsync();
        }

        public async Task GetInformationAboutFront()
        {
            try
            {
                var bankierService = Global.Kernel.Get<IBankierConnection>();
                var data = await bankierService.GetData(companySymbol, true, true);



                lock (Fronts)
                {
                    foreach (var front in Fronts)
                        front.HoldedPrice = (decimal)data.ActualPrice;
                }
            }
            catch (Exception e)
            {
                int a = 2;
                //i must log that.
            }
        }

        private void NewFrontEvent(MoneyBack.Front front)
        {
            if (front.CompanyID == companyID)
            {
                Fronts.Add(new FrontListItemViewModel(front));
            }
        }

        private void showFront(FrontListItemViewModel front)
        {
            var view = new FrontView(front.ID);
            MainWindow.CreateNewTab(view, "[Front]" + front.Name);
        }

        public ICommand ShowFront { get; set; }
    }
}
