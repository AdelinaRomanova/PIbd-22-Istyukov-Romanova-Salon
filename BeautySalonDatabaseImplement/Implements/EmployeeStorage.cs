using BeautySalonContracts.BindingModels;
using BeautySalonContracts.StoragesContracts;
using BeautySalonContracts.ViewModels;
using BeautySalonDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautySalonDatabaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using var context = new BeautySalonDatabase();
            return context.Employees.Select(CreateModel).ToList();
        }
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            return context.Employees
                .Where(rec => rec.Login.Contains(model.Login) && rec.Password == model.Password)
                .Select(CreateModel)
                .ToList();
        }
        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new BeautySalonDatabase();
            var employee = context.Employees.FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
            return employee != null ? CreateModel(employee) : null;
        }
        public void Insert(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            context.Employees.Add(CreateModel(model, new Employee()));
            context.SaveChanges();
        }
        public void Update(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Сотрудник не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(EmployeeBindingModel model)
        {
            using var context = new BeautySalonDatabase();
            Employee element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Employees.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Сотрудник не найден");
            }
        }
        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.EmployeeName = model.EmployeeName;
            employee.EmployeeSurname = model.EmployeeSurname;
            employee.Patronymic = model.Patronymic;
            employee.Login = model.Login;
            employee.Password = model.Password;
            employee.Email = model.Email;
            employee.Phone = model.Phone;
            return employee;
        }
        private static EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
                EmployeeSurname = employee.EmployeeSurname,
                Patronymic = employee.Patronymic,
                Login = employee.Login,
                Password = employee.Password,
                Email = employee.Email,
                Phone = employee.Phone 
            };
        }
    }
}
