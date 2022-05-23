using BeautySalonBusinessLogic.BusinessLogics;
using BeautySalonContracts.BindingModels;
using System;
using System.Windows.Forms;
using Unity;

namespace BeautySalonViewClient
{
	public partial class FormMain : Form
	{
		public int Id { set { id = value; } }
		private int? id;
		private ClientLogic logic;
		public FormMain(ClientLogic logic)
		{
			InitializeComponent();
			this.logic = logic;
		}

        private void процедурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormProcedures>();
			form.Id = (int)id;
			form.ShowDialog();
		}

        private void покупкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormPurchases>();
			form.ShowDialog();
		}

        private void посещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormVisits>();
			form.ShowDialog();
		}

        private void привязатьКчекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormBindingReceipt>();
			form.ShowDialog();
		}

        private void списоквыдачToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormDistributionList>();
			form.ShowDialog();
		}

        private void отчётПоПроцедурамToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormReportProcedures>();
			form.ShowDialog();
		}

        private void FormMain_Load(object sender, EventArgs e)
        {
			var client = logic.Read(new ClientBindingModel { Id = id })?[0];
			labelClient.Text = "Клиент: " + client.ClientName + " " + client.ClientSurname;
		}
    }
}
