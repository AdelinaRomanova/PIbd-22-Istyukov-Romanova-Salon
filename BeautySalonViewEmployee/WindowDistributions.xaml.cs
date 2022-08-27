﻿using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using BeautySalonContracts.ViewModels;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace BeautySalonViewEmployee
{
    /// <summary>
    /// Логика взаимодействия для WindowDistributions.xaml
    /// </summary>
    public partial class WindowDistributions : Window
    {
        public int Id { set { id = value; } }

        private int? id;

        private readonly IDistributionLogic _logic;

        public WindowDistributions(IDistributionLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void WindowDistributions_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new DistributionBindingModel { EmployeeId = id });
                if (list != null)
                {
                    dataGrid.ItemsSource = list;
                    dataGrid.Columns[1].Visibility = Visibility.Hidden;
                    dataGrid.Columns[2].Visibility = Visibility.Hidden;
                    dataGrid.Columns[4].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = App.Container.Resolve<WindowDistribution>();
            window.EmployeeId = (int)id;
            if (window.ShowDialog().Value)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedCells.Count != 0)
            {
                var window = App.Container.Resolve<WindowDistribution>();
                window.Id = ((DistributionViewModel)dataGrid.SelectedCells[0].Item).Id;
                window.EmployeeId = (int)id;
                if (window.ShowDialog().Value)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedCells.Count != 0)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((DistributionViewModel)dataGrid.SelectedCells[0].Item).Id;
                    try
                    {
                        _logic.Delete(new DistributionBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void buttonLinking_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedCells.Count != 0)
            {
                var window = App.Container.Resolve<WindowLinkingDistribution>();
                window.EmployeeId = (int)id;
                window.DistributionId = ((DistributionViewModel)dataGrid.SelectedCells[0].Item).Id;
                if (window.ShowDialog().Value)
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Данные для привязки DisplayName к названиям столбцов
        /// </summary>
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
        }

        /// <summary>
        /// метод привязки DisplayName к названию столбца
        /// </summary>
        public static string GetPropertyDisplayName(object descriptor)
        {
            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                DisplayNameAttribute displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }
            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }
    }
}
