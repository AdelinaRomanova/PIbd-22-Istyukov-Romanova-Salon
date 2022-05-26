﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

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
                        TextBoxF_Name.Text = view.F_Name;
                        TextBoxL_Name.Text = view.L_Name;
                        TextBoxLogin.Text = view.Login;
                        TextBoxPassword.Text = view.Password;
                        TextBoxPhoneNumber.Text = view.PhoneNumber;
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
            if (string.IsNullOrEmpty(TextBoxF_Name.Text))
            {
                MessageBox.Show("Заполните фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxL_Name.Text))
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
            if (string.IsNullOrEmpty(TextBoxPhoneNumber.Text))
            {
                MessageBox.Show("Заполните номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    F_Name = TextBoxF_Name.Text,
                    L_Name = TextBoxL_Name.Text,
                    Login = TextBoxLogin.Text,
                    Password = TextBoxPassword.Text,
                    PhoneNumber = TextBoxPhoneNumber.Text
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
