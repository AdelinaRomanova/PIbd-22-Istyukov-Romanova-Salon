using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        private IEmployeeLogic _logic;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var employee = _logic.Read(new EmployeeBindingModel { Id = id })?[0];
            lbl_Employee.Content = "Сотрудник: " + employee.EmployeeName + " " + employee.EmployeeSurname;
        }


        private void CosmeticMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowCosmetics>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void ReceiptMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowReceipts>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void DistributionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowDistributions>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void PurchaseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowPurchaseList>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void ReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowReportCosmetics>();
            window.Id = (int)id;
            window.ShowDialog();
        }
    }
}
