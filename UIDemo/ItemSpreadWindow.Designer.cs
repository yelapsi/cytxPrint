namespace Demo
{
    partial class ItemSpreadWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSpreadWindow));
            this.plBody = new System.Windows.Forms.Panel();
            this.radioBtnWay5 = new System.Windows.Forms.RadioButton();
            this.radioBtnWay3 = new System.Windows.Forms.RadioButton();
            this.radioBtnWay4 = new System.Windows.Forms.RadioButton();
            this.radioBtnWay2 = new System.Windows.Forms.RadioButton();
            this.radioBtnWay1 = new System.Windows.Forms.RadioButton();
            this.updatebtn = new System.Windows.Forms.Button();
            this.plHead = new System.Windows.Forms.Panel();
            this.labErrorTypeMsg = new System.Windows.Forms.Label();
            this.plBody.SuspendLayout();
            this.plHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // plBody
            // 
            this.plBody.BackColor = System.Drawing.Color.White;
            this.plBody.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plBody.BackgroundImage")));
            this.plBody.Controls.Add(this.radioBtnWay5);
            this.plBody.Controls.Add(this.radioBtnWay3);
            this.plBody.Controls.Add(this.radioBtnWay4);
            this.plBody.Controls.Add(this.radioBtnWay2);
            this.plBody.Controls.Add(this.radioBtnWay1);
            this.plBody.Controls.Add(this.updatebtn);
            this.plBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBody.Location = new System.Drawing.Point(0, 34);
            this.plBody.Name = "plBody";
            this.plBody.Size = new System.Drawing.Size(728, 169);
            this.plBody.TabIndex = 1;
            // 
            // radioBtnWay5
            // 
            this.radioBtnWay5.AutoSize = true;
            this.radioBtnWay5.BackColor = System.Drawing.Color.Transparent;
            this.radioBtnWay5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWay5.Location = new System.Drawing.Point(46, 136);
            this.radioBtnWay5.Name = "radioBtnWay5";
            this.radioBtnWay5.Size = new System.Drawing.Size(327, 24);
            this.radioBtnWay5.TabIndex = 19;
            this.radioBtnWay5.TabStop = true;
            this.radioBtnWay5.Text = "5、(弹出提示)等待手工选择，30s后默认按2处理";
            this.radioBtnWay5.UseVisualStyleBackColor = false;
            // 
            // radioBtnWay3
            // 
            this.radioBtnWay3.AutoSize = true;
            this.radioBtnWay3.BackColor = System.Drawing.Color.Transparent;
            this.radioBtnWay3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWay3.Location = new System.Drawing.Point(46, 72);
            this.radioBtnWay3.Name = "radioBtnWay3";
            this.radioBtnWay3.Size = new System.Drawing.Size(199, 24);
            this.radioBtnWay3.TabIndex = 18;
            this.radioBtnWay3.TabStop = true;
            this.radioBtnWay3.Text = "3、(弹出提示)等待手工选择";
            this.radioBtnWay3.UseVisualStyleBackColor = false;
            // 
            // radioBtnWay4
            // 
            this.radioBtnWay4.AutoSize = true;
            this.radioBtnWay4.BackColor = System.Drawing.Color.Transparent;
            this.radioBtnWay4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWay4.Location = new System.Drawing.Point(46, 104);
            this.radioBtnWay4.Name = "radioBtnWay4";
            this.radioBtnWay4.Size = new System.Drawing.Size(327, 24);
            this.radioBtnWay4.TabIndex = 17;
            this.radioBtnWay4.TabStop = true;
            this.radioBtnWay4.Text = "4、(弹出提示)等待手工选择，30s后默认按1处理";
            this.radioBtnWay4.UseVisualStyleBackColor = false;
            // 
            // radioBtnWay2
            // 
            this.radioBtnWay2.AutoSize = true;
            this.radioBtnWay2.BackColor = System.Drawing.Color.Transparent;
            this.radioBtnWay2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWay2.Location = new System.Drawing.Point(46, 40);
            this.radioBtnWay2.Name = "radioBtnWay2";
            this.radioBtnWay2.Size = new System.Drawing.Size(437, 24);
            this.radioBtnWay2.TabIndex = 16;
            this.radioBtnWay2.TabStop = true;
            this.radioBtnWay2.Text = "2、(自动处理)把票置为错漏票，继续出票，到错漏票模块进行处理";
            this.radioBtnWay2.UseVisualStyleBackColor = false;
            // 
            // radioBtnWay1
            // 
            this.radioBtnWay1.AutoSize = true;
            this.radioBtnWay1.BackColor = System.Drawing.Color.Transparent;
            this.radioBtnWay1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnWay1.Location = new System.Drawing.Point(46, 8);
            this.radioBtnWay1.Name = "radioBtnWay1";
            this.radioBtnWay1.Size = new System.Drawing.Size(311, 24);
            this.radioBtnWay1.TabIndex = 15;
            this.radioBtnWay1.TabStop = true;
            this.radioBtnWay1.Text = "1、(自动处理)把票置为错漏票，然后停止出票";
            this.radioBtnWay1.UseVisualStyleBackColor = false;
            // 
            // updatebtn
            // 
            this.updatebtn.BackColor = System.Drawing.Color.Transparent;
            this.updatebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updatebtn.BackgroundImage")));
            this.updatebtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.updatebtn.FlatAppearance.BorderSize = 0;
            this.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(618, 127);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(83, 24);
            this.updatebtn.TabIndex = 13;
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            this.updatebtn.MouseEnter += new System.EventHandler(this.updatebtn_MouseEnter);
            this.updatebtn.MouseLeave += new System.EventHandler(this.updatebtn_MouseLeave);
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.White;
            this.plHead.BackgroundImage = global::Demo.Properties.Resources.SpreadWindowOpen;
            this.plHead.Controls.Add(this.labErrorTypeMsg);
            this.plHead.Cursor = System.Windows.Forms.Cursors.Default;
            this.plHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(728, 34);
            this.plHead.TabIndex = 0;
            // 
            // labErrorTypeMsg
            // 
            this.labErrorTypeMsg.AutoSize = true;
            this.labErrorTypeMsg.BackColor = System.Drawing.Color.Transparent;
            this.labErrorTypeMsg.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErrorTypeMsg.ForeColor = System.Drawing.Color.DimGray;
            this.labErrorTypeMsg.Location = new System.Drawing.Point(41, 7);
            this.labErrorTypeMsg.Name = "labErrorTypeMsg";
            this.labErrorTypeMsg.Size = new System.Drawing.Size(234, 20);
            this.labErrorTypeMsg.TabIndex = 14;
            this.labErrorTypeMsg.Text = "向硬件发送出票数据时出现错误：";
            // 
            // ItemSpreadWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.plHead);
            this.Name = "ItemSpreadWindow";
            this.Size = new System.Drawing.Size(728, 203);
            this.Load += new System.EventHandler(this.ItemSpreadWindow_Load);
            this.plBody.ResumeLayout(false);
            this.plBody.PerformLayout();
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.Panel plBody;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Label labErrorTypeMsg;
        private System.Windows.Forms.RadioButton radioBtnWay5;
        private System.Windows.Forms.RadioButton radioBtnWay3;
        private System.Windows.Forms.RadioButton radioBtnWay4;
        private System.Windows.Forms.RadioButton radioBtnWay2;
        private System.Windows.Forms.RadioButton radioBtnWay1;
    }
}
