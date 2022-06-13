namespace Demo
{
    partial class FrmPassEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassEnter));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tBoxPass = new System.Windows.Forms.TextBox();
            this.labTip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = global::Demo.Properties.Resources.xzw;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(323, 46);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(58, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.xzw;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(259, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tBoxPass
            // 
            this.tBoxPass.Location = new System.Drawing.Point(58, 47);
            this.tBoxPass.Name = "tBoxPass";
            this.tBoxPass.PasswordChar = '*';
            this.tBoxPass.Size = new System.Drawing.Size(193, 21);
            this.tBoxPass.TabIndex = 4;
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.BackColor = System.Drawing.Color.Transparent;
            this.labTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.Location = new System.Drawing.Point(11, 9);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(90, 22);
            this.labTip.TabIndex = 5;
            this.labTip.Text = "请输入密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "密码:";
            // 
            // FrmPassEnter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Demo.Properties.Resources.tanchuk;
            this.ClientSize = new System.Drawing.Size(388, 83);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labTip);
            this.Controls.Add(this.tBoxPass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPassEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请输入密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tBoxPass;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Label label1;
    }
}