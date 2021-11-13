using Common.Commands;
using Money.ViewModels.Companies;
using MoneyBack.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CompanyList.xaml
    /// </summary>
    public partial class CompanyList : UserControl
    {
        private List<CompanyListItemViewModel> Companies;
        private List<CompanyListItemViewModel> Filtered;
        public CompanyList()
        {
            InitializeComponent();

            LoadCompanies();

            CreateNewFront  = new ActionCommand<CompanyListItemViewModel>(canExecuteDelegate: null, executeDelegate: createNewFront);
        }

        public void LoadCompanies()
        {
            var companyRepository = Global.Kernel.Get<ICompanyRepository>();

            Companies = companyRepository.GetAll()
                .Select(c => new CompanyListItemViewModel()
                {
                    ID = c.ID,
                    Name = c.Name,
                    Symbol = c.Symbol,
                    FrontsCount = c.Fronts.Count,
                    StockPriceType = c.StockPriceType
                }).ToList();

            Filtered = Companies;
            CompanyDataGrid.ItemsSource = Filtered;

        }
    
        private void Refresh(object sender, RoutedEventArgs e)
        {
            LoadCompanies();
        }

        private void createNewFront(CompanyListItemViewModel item)
        {
            var window = new CreateFront(item);
            window.ShowDialog();
            LoadCompanies();
        }
        private static void showCompany(CompanyListItemViewModel item)
        {
            MainWindow.CreateNewTab(new CompanyInfo(item.ID, item.StockPriceType), "[Company]" + item.Symbol);

        }

        public static ICommand CreateNewFront { get; set; } 
        public static ICommand ShowCompany { get; set; } = new ActionCommand<CompanyListItemViewModel>(canExecuteDelegate: null, executeDelegate: showCompany);
    }
}
