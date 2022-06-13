namespace Demo
{
    partial class ItemTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemTicket));
            this.plMiddle = new System.Windows.Forms.Panel();
            this.picIsWaiting = new System.Windows.Forms.PictureBox();
            this.lbDetails2 = new System.Windows.Forms.Label();
            this.plBottom = new System.Windows.Forms.Panel();
            this.plTop = new System.Windows.Forms.Panel();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbIndex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBetTag = new System.Windows.Forms.Label();
            this.lbBet = new System.Windows.Forms.Label();
            this.lbDetails = new System.Windows.Forms.Label();
            this.lbMultipleTag = new System.Windows.Forms.Label();
            this.lbMultiple = new System.Windows.Forms.Label();
            this.plMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIsWaiting)).BeginInit();
            this.plTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMiddle
            // 
            this.plMiddle.BackColor = System.Drawing.Color.Transparent;
            this.plMiddle.BackgroundImage = global::Demo.Properties.Resources.printingTicketMiddle;
            this.plMiddle.Controls.Add(this.picIsWaiting);
            this.plMiddle.Controls.Add(this.lbDetails2);
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(0, 32);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(646, 36);
            this.plMiddle.TabIndex = 34;
            // 
            // picIsWaiting
            // 
            this.picIsWaiting.Image = global::Demo.Properties.Resources.waiting;
            this.picIsWaiting.Location = new System.Drawing.Point(565, 0);
            this.picIsWaiting.Name = "picIsWaiting";
            this.picIsWaiting.Size = new System.Drawing.Size(35, 35);
            this.picIsWaiting.TabIndex = 32;
            this.picIsWaiting.TabStop = false;
            this.picIsWaiting.Visible = false;
            // 
            // lbDetails2
            // 
            this.lbDetails2.AutoSize = true;
            this.lbDetails2.BackColor = System.Drawing.Color.Transparent;
            this.lbDetails2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDetails2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDetails2.Location = new System.Drawing.Point(45, 14);
            this.lbDetails2.Name = "lbDetails2";
            this.lbDetails2.Size = new System.Drawing.Size(127, 21);
            this.lbDetails2.TabIndex = 30;
            this.lbDetails2.Text = "周四 001 胜平负\r\n";
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.Color.Transparent;
            this.plBottom.BackgroundImage = global::Demo.Properties.Resources.printingTicketBottom;
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 68);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(646, 15);
            this.plBottom.TabIndex = 33;
            // 
            // plTop
            // 
            this.plTop.BackColor = System.Drawing.Color.Transparent;
            this.plTop.BackgroundImage = global::Demo.Properties.Resources.printingTicketTop;
            this.plTop.Controls.Add(this.picStatus);
            this.plTop.Controls.Add(this.label2);
            this.plTop.Controls.Add(this.panel1);
            this.plTop.Controls.Add(this.lbBetTag);
            this.plTop.Controls.Add(this.lbBet);
            this.plTop.Controls.Add(this.lbDetails);
            this.plTop.Controls.Add(this.lbMultipleTag);
            this.plTop.Controls.Add(this.lbMultiple);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(646, 32);
            this.plTop.TabIndex = 32;
            // 
            // picStatus
            // 
            this.picStatus.BackColor = System.Drawing.Color.Transparent;
            this.picStatus.BackgroundImage = global::Demo.Properties.Resources.wwc;
            this.picStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picStatus.Location = new System.Drawing.Point(600, 9);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(16, 17);
            this.picStatus.TabIndex = 27;
            this.picStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label2.Location = new System.Drawing.Point(45, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "投注详情：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbIndex);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 14);
            this.panel1.TabIndex = 20;
            // 
            // lbIndex
            // 
            this.lbIndex.AutoSize = true;
            this.lbIndex.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIndex.ForeColor = System.Drawing.Color.White;
            this.lbIndex.Location = new System.Drawing.Point(-1, -3);
            this.lbIndex.Name = "lbIndex";
            this.lbIndex.Size = new System.Drawing.Size(17, 19);
            this.lbIndex.TabIndex = 27;
            this.lbIndex.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-8, -35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "10";
            // 
            // lbBetTag
            // 
            this.lbBetTag.AutoSize = true;
            this.lbBetTag.BackColor = System.Drawing.Color.Transparent;
            this.lbBetTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBetTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lbBetTag.Location = new System.Drawing.Point(390, 12);
            this.lbBetTag.Name = "lbBetTag";
            this.lbBetTag.Size = new System.Drawing.Size(41, 12);
            this.lbBetTag.TabIndex = 23;
            this.lbBetTag.Text = "注数：";
            // 
            // lbBet
            // 
            this.lbBet.AutoSize = true;
            this.lbBet.BackColor = System.Drawing.Color.Transparent;
            this.lbBet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbBet.Location = new System.Drawing.Point(442, 12);
            this.lbBet.Name = "lbBet";
            this.lbBet.Size = new System.Drawing.Size(29, 12);
            this.lbBet.TabIndex = 24;
            this.lbBet.Text = "99注";
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.BackColor = System.Drawing.Color.Transparent;
            this.lbDetails.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbDetails.Location = new System.Drawing.Point(119, 7);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(97, 17);
            this.lbDetails.TabIndex = 22;
            this.lbDetails.Text = "周四 001 胜平负\r\n";
            // 
            // lbMultipleTag
            // 
            this.lbMultipleTag.AutoSize = true;
            this.lbMultipleTag.BackColor = System.Drawing.Color.Transparent;
            this.lbMultipleTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultipleTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lbMultipleTag.Location = new System.Drawing.Point(487, 12);
            this.lbMultipleTag.Name = "lbMultipleTag";
            this.lbMultipleTag.Size = new System.Drawing.Size(41, 12);
            this.lbMultipleTag.TabIndex = 25;
            this.lbMultipleTag.Text = "倍数：";
            // 
            // lbMultiple
            // 
            this.lbMultiple.AutoSize = true;
            this.lbMultiple.BackColor = System.Drawing.Color.Transparent;
            this.lbMultiple.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultiple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbMultiple.Location = new System.Drawing.Point(539, 12);
            this.lbMultiple.Name = "lbMultiple";
            this.lbMultiple.Size = new System.Drawing.Size(23, 12);
            this.lbMultiple.TabIndex = 26;
            this.lbMultiple.Text = "1倍";
            // 
            // ItemTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plTop);
            this.Name = "ItemTicket";
            this.Size = new System.Drawing.Size(646, 83);
            this.Load += new System.EventHandler(this.TicketItem_Load);
            this.plMiddle.ResumeLayout(false);
            this.plMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIsWaiting)).EndInit();
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.Label lbMultiple;
        private System.Windows.Forms.Label lbMultipleTag;
        private System.Windows.Forms.Label lbBet;
        private System.Windows.Forms.Label lbBetTag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbIndex;
        private System.Windows.Forms.Label lbDetails2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Panel plMiddle;
        private int X;
        private System.Windows.Forms.PictureBox picIsWaiting;
    }
}
