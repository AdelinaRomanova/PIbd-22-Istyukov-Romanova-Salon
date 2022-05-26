using System;
using Unity;
using System.Windows.Forms;

namespace BeautySaloonViewEmployee
{
    public partial class FormInitial : Form
    {
        public FormInitial()
        {
            InitializeComponent();
        }

        private void FormInitial_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormAuthorization>();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRegistration>();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
