namespace Demo
{
    partial class ItemManualTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemManualTicket));
            this.plMiddle = new System.Windows.Forms.Panel();
            this.picSeal = new System.Windows.Forms.PictureBox();
            this.lbDetails2 = new System.Windows.Forms.Label();
            this.plBottom = new System.Windows.Forms.Panel();
            this.plTop = new System.Windows.Forms.Panel();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbDetails = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbIndex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBetTag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbBet = new System.Windows.Forms.Label();
            this.lbMultipleTag = new System.Windows.Forms.Label();
            this.lbMultiple = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.plMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).BeginInit();
            this.plTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
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
            this.plMiddle.Size = new System.Drawing.Size(654, 36);
            this.plMiddle.TabIndex = 33;
            // 
            // picSeal
            // 
            this.picSeal.Location = new System.Drawing.Point(568, 3);
            this.picSeal.Name = "picSeal";
            this.picSeal.Size = new System.Drawing.Size(60, 60);
            this.picSeal.TabIndex = 51;
            this.picSeal.TabStop = false;
            // 
            // lbDetails2
            // 
            this.lbDetails2.AutoSize = true;
            this.lbDetails2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDetails2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDetails2.Location = new System.Drawing.Point(49, 14);
            this.lbDetails2.Name = "lbDetails2";
            this.lbDetails2.Size = new System.Drawing.Size(127, 21);
            this.lbDetails2.TabIndex = 33;
            this.lbDetails2.Text = "周四 001 胜平负\r\n";
            // 
            // plBottom
            // 
            this.plBottom.BackgroundImage = global::Demo.Properties.Resources.printingTicketBottom;
            this.plBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 68);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(654, 15);
            this.plBottom.TabIndex = 34;
            // 
            // plTop
            // 
            this.plTop.BackgroundImage = global::Demo.Properties.Resources.printingTicketTop;
            this.plTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plTop.Controls.Add(this.lbResult);
            this.plTop.Controls.Add(this.btnCancel);
            this.plTop.Controls.Add(this.btnOk);
            this.plTop.Controls.Add(this.lbDetails);
            this.plTop.Controls.Add(this.panel1);
            this.plTop.Controls.Add(this.lbBetTag);
            this.plTop.Controls.Add(this.label2);
            this.plTop.Controls.Add(this.lbBet);
            this.plTop.Controls.Add(this.lbMultipleTag);
            this.plTop.Controls.Add(this.lbMultiple);
            this.plTop.Controls.Add(this.picStatus);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(654, 32);
            this.plTop.TabIndex = 32;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbResult.ForeColor = System.Drawing.Color.Red;
            this.lbResult.Location = new System.Drawing.Point(556, 5);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(0, 22);
            this.lbResult.TabIndex = 33;
            this.lbResult.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.btnCancelTicket;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(616, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(33, 22);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseHover += new System.EventHandler(this.btnCancel_MouseHover);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BackgroundImage = global::Demo.Properties.Resources.btnOKPrint60X22;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(553, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(60, 22);
            this.btnOk.TabIndex = 21;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.MouseLeave += new System.EventHandler(this.btnOk_MouseLeave);
            this.btnOk.MouseHover += new System.EventHandler(this.btnOk_MouseHover);
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbDetails.Location = new System.Drawing.Point(118, 8);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(97, 17);
            this.lbDetails.TabIndex = 14;
            this.lbDetails.Text = "周四 001 胜平负";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbIndex);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(29, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 14);
            this.panel1.TabIndex = 12;
            // 
            // lbIndex
            // 
            this.lbIndex.AutoSize = true;
            this.lbIndex.BackColor = System.Drawing.Color.Transparent;
            this.lbIndex.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbIndex.ForeColor = System.Drawing.Color.White;
            this.lbIndex.Location = new System.Drawing.Point(-1, -2);
            this.lbIndex.Name = "lbIndex";
            this.lbIndex.Size = new System.Drawing.Size(18, 19);
            this.lbIndex.TabIndex = 28;
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
            this.lbBetTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBetTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lbBetTag.Location = new System.Drawing.Point(319, 11);
            this.lbBetTag.Name = "lbBetTag";
            this.lbBetTag.Size = new System.Drawing.Size(41, 12);
            this.lbBetTag.TabIndex = 15;
            this.lbBetTag.Text = "注数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.label2.Location = new System.Drawing.Point(49, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "投注详情：";
            // 
            // lbBet
            // 
            this.lbBet.AutoSize = true;
            this.lbBet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbBet.Location = new System.Drawing.Point(359, 11);
            this.lbBet.Name = "lbBet";
            this.lbBet.Size = new System.Drawing.Size(23, 12);
            this.lbBet.TabIndex = 16;
            this.lbBet.Text = "1注";
            // 
            // lbMultipleTag
            // 
            this.lbMultipleTag.AutoSize = true;
            this.lbMultipleTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultipleTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.lbMultipleTag.Location = new System.Drawing.Point(383, 11);
            this.lbMultipleTag.Name = "lbMultipleTag";
            this.lbMultipleTag.Size = new System.Drawing.Size(41, 12);
            this.lbMultipleTag.TabIndex = 17;
            this.lbMultipleTag.Text = "倍数：";
            // 
            // lbMultiple
            // 
            this.lbMultiple.AutoSize = true;
            this.lbMultiple.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMultiple.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(135)))), ((int)(((byte)(234)))));
            this.lbMultiple.Location = new System.Drawing.Point(423, 11);
            this.lbMultiple.Name = "lbMultiple";
            this.lbMultiple.Size = new System.Drawing.Size(23, 12);
            this.lbMultiple.TabIndex = 18;
            this.lbMultiple.Text = "1倍";
            // 
            // picStatus
            // 
            this.picStatus.BackgroundImage = global::Demo.Properties.Resources.wwc;
            this.picStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picStatus.Location = new System.Drawing.Point(481, 8);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(16, 17);
            this.picStatus.TabIndex = 19;
            this.picStatus.TabStop = false;
            // 
            // ItemManualTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.plMiddle);
            this.Controls.Add(this.plBottom);
            this.Controls.Add(this.plTop);
            this.Name = "ItemManualTicket";
            this.Size = new System.Drawing.Size(654, 83);
            this.Load += new System.EventHandler(this.ItemManualTicket_Load);
            this.plMiddle.ResumeLayout(false);
            this.plMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeal)).EndInit();
            this.plTop.ResumeLayout(false);
            this.plTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMultiple;
        private System.Windows.Forms.Label lbMultipleTag;
        private System.Windows.Forms.Label lbBet;
        private System.Windows.Forms.Label lbBetTag;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDetails2;
        private System.Windows.Forms.Panel plTop;
        private System.Windows.Forms.Panel plMiddle;
        private System.Windows.Forms.Panel plBottom;
        private int X;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.PictureBox picSeal;
    }
}
