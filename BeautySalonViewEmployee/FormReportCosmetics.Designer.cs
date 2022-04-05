
namespace BeautySaloonViewEmployee
{
    partial class FormReportCosmetics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportCosmetics));
            this.labelFrom = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.labelReport = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFrom
            // 
            this.labelFrom.Location = new System.Drawing.Point(3, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(26, 26);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "С";
            this.labelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(35, 3);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(142, 23);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelFrom);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerFrom);
            this.flowLayoutPanel1.Controls.Add(this.labelTo);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerTo);
            this.flowLayoutPanel1.Controls.Add(this.buttonMake);
            this.flowLayoutPanel1.Controls.Add(this.buttonToPdf);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 32);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // labelTo
            // 
            this.labelTo.Location = new System.Drawing.Point(183, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(26, 26);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "по";
            this.labelTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(215, 3);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(142, 23);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // buttonMake
            // 
            this.buttonMake.BackColor = System.Drawing.Color.White;
            this.buttonMake.Location = new System.Drawing.Point(363, 3);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(75, 23);
            this.buttonMake.TabIndex = 4;
            this.buttonMake.Text = "Показать";
            this.buttonMake.UseVisualStyleBackColor = false;
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.BackColor = System.Drawing.Color.White;
            this.buttonToPdf.Location = new System.Drawing.Point(444, 3);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(75, 23);
            this.buttonToPdf.TabIndex = 5;
            this.buttonToPdf.Text = "На почту";
            this.buttonToPdf.UseVisualStyleBackColor = false;
            // 
            // labelReport
            // 
            this.labelReport.BackColor = System.Drawing.Color.White;
            this.labelReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelReport.Location = new System.Drawing.Point(4, 36);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(526, 345);
            this.labelReport.TabIndex = 4;
            this.labelReport.Text = "Таблица для показа отчёта";
            this.labelReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormReportCosmetics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(534, 386);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelReport);
            this.Name = "FormReportCosmetics";
            this.Text = "Учёт косметики";
            this.Load += new System.EventHandler(this.FormReportCosmetics_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Label labelReport;
    }
}