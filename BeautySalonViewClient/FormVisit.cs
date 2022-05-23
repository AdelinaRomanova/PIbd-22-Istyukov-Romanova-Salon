using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BindingModels;
using System;
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
	public partial class FormVisit : Form
	{
        public int Id { set { id = value; } }
        public int ClientId { set { clientId = value; } }
        private readonly VisitLogic logic;
        private int? id;
        private int? clientId;
        private Dictionary<int, string> visitsProcedures;
        private DateTime oldDate = DateTime.MinValue;
        public FormVisit(VisitLogic logic)
		{
			InitializeComponent();
            this.logic = logic;
        }

        private void LoadData()
        {
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

        }

        private void buttonRef_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void FormVisit_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new VisitBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        visitCalendar.Text = view.Date.ToString();
                        visitCalendar.Text = view.Date.ToString();
                        oldDate = view.Date;
                        visitsProcedures = view.VisitProcedures;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
