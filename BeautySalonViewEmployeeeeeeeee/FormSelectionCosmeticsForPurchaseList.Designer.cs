
namespace BeautySaloonViewEmployee
{
    partial class FormSelectionCosmeticsForPurchaseList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectionCosmeticsForPurchaseList));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxCosmeticName = new System.Windows.Forms.ComboBox();
            this.labelCosmeticName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Pink;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(164, 61);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(139, 41);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Pink;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(12, 61);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(139, 41);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxCosmeticName
            // 
            this.comboBoxCosmeticName.FormattingEnabled = true;
            this.comboBoxCosmeticName.Location = new System.Drawing.Point(126, 21);
            this.comboBoxCosmeticName.Name = "comboBoxCosmeticName";
            this.comboBoxCosmeticName.Size = new System.Drawing.Size(177, 23);
            this.comboBoxCosmeticName.TabIndex = 9;
            // 
            // labelCosmeticName
            // 
            this.labelCosmeticName.AutoSize = true;
            this.labelCosmeticName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCosmeticName.Location = new System.Drawing.Point(12, 19);
            this.labelCosmeticName.Name = "labelCosmeticName";
            this.labelCosmeticName.Size = new System.Drawing.Size(96, 21);
            this.labelCosmeticName.TabIndex = 8;
            this.labelCosmeticName.Text = "Косметика:";
            // 
            // FormSelectionCosmeticsForPurchaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(315, 110);
            this.Controls.Add(this.comboBoxCosmeticName);
            this.Controls.Add(this.labelCosmeticName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormSelectionCosmeticsForPurchaseList";
            this.Text = "Выбор косметики";
            this.Load += new System.EventHandler(this.FormSelectionCosmeticsForPurchaseList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxCosmeticName;
        private System.Windows.Forms.Label labelCosmeticName;
    }
}