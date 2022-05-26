
namespace BeautySaloonViewEmployee
{
    partial class FormLinkingDistribution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLinkingDistribution));
            this.comboBoxVisit = new System.Windows.Forms.ComboBox();
            this.comboBoxDistribution = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLinking = new System.Windows.Forms.Button();
            this.labelDistribution = new System.Windows.Forms.Label();
            this.labelVisit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxVisit
            // 
            this.comboBoxVisit.FormattingEnabled = true;
            this.comboBoxVisit.Location = new System.Drawing.Point(121, 51);
            this.comboBoxVisit.Name = "comboBoxVisit";
            this.comboBoxVisit.Size = new System.Drawing.Size(227, 23);
            this.comboBoxVisit.TabIndex = 12;
            // 
            // comboBoxDistribution
            // 
            this.comboBoxDistribution.DisplayMember = "Выбранная выдача";
            this.comboBoxDistribution.FormattingEnabled = true;
            this.comboBoxDistribution.Location = new System.Drawing.Point(121, 14);
            this.comboBoxDistribution.Name = "comboBoxDistribution";
            this.comboBoxDistribution.Size = new System.Drawing.Size(227, 23);
            this.comboBoxDistribution.TabIndex = 11;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Pink;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(200, 94);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(123, 37);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLinking
            // 
            this.buttonLinking.BackColor = System.Drawing.Color.Pink;
            this.buttonLinking.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLinking.Location = new System.Drawing.Point(42, 94);
            this.buttonLinking.Name = "buttonLinking";
            this.buttonLinking.Size = new System.Drawing.Size(123, 37);
            this.buttonLinking.TabIndex = 9;
            this.buttonLinking.Text = "Привязать";
            this.buttonLinking.UseVisualStyleBackColor = false;
            this.buttonLinking.Click += new System.EventHandler(this.buttonLinking_Click);
            // 
            // labelDistribution
            // 
            this.labelDistribution.AutoSize = true;
            this.labelDistribution.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDistribution.Location = new System.Drawing.Point(12, 14);
            this.labelDistribution.Name = "labelDistribution";
            this.labelDistribution.Size = new System.Drawing.Size(70, 21);
            this.labelDistribution.TabIndex = 13;
            this.labelDistribution.Text = "Выдача:";
            // 
            // labelVisit
            // 
            this.labelVisit.AutoSize = true;
            this.labelVisit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVisit.Location = new System.Drawing.Point(11, 51);
            this.labelVisit.Name = "labelVisit";
            this.labelVisit.Size = new System.Drawing.Size(104, 21);
            this.labelVisit.TabIndex = 14;
            this.labelVisit.Text = "Посещение:";
            // 
            // FormLinkingDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(360, 140);
            this.Controls.Add(this.labelVisit);
            this.Controls.Add(this.labelDistribution);
            this.Controls.Add(this.comboBoxVisit);
            this.Controls.Add(this.comboBoxDistribution);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLinking);
            this.Name = "FormLinkingDistribution";
            this.Text = "Привязка выдачи";
            this.Load += new System.EventHandler(this.FormLinkingDistribution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVisit;
        private System.Windows.Forms.ComboBox comboBoxDistribution;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLinking;
        private System.Windows.Forms.Label labelDistribution;
        private System.Windows.Forms.Label labelVisit;
    }
}