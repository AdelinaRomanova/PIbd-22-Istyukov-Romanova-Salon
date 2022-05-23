using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BindingModels;
using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalonViewClient
{
	public partial class FormRegistration : Form
	{
		public int Id { set { id = value; } }
		private readonly ClientLogic _clientLogic;
		private int? id;

		public FormRegistration(ClientLogic clientLogic)
		{
			InitializeComponent();
			this._clientLogic = clientLogic;
		}
        private void FormRegistration_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _clientLogic.Read(new ClientBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ClientName;
                        textBoxSurname.Text = view.ClientSurname;
                        textBoxPatronymic.Text = view.Patronymic;
                        textBoxEmail.Text = view.Email;
                        textBoxPassword.Text = view.Password;
                        textBoxPhone.Text = view.Phone;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSurname.Text))
            {
                MessageBox.Show("Заполните фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _clientLogic.CreateOrUpdate(new ClientBindingModel
                {
                    ClientName = textBoxName.Text,
                    ClientSurname = textBoxSurname.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text,
                    Phone = textBoxPhone.Text
                });
                MessageBox.Show("Регистрация прошла успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
