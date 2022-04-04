using BeautySalonContracts.BindingModels;
using BeautySalonContracts.BusinessLogicsContracts;
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
    public partial class FormProcedure : Form
    {
        public int Id { set { id = value; } }
        private readonly IProcedureLogic _logic;
        private int? id;
        public int ClientId { set { clientId = value; } }
        private int? clientId;
        public FormProcedure(IProcedureLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormProcedure_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new ProcedureBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxProcedureName.Text = view.ProcedureName;
                        textBoxFIOmaster.Text = view.FIO_Master;
                        textBoxDuration.Text = view.Duration.ToString();
                        textBoxPrice.Text = view.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProcedureName.Text))
            {
                MessageBox.Show("Заполните название процедуры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFIOmaster.Text))
            {
                MessageBox.Show("Заполните ФИО мастера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDuration.Text))
            {
                MessageBox.Show("Заполните продолжительность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ProcedureBindingModel
                {
                    Id = id,
                    ProcedureName = textBoxProcedureName.Text,
                    FIO_Master = textBoxFIOmaster.Text,
                    Duration = Convert.ToInt32(textBoxDuration.Text),
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ClientId = clientId
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
