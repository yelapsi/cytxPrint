namespace Demo
{
    partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.panelBtnArea = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labfrmTitle = new System.Windows.Forms.Label();
            this.labCountdownText = new System.Windows.Forms.Label();
            this.panelBtnArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBtnArea
            // 
            this.panelBtnArea.BackColor = System.Drawing.Color.White;
            this.panelBtnArea.Controls.Add(this.btnCancel);
            this.panelBtnArea.Controls.Add(this.btnOK);
            this.panelBtnArea.Location = new System.Drawing.Point(3, 161);
            this.panelBtnArea.Name = "panelBtnArea";
            this.panelBtnArea.Size = new System.Drawing.Size(398, 37);
            this.panelBtnArea.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.xzw;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(261, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseHover += new System.EventHandler(this.btnCancel_MouseHover);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = global::Demo.Properties.Resources.xzw;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(325, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(58, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnOK.MouseHover += new System.EventHandler(this.btnCancel_MouseHover);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.Location = new System.Drawing.Point(54, 62);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(170, 21);
            this.lbMessage.TabIndex = 11;
            this.lbMessage.Text = "是否要退出出票系统？";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::Demo.Properties.Resources.xinxitb;
            this.pictureBox1.Location = new System.Drawing.Point(15, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labfrmTitle
            // 
            this.labfrmTitle.AutoSize = true;
            this.labfrmTitle.BackColor = System.Drawing.Color.Transparent;
            this.labfrmTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labfrmTitle.ForeColor = System.Drawing.Color.White;
            this.labfrmTitle.Location = new System.Drawing.Point(12, 5);
            this.labfrmTitle.Name = "labfrmTitle";
            this.labfrmTitle.Size = new System.Drawing.Size(42, 21);
            this.labfrmTitle.TabIndex = 9;
            this.labfrmTitle.Text = "提示";
            // 
            // labCountdownText
            // 
            this.labCountdownText.AutoSize = true;
            this.labCountdownText.BackColor = System.Drawing.Color.Transparent;
            this.labCountdownText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCountdownText.Location = new System.Drawing.Point(105, 103);
            this.labCountdownText.Name = "labCountdownText";
            this.labCountdownText.Size = new System.Drawing.Size(0, 21);
            this.labCountdownText.TabIndex = 13;
            // 
            // MsgBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Demo.Properties.Resources.popupWithoutShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(404, 202);
            this.Controls.Add(this.labCountdownText);
            this.Controls.Add(this.panelBtnArea);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labfrmTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsgBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MsgBox";
            this.panelBtnArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBtnArea;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labfrmTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labCountdownText;
    }
}