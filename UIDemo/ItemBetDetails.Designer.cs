namespace Demo
{
    partial class ItemBetDetails
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbIndex = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit1;
            this.panel1.Controls.Add(this.lbIndex);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 0;
            // 
            // lbIndex
            // 
            this.lbIndex.AutoSize = true;
            this.lbIndex.BackColor = System.Drawing.Color.Transparent;
            this.lbIndex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIndex.ForeColor = System.Drawing.Color.White;
            this.lbIndex.Location = new System.Drawing.Point(3, -1);
            this.lbIndex.Name = "lbIndex";
            this.lbIndex.Size = new System.Drawing.Size(15, 17);
            this.lbIndex.TabIndex = 0;
            this.lbIndex.Text = "1";
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetails.Enabled = false;
            this.txtDetails.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDetails.Location = new System.Drawing.Point(23, 0);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(256, 23);
            this.txtDetails.TabIndex = 1;
            this.txtDetails.TextChanged += new System.EventHandler(this.txtDetails_TextChanged);
            // 
            // ItemBetDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.panel1);
            this.Name = "ItemBetDetails";
            this.Size = new System.Drawing.Size(296, 23);
            this.Load += new System.EventHandler(this.ItemBetDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbIndex;
        private System.Windows.Forms.TextBox txtDetails;
    }
}
