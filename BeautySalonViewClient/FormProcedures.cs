using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
using System;
using System.Windows.Forms;
using Unity;

namespace BeautySalonViewClient
{
	public partial class FormProcedures : Form
	{
		private readonly IProcedureLogic _logic;
		public int Id { set { id = value; } }
		private int? id;

		public FormProcedures(IProcedureLogic logic)
		{
			InitializeComponent();
			_logic = logic;
		}
		private void FormProcedures_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				var list = _logic.Read(null);
				if (list != null)
				{
					dataGridViewProcedures.DataSource = list;
					dataGridViewProcedures.Columns[0].Visible = false;
					dataGridViewProcedures.Columns[1].Visible = false;
					dataGridViewProcedures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void buttonAdd_Click(object sender, EventArgs e)
        {
			var form = Program.Container.Resolve<FormProcedure>();
			form.ClientId = (int)id;
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}
        private void buttonUpd_Click(object sender, EventArgs e)
        {
			if (dataGridViewProcedures.SelectedRows.Count == 1)
			{
				var form = Program.Container.Resolve<FormProcedure>();
				form.Id = Convert.ToInt32(dataGridViewProcedures.SelectedRows[0].Cells[0].Value);
				form.ClientId = (int)id;
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
        private void buttonDel_Click(object sender, EventArgs e)
        {
			if (dataGridViewProcedures.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridViewProcedures.SelectedRows[0].Cells[0].Value);
					try
					{
						_logic.Delete(new ProcedureBindingModel { Id = id });
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}
        private void buttonRef_Click(object sender, EventArgs e)
        {
			LoadData();
		}
	}
}
