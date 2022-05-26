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
    public partial class FormDistribution : Form
    {
        public FormDistribution()
        {
            InitializeComponent();
        }

        private void FormDistribution_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSelectionCosmetics>();
            form.ShowDialog();
            /*window.EmployeeId = (int)employeeId;
            if (window.ShowDialog().Value)
            {
                if (distributionCosmetics.ContainsKey(window.Id))
                {
                    distributionCosmetics[window.Id] = (window.CosmeticName, window.Count);
                }
                else
                {
                    distributionCosmetics.Add(window.Id, (window.CosmeticName, window.Count));
                }
                LoadData();
            } */
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
