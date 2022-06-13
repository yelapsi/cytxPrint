namespace Demo
{
    partial class ItemErrorTicketDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemErrorTicketDetail));
            this.lbBet = new System.Windows.Forms.Label();
            this.lbBetTag = new System.Windows.Forms.Label();
            this.lbMultiple = new System.Windows.Forms.Label();
            this.lbMultipleTag = new System.Windows.Forms.Label();
            this.lbCheckDetail = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labIndex = new System.Windows.Forms.Label();
            this.picSure = new System.Windows.Forms.PictureBox();
            this.picCancel = new System.Windows.Forms.PictureBox();
            this.picRepeat = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDetails2 = new System.Windows.Forms.Label();
            this.lbDetails = new System.Windows.Forms.Label();
            this.plTop = new System.Windows.Forms.Panel();
            this.plMiddle = new System.Windows.Forms.Panel();
            this.plBottom = new System.Windows.Forms.Panel();
            this.picSeal = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepeat)).BeginInit();
            this.plTop.SuspendLayout();
            this.plMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).BeginInit();
            this.SuspendLayout();
            // 
            // lbBet
            // 
            this.lbBet.AutoSize = true;
            this.lbBet.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbBet.Location = new System.Drawing.Point(414, 6);
            this.lbBet.Name = "lbBet";
            this.lbBet.Size = new System.Drawing.Size(31, 20);
            this.lbBet.TabIndex = 5;
            this.lbBet.Text = "1注";
            // 
            // lbBetTag
            // 
            this.lbBetTag.AutoSize = true;
            this.lbBetTag.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBetTag.ForeColor = System.Drawing.Color.Gray;
            this.lbBetTag.Location = new System.Drawing.Point(371, 6);
            this.lbBetTag.Name = "lbBetTag";
            this.lbBetTag.Size = new System.Drawing.Size(51, 20);
            this.lbBetTag.TabIndex = 4;
            this.lbBetTag.Text = "注数：";
            // 
            // lbMultiple
            // 
            this.lbMultiple.AutoSize = true;
            this.lbMultiple.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultiple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbMultiple.Location = new System.Drawing.Point(491, 6);
            this.lbMultiple.Name = "lbMultiple";
            this.lbMultiple.Size = new System.Drawing.Size(31, 20);
            this.lbMultiple.TabIndex = 7;
            this.lbMultiple.Text = "1倍";
            // 
            // lbMultipleTag
            // 
            this.lbMultipleTag.AutoSize = true;
            this.lbMultipleTag.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultipleTag.ForeColor = System.Drawing.Color.Gray;
            this.lbMultipleTag.Location = new System.Drawing.Point(457, 6);
            this.lbMultipleTag.Name = "lbMultipleTag";
            this.lbMultipleTag.Size = new System.Drawing.Size(51, 20);
            this.lbMultipleTag.TabIndex = 6;
            this.lbMultipleTag.Text = "倍数：";
            // 
            // lbCheckDetail
            // 
            this.lbCheckDetail.AutoSize = true;
            this.lbCheckDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCheckDetail.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCheckDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbCheckDetail.Location = new System.Drawing.Point(809, 6);
            this.lbCheckDetail.Name = "lbCheckDetail";
            this.lbCheckDetail.Size = new System.Drawing.Size(65, 20);
            this.lbCheckDetail.TabIndex = 11;
            this.lbCheckDetail.Text = "查看详情";
            this.lbCheckDetail.Click += new System.EventHandler(this.lbCheckDetail_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Demo.Properties.Resources.sy;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labIndex);
            this.panel1.Location = new System.Drawing.Point(24, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 14);
            this.panel1.TabIndex = 1;
            // 
            // labIndex
            // 
            this.labIndex.AutoSize = true;
            this.labIndex.BackColor = System.Drawing.Color.Transparent;
            this.labIndex.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.labIndex.ForeColor = System.Drawing.Color.White;
            this.labIndex.Location = new System.Drawing.Point(-1, -3);
            this.labIndex.Name = "labIndex";
            this.labIndex.Size = new System.Drawing.Size(17, 19);
            this.labIndex.TabIndex = 0;
            this.labIndex.Text = "0";
            // 
            // picSure
            // 
            this.picSure.BackColor = System.Drawing.Color.Transparent;
            this.picSure.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSure.BackgroundImage")));
            this.picSure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSure.Location = new System.Drawing.Point(738, 8);
            this.picSure.Name = "picSure";
            this.picSure.Size = new System.Drawing.Size(16, 16);
            this.picSure.TabIndex = 10;
            this.picSure.TabStop = false;
            this.picSure.Click += new System.EventHandler(this.picSure_Click);
            // 
            // picCancel
            // 
            this.picCancel.BackColor = System.Drawing.Color.Transparent;
            this.picCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picCancel.BackgroundImage")));
            this.picCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCancel.Location = new System.Drawing.Point(654, 8);
            this.picCancel.Name = "picCancel";
            this.picCancel.Size = new System.Drawing.Size(16, 16);
            this.picCancel.TabIndex = 9;
            this.picCancel.TabStop = false;
            this.picCancel.Click += new System.EventHandler(this.picCancel_Click);
            // 
            // picRepeat
            // 
            this.picRepeat.BackColor = System.Drawing.Color.Transparent;
            this.picRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picRepeat.BackgroundImage")));
            this.picRepeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRepeat.Location = new System.Drawing.Point(566, 8);
            this.picRepeat.Name = "picRepeat";
            this.picRepeat.Size = new System.Drawing.Size(16, 16);
            this.picRepeat.TabIndex = 8;
            this.picRepeat.TabStop = false;
            this.picRepeat.Click += new System.EventHandler(this.picRepeat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label2.Location = new System.Drawing.Point(42, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "投注详情：";
            // 
            // lbDetails2
            // 
            this.lbDetails2.AutoSize = true;
            this.lbDetails2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDetails2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDetails2.Location = new System.Drawing.Point(42, 14);
            this.lbDetails2.Name = "lbDetails2";
            this.lbDetails2.Size = new System.Drawing.Size(127, 21);
            this.lbDetails2.TabIndex = 34;
            this.lbDetails2.Text = "周四 001 胜平负\r\n";
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lbDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbDetails.Location = new System.Drawing.Point(114, 6);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(111, 20);
            this.lbDetails.TabIndex = 32;
            this.lbDetails.Text = "周四 001 胜平负\r\n";
            // 
            // plTop
            // 
            this.plTop.BackgroundImage = global::Demo.Properties.Resources.printingTicketTop;
            this.plTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plTop.Controls.Add(this.lbDetails);
            this.plTop.Controls.Add(this.lbMultiple);
            this.plTop.Controls.Add(this.lbBet);
            this.plTop.Controls.Add(this.panel1);
            this.plTop.Controls.Add(this.label2);
            this.plTop.Controls.Add(this.lbCheckDetail);
            this.plTop.Controls.Add(this.picSure);
            this.plTop.Controls.Add(this.picCancel);
            this.plTop.Controls.Add(this.picRepeat);
            this.plTop.Controls.Add(this.lbMultipleTag);
            this.plTop.Controls.Add(this.lbBetTag);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(900, 32);
            this.plTop.TabIndex = 36;
            // 
            // plMiddle
            // 
            this.plMiddle.BackgroundImage = global::Demo.Properties.Resources.printingTicketMiddle;
            this.plMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plMiddle.Controls.Add(this.picSeal);
            this.plMiddle.Controls.Add(this.lbDetails2);
            this.plMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMiddle.Location = new System.Drawing.Point(0, 32);
            this.plMiddle.Name = "plMiddle";
            this.plMiddle.Size = new System.Drawing.Size(900, 39);
            this.plMiddle.TabIndex = 37;
            // 
            // plBottom
            // 
            this.plBottom.BackgroundImage = global::Demo.Properties.Resources.printingTicketBottom;
            this.plBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 71);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(900, 15);
            this.plBottom.TabIndex = 37;
            // 
            // picSeal
            // 
            this.picSeal.Location = new System.Drawing.Point(813, 3);
            this.picSeal.Name = "picSeal";
            this.picSeal.Size = new System.Drawing.Size(60, 60);
            this.picSeal.TabIndex = 50;
            this.picSeal.TabStop = false;
            // 
            // ItemErrorTicketDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plTop);
            this.Name = "ItemErrorTicketDetail";
            this.Size = new System.Drawing.Size(900, 86);
            this.Load += new System.EventHandler(this.ErrorTicketItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepeat)).EndInit();
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.plMiddle.ResumeLayout(false);
            this.plMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labIndex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbBet;
        private System.Windows.Forms.Label lbBetTag;
        private System.Windows.Forms.Label lbMultiple;
        private System.Windows.Forms.Label lbMultipleTag;
        private System.Windows.Forms.PictureBox picRepeat;
        private System.Windows.Forms.PictureBox picCancel;
        private System.Windows.Forms.PictureBox picSure;
        private System.Windows.Forms.Label lbCheckDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDetails2;
        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plMiddle;
        private System.Windows.Forms.Panel plBottom;
        private int X;
        private System.Windows.Forms.PictureBox picSeal;
    }
}
