﻿using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using System;
using System.Windows;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        private readonly IEmployeeLogic _logic;

        public WindowAuthorization(IEmployeeLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
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
            try
            {
                var list = _logic.Read(new EmployeeBindingModel
                {
                    Login = TextBoxLogin.Text,
                    Password = TextBoxPassword.Text
                });
                if (list.Count > 0 && list != null)
                {
                    DialogResult = true;
                    var window = App.Container.Resolve<MainWindow>();
                    window.Id = list[0].Id;
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
