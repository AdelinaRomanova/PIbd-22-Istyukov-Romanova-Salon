using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BindingModels;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace BeautySalonViewClient
{
	public partial class FormAuthorization : Form
	{
		private readonly ClientLogic logic;
        public FormAuthorization(ClientLogic logic)
		{
			InitializeComponent();
			this.logic = logic;
		}

		private void AvtorizationForm_Load(object sender, EventArgs e)
		{

		}

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
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
                var view = logic.Read(new ClientBindingModel
                {
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text
                });
                if (view != null && view.Count > 0)
                {
                    var form = Program.Container.Resolve<FormMain>();
                    form.Id = view[0].Id;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
