
namespace BeautySaloonViewEmployee
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.косметикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чекиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.получениеСпискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.рекомендацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.косметикаToolStripMenuItem,
            this.отчётToolStripMenuItem,
            this.чекиToolStripMenuItem,
            this.получениеСпискаToolStripMenuItem,
            this.отчётToolStripMenuItem1,
            this.рекомендацииToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // косметикаToolStripMenuItem
            // 
            this.косметикаToolStripMenuItem.Name = "косметикаToolStripMenuItem";
            this.косметикаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.косметикаToolStripMenuItem.Text = "Косметика";
            this.косметикаToolStripMenuItem.Click += new System.EventHandler(this.косметикаToolStripMenuItem_Click);
            // 
            // отчётToolStripMenuItem
            // 
            this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            this.отчётToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.отчётToolStripMenuItem.Text = "Выдачи";
            this.отчётToolStripMenuItem.Click += new System.EventHandler(this.выдачиToolStripMenuItem_Click);
            // 
            // чекиToolStripMenuItem
            // 
            this.чекиToolStripMenuItem.Name = "чекиToolStripMenuItem";
            this.чекиToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.чекиToolStripMenuItem.Text = "Чеки";
            this.чекиToolStripMenuItem.Click += new System.EventHandler(this.чекиToolStripMenuItem_Click);
            // 
            // получениеСпискаToolStripMenuItem
            // 
            this.получениеСпискаToolStripMenuItem.Name = "получениеСпискаToolStripMenuItem";
            this.получениеСпискаToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.получениеСпискаToolStripMenuItem.Text = "Список покупок";
            this.получениеСпискаToolStripMenuItem.Click += new System.EventHandler(this.получениеСпискаToolStripMenuItem_Click);
            // 
            // отчётToolStripMenuItem1
            // 
            this.отчётToolStripMenuItem1.Name = "отчётToolStripMenuItem1";
            this.отчётToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.отчётToolStripMenuItem1.Text = "Отчёт";
            this.отчётToolStripMenuItem1.Click += new System.EventHandler(this.отчётToolStripMenuItem_Click);
            // 
            // рекомендацииToolStripMenuItem
            // 
            this.рекомендацииToolStripMenuItem.Name = "рекомендацииToolStripMenuItem";
            this.рекомендацииToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.рекомендацииToolStripMenuItem.Text = "Статистика";
            this.рекомендацииToolStripMenuItem.Click += new System.EventHandler(this.рекомендацииToolStripMenuItem_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 27);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(500, 503);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(524, 536);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Салон красоты";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem косметикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чекиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem получениеСпискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem рекомендацииToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}