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

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CosmeticMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var window = Container.Resolve<WindowCosmetics>();
            //window.Id = (int)id;
            //window.ShowDialog();
        }

        private void ReceiptMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var window = Container.Resolve<WindowReceipts>();
            //window.Id = (int)id;
            //window.ShowDialog();
        }

        private void DistributionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var window = Container.Resolve<WindowDistributions>();
            //window.Id = (int)id;
            //window.ShowDialog();
        }

        private void PurchaseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var window = Container.Resolve<WindowPurchaseList>();
            //window.Id = (int)id;
            //window.ShowDialog();
        }

        private void ReportMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //var window = Container.Resolve<WindowReportCosmetics>();
            //window.Id = (int)id;
            //window.ShowDialog();
        }

    }
}
