using Common.WPF.Controls;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static event Action<object, string> createNewTabEvent;
        public MainWindow()
        {
            InitializeComponent();

            CreateFront.NewFrontCreatedEvent += OnNewFrontCreation;
            createNewTabEvent += createNewTab;

        }

        private void OnNewFrontCreation(MoneyBack.Front front)
        {
            createNewTab(new FrontView(front.ID), "[Front]" + front.Name);
        }

        public static void CreateNewTab(object obj, string header)
        {
            createNewTabEvent(obj, header);
        }

        private void createNewTab(object obj, string header)
        {
            var tab = new ClosableTab();
            tab.Title = header;

            tab.Content = obj;
            Tabs.Items.Add(tab);
            Tabs.SelectedItem = tab;
        }

        private void OpenCompanies(object sender, RoutedEventArgs e)
        {
            createNewTab(new CompanyList(), "Companies");
        }

        private void OpenAllFronts(object sender, RoutedEventArgs e)
        {
            createNewTab(new AllFrontView(), "Fronts");
        }

    }
}
