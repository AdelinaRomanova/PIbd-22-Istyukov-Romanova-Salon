using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BeautySaloonViewEmployee
{
    public partial class FormDistributions : Form
    {
        public FormDistributions()
        {
            InitializeComponent();
        }

        private void FormDistributions_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormDistribution>();
            form.ShowDialog();
            //form.EmployeeId = (int)id;
            //if (form.ShowDialog().Value)
            //{
            //    LoadData();
            //}
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void buttonLinking_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormLinkingDistribution>();
            form.ShowDialog();
        }
    }
}
