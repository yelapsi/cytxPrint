namespace Demo
{
    partial class FrmInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInit));
            this.title = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDataKeepTime = new System.Windows.Forms.ComboBox();
            this.chIsAutoFeedback = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateSysParam = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.cBoxServer = new System.Windows.Forms.ComboBox();
            this.cbPrintType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPrinterModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(4, 2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(126, 25);
            this.title.TabIndex = 0;
            this.title.Text = "系统初始参数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(20, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "服务器：";
            // 
            // cbLocation
            // 
            this.cbLocation.BackColor = System.Drawing.Color.White;
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLocation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(87, 103);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(146, 25);
            this.cbLocation.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "地区选择：";
            // 
            // cbDataKeepTime
            // 
            this.cbDataKeepTime.BackColor = System.Drawing.Color.White;
            this.cbDataKeepTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataKeepTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDataKeepTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDataKeepTime.FormattingEnabled = true;
            this.cbDataKeepTime.Location = new System.Drawing.Point(87, 147);
            this.cbDataKeepTime.Name = "cbDataKeepTime";
            this.cbDataKeepTime.Size = new System.Drawing.Size(146, 25);
            this.cbDataKeepTime.TabIndex = 20;
            // 
            // chIsAutoFeedback
            // 
            this.chIsAutoFeedback.AutoSize = true;
            this.chIsAutoFeedback.BackColor = System.Drawing.Color.Transparent;
            this.chIsAutoFeedback.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chIsAutoFeedback.Location = new System.Drawing.Point(257, 146);
            this.chIsAutoFeedback.Name = "chIsAutoFeedback";
            this.chIsAutoFeedback.Size = new System.Drawing.Size(168, 16);
            this.chIsAutoFeedback.TabIndex = 15;
            this.chIsAutoFeedback.Text = "自动向服务器回馈出票结果";
            this.chIsAutoFeedback.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据保存：";
            // 
            // btnUpdateSysParam
            // 
            this.btnUpdateSysParam.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateSysParam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateSysParam.BackgroundImage")));
            this.btnUpdateSysParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSysParam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateSysParam.FlatAppearance.BorderSize = 0;
            this.btnUpdateSysParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSysParam.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateSysParam.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSysParam.Location = new System.Drawing.Point(362, 195);
            this.btnUpdateSysParam.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdateSysParam.Name = "btnUpdateSysParam";
            this.btnUpdateSysParam.Size = new System.Drawing.Size(83, 24);
            this.btnUpdateSysParam.TabIndex = 35;
            this.btnUpdateSysParam.UseVisualStyleBackColor = false;
            this.btnUpdateSysParam.Click += new System.EventHandler(this.btnUpdateSysParam_Click);
            this.btnUpdateSysParam.MouseEnter += new System.EventHandler(this.btnUpdateSysParam_MouseEnter);
            this.btnUpdateSysParam.MouseLeave += new System.EventHandler(this.btnUpdateSysParam_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = global::Demo.Properties.Resources.btnClose;
            this.picClose.Location = new System.Drawing.Point(453, 4);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(19, 19);
            this.picClose.TabIndex = 36;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // cBoxServer
            // 
            this.cBoxServer.BackColor = System.Drawing.Color.White;
            this.cBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBoxServer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxServer.FormattingEnabled = true;
            this.cBoxServer.Location = new System.Drawing.Point(87, 62);
            this.cBoxServer.Name = "cBoxServer";
            this.cBoxServer.Size = new System.Drawing.Size(146, 25);
            this.cBoxServer.TabIndex = 23;
            // 
            // cbPrintType
            // 
            this.cbPrintType.BackColor = System.Drawing.Color.White;
            this.cbPrintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPrintType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPrintType.FormattingEnabled = true;
            this.cbPrintType.Location = new System.Drawing.Point(330, 62);
            this.cbPrintType.Name = "cbPrintType";
            this.cbPrintType.Size = new System.Drawing.Size(119, 25);
            this.cbPrintType.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(257, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "打印方式：";
            // 
            // cbPrinterModel
            // 
            this.cbPrinterModel.BackColor = System.Drawing.Color.White;
            this.cbPrinterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinterModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPrinterModel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPrinterModel.FormattingEnabled = true;
            this.cbPrinterModel.Location = new System.Drawing.Point(330, 102);
            this.cbPrinterModel.Name = "cbPrinterModel";
            this.cbPrinterModel.Size = new System.Drawing.Size(120, 25);
            this.cbPrinterModel.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(255, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "机器型号：";
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Demo.Properties.Resources.updateBackImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(489, 255);
            this.Controls.Add(this.cbPrinterModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPrintType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.cBoxServer);
            this.Controls.Add(this.btnUpdateSysParam);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chIsAutoFeedback);
            this.Controls.Add(this.cbDataKeepTime);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInit";
            this.Load += new System.EventHandler(this.FrmInit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDataKeepTime;
        private System.Windows.Forms.CheckBox chIsAutoFeedback;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateSysParam;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.ComboBox cBoxServer;
        private System.Windows.Forms.ComboBox cbPrintType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPrinterModel;
        private System.Windows.Forms.Label label1;
    }
}