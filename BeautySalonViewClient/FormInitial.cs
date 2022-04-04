using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonBusinessLogic.OfficePackage;
using System;
using System.Windows.Forms;
using Unity;
using BeautySalonViewClient;

namespace BeautySalonView
{
    public partial class FormInitial : Form
    {
        public FormInitial()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            //var form = Container.Resolve<FormAuthorization>();
            //form.ShowDialog();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {

        }
    }
}
