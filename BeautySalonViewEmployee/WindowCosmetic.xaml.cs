using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowCosmetic.xaml
    /// </summary>
    public partial class WindowCosmetic : Window
    {
        public int Id { set { id = value; } }

        public int EmployeeId { set { employeeId = value; } }

        private readonly ICosmeticLogic _logic;

        private int? id;

        private int? employeeId;

        public WindowCosmetic(ICosmeticLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void WindowCosmetic_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new CosmeticBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        TextBoxName.Text = view.CosmeticName;
                        TextBoxPrice.Text = view.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPrice.Text))
            {
                MessageBox.Show("Заполните стоимость", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CosmeticBindingModel
                {
                    Id = id,
                    CosmeticName = TextBoxName.Text,
                    Price = Convert.ToDecimal(TextBoxPrice.Text),
                    EmployeeId = employeeId
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
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
    }
}
