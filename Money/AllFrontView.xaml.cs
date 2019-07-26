using Common.Commands;
using Common.Tasks;
using Money.ViewModels.Fronts;
using MoneyBack.Bankier;
using MoneyBack.Bankier.Models;
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
    /// Interaction logic for AllFrontView.xaml
    /// </summary>
    public partial class AllFrontView : UserControl
    {
        public ObservableCollection<AllFrontListItemViewModel> Fronts { get; set; } = new ObservableCollection<AllFrontListItemViewModel>();
        public AllFrontView()
        {
            InitializeComponent();

            GetFronts(hideEmpty: false);

            GetInformationAboutFront().RunAsync();

            ShowFront = new ActionCommand<AllFrontListItemViewModel>(null, showFront);
        }

        private void GetFronts(bool hideEmpty)
        {
            Fronts = new ObservableCollection<AllFrontListItemViewModel>();
            var frontRepository = Global.Kernel.Get<IFrontRepository>();

            var fronts = frontRepository.
                 OrderByDescending(f => f.ID)
                 .ToList();


            foreach (var f in fronts)
            {
                var vm = new AllFrontListItemViewModel(f);

                if(hideEmpty == false || vm.HoldedAmount > 0)
                Fronts.Add(vm);
            }



            FrontsGrid.ItemsSource = Fronts;
        }

        public async Task GetInformationAboutFront()
        {
            Dictionary<string, GetDataResponse> companyDatas = new Dictionary<string, GetDataResponse>();

            foreach (var f in Fronts)
            {
                if (f.HoldedAmount == 0)
                    continue;

                string companySymbol = f.CompanyName;
                if (companyDatas.ContainsKey(companySymbol))
                {
                    lock (Fronts)
                        f.HoldedPrice = (decimal)companyDatas[companySymbol].ActualPrice;
                }
                else try
                {
                    var bankierService = Global.Kernel.Get<IBankierConnection>();
                    GetDataResponse data = await bankierService.GetData(companySymbol, true, true);

                    
                    lock (Fronts)
                    {
                           f.HoldedPrice = (decimal)data.ActualPrice;
                    }
                    
                        companyDatas.Add(companySymbol, data);
                }
                catch (Exception e)
                {
                    int a = 2;
                    //i must log that.
                }
            }
        }

        private void showFront(AllFrontListItemViewModel front)
        {
            var view = new FrontView(front.ID);
            MainWindow.CreateNewTab(view, "[Front]" + front.Name);
        }
        public ICommand ShowFront { get; set; }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(sender == HideEmptyFrontCheckbox)
            {
                var checkbox = sender as CheckBox;
                GetFronts(hideEmpty: checkbox.IsChecked == true);
                GetInformationAboutFront().RunAsync();
            }
        }

    }
}
