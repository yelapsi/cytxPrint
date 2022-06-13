namespace Demo
{
    partial class UnitConfigErrorHandlerPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.panelError = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelspread = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.panelError.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "错误处理设置";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.panel2);
            this.panelError.Controls.Add(this.label1);
            this.panelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelError.Location = new System.Drawing.Point(0, 0);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(748, 257);
            this.panelError.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelspread);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 257);
            this.panel2.TabIndex = 11;
            // 
            // panelspread
            // 
            this.panelspread.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelspread.Location = new System.Drawing.Point(0, 38);
            this.panelspread.Name = "panelspread";
            this.panelspread.Size = new System.Drawing.Size(748, 219);
            this.panelspread.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(17, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "错误处理设置";
            // 
            // UnitConfigErrorHandlerPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelError);
            this.Name = "UnitConfigErrorHandlerPage";
            this.Size = new System.Drawing.Size(748, 514);
            this.Load += new System.EventHandler(this.UnitConfigErrorHandlerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelspread;
        private System.Windows.Forms.Label label3;
    }
}
