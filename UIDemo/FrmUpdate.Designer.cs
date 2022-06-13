namespace Demo
{
    partial class FrmUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdate));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbTips = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(63, 73);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(315, 38);
            this.progressBar.TabIndex = 0;
            // 
            // lbTips
            // 
            this.lbTips.AutoSize = true;
            this.lbTips.BackColor = System.Drawing.Color.Transparent;
            this.lbTips.Location = new System.Drawing.Point(66, 47);
            this.lbTips.Name = "lbTips";
            this.lbTips.Size = new System.Drawing.Size(0, 12);
            this.lbTips.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = global::Demo.Properties.Resources.btnUpdateUnfocused;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(93, 150);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 24);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdateAgain_Click);
            this.btnUpdate.MouseEnter += new System.EventHandler(this.btnUpdate_MouseEnter);
            this.btnUpdate.MouseLeave += new System.EventHandler(this.btnUpdate_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.btnCancelUnfocused;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(238, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Demo.Properties.Resources.btnClose;
            this.picClose.Location = new System.Drawing.Point(398, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 19);
            this.picClose.TabIndex = 6;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // FrmUpdate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Demo.Properties.Resources.updateBackImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 221);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbTips);
            this.Controls.Add(this.progressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbTips;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picClose;
    }
}