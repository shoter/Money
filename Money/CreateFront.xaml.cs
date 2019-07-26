using Money.ViewModels.Companies;
using Money.ViewModels.Fronts;
using MoneyBack;
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
using System.Windows.Shapes;

namespace Money
{
    /// <summary>
    /// Interaction logic for CreateFront.xaml
    /// </summary>
    public partial class CreateFront : Window
    {
        public static event Action<Front> NewFrontCreatedEvent;

        private CreateFrontViewModel vm;
        public CreateFront(CompanyListItemViewModel item)
        {
            InitializeComponent();

            DataContext = vm = new CreateFrontViewModel(item);
        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            var frontRepository = Global.Kernel.Get<IFrontRepository>();

            var front = new Front()
            {
                CompanyID = vm.CompanyID,
                Name = vm.Name,
                StartDate = vm.StartDate
            };

            frontRepository.Add(front);
            frontRepository.SaveChanges();

            NewFrontCreatedEvent?.Invoke(front);

            //Open tab with front.

            this.Close();
        }
    }
}
