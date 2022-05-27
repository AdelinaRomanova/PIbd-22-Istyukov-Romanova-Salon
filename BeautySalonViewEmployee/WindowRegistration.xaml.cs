using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public int Id { set { id = value; } }

        private readonly IEmployeeLogic _logic;

        private int? id;

        public WindowRegistration(IEmployeeLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void WindowRegistration_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new EmployeeBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        TextBoxEmployeeName.Text = view.EmployeeName;
                        TextBoxEmployeeSurname.Text = view.EmployeeSurname;
                        TextBoxLogin.Text = view.Login;
                        TextBoxPassword.Text = view.Password;
                        TextBoxPhone.Text = view.Phone;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxEmployeeName.Text))
            {
                MessageBox.Show("Заполните фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxEmployeeSurname.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPhone.Text))
            {
                MessageBox.Show("Заполните номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    EmployeeName = TextBoxEmployeeName.Text,
                    EmployeeSurname = TextBoxEmployeeSurname.Text,
                    Login = TextBoxLogin.Text,
                    Password = TextBoxPassword.Text,
                    Phone = TextBoxPhone.Text
                });
                MessageBox.Show("Решистрация прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
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
