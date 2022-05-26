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
    public partial class FormPurchaseList : Form
    {
        public FormPurchaseList()
        {
            InitializeComponent();
        }

        private void FormPurchaseList_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSelectionCosmeticsForPurchaseList>();
            form.ShowDialog();
            /*window.EmployeeId = (int)id;
            if (window.ShowDialog().Value)
            {
                if (purchaseCosmetics.ContainsKey(window.Id))
                {
                    purchaseCosmetics[window.Id] = window.CosmeticName;
                }
                else
                {
                    purchaseCosmetics.Add(window.Id, window.CosmeticName);
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

        private void buttonWord_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
