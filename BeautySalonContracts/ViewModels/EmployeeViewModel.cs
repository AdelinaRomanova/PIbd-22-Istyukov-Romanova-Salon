using System.ComponentModel;

namespace BeautySalonContracts.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string EmployeeName { get; set; }
        [DisplayName("Фамилия")]
        public string EmployeeSurname { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Почта")]
        public string Email { get; set; }
        [DisplayName("Сотовый телефон")]
        public string Phone { get; set; }
    }
}
