using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowSelectionCosmetics.xaml
    /// </summary>
    public partial class WindowSelectionCosmetics : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { get { return (int)(ComboBoxCosmeticName.SelectedItem as CosmeticViewModel).Id; } set { id = value; } }

        public string CosmeticName { get { return (ComboBoxCosmeticName.SelectedItem as CosmeticViewModel).CosmeticName; } }

        public int Count { get { return Convert.ToInt32(TextBoxCount.Text); } set { TextBoxCount.Text = value.ToString(); } }

        public int EmployeeId { set { employeeId = value; } }

        private int? id;

        private int? employeeId;

        private readonly ICosmeticLogic _logic;

        public WindowSelectionCosmetics(ICosmeticLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void WindowSelectionCosmetics_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _logic.Read(new CosmeticBindingModel { EmployeeId = employeeId });
            if (list != null)
            {
                ComboBoxCosmeticName.ItemsSource = list;
            }
            if (id != null)
            {
                ComboBoxCosmeticName.SelectedItem = SetValue(id.Value);
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComboBoxCosmeticName.SelectedValue == null)
            {
                MessageBox.Show("Выберите косметику", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private CosmeticViewModel SetValue(int value)
        {
            foreach (var item in ComboBoxCosmeticName.Items)
            {
                if ((item as CosmeticViewModel).Id == value)
                {
                    return item as CosmeticViewModel;
                }
            }
            return null;
        }
    }
}
