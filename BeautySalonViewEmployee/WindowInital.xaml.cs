using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowInital.xaml
    /// </summary>
    public partial class WindowInital : Window
    {
        public WindowInital()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowRegistration>();
            window.ShowDialog();
        }

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowAuthorization>();
            window.ShowDialog();
        }
    }
}
