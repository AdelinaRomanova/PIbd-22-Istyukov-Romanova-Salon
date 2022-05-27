using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowLinkingDistribution.xaml
    /// </summary>
    public partial class WindowLinkingDistribution : Window
    {
        public int VisitId { get { return (int)(ComboBoxVisit.SelectedItem as VisitViewModel).Id; } }

        public int DistributionId { get { return (ComboBoxDistribution.SelectedItem as DistributionViewModel).Id; } set { distributionId = value; } }

        public int EmployeeId { set { employeeId = value; } }

        private int? distributionId;

        private int? employeeId;

        private readonly IVisitLogic _logicVisit;

        private readonly IDistributionLogic _logicDistribution;

        public WindowLinkingDistribution(IVisitLogic logicVisit, IDistributionLogic logicDistribution)
        {
            InitializeComponent();
            this._logicDistribution = logicDistribution;
            this._logicVisit = logicVisit;
        }

        private void WindowLinkingDistribution_Loaded(object sender, RoutedEventArgs e)
        {
            var listVisit = _logicVisit.Read(null);
            if (listVisit != null)
            {
                ComboBoxVisit.ItemsSource = listVisit;
            }
            var listDistribution = _logicDistribution.Read(new DistributionBindingModel { EmployeeId = employeeId });
            if (listDistribution != null)
            {
                ComboBoxDistribution.ItemsSource = listDistribution;
            }
            if (distributionId != null)
            {
                ComboBoxDistribution.SelectedItem = SetValueDistribution(distributionId.Value);
            }
        }

        private void buttonLinking_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxVisit.SelectedValue == null)
            {
                MessageBox.Show("Выберите посещение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComboBoxDistribution.SelectedValue == null)
            {
                MessageBox.Show("Выберите выдачу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logicDistribution.Linking(new DistributionLinkingBindingModel
                {
                    VisitId = (int)(ComboBoxVisit.SelectedItem as VisitViewModel).Id,
                    DistributionId = (ComboBoxDistribution.SelectedItem as DistributionViewModel).Id
                });
                MessageBox.Show("Привязка прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private DistributionViewModel SetValueDistribution(int value)
        {
            foreach (var item in ComboBoxDistribution.Items)
            {
                if ((item as DistributionViewModel).Id == value)
                {
                    return item as DistributionViewModel;
                }
            }
            return null;
        }
    }
}
