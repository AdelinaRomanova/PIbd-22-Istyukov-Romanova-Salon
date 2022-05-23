using System.ComponentModel;
using System.Runtime.Serialization;


namespace BeautySalonContracts.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string ClientName { get; set; }
        [DisplayName("Фамилия")]
        public string ClientSurname { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }
        [DisplayName("Почта")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Сотовый телефон")]
        public string Phone { get; set; }
    }
}
