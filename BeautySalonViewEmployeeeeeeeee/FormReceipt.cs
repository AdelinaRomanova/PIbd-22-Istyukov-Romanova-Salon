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
    public partial class FormReceipt : Form
    {
        public FormReceipt()
        {
            InitializeComponent();
        }

        private void FormReceipt_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSelectionCosmetics>();
            form.ShowDialog();
            /*window.EmployeeId = (int)employeeId;
            if (window.ShowDialog().Value)
            {
                if (receiptCosmetics.ContainsKey(window.Id))
                {
                    receiptCosmetics[window.Id] = (window.CosmeticName, window.Count);
                }
                else
                {
                    receiptCosmetics.Add(window.Id, (window.CosmeticName, window.Count));
                }
                LoadData();
                CalcTotalCost();
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
    }
}
