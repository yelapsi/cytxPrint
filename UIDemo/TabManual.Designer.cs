namespace Demo
{
    partial class TabManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabManual));
            this.totalTicketNum = new System.Windows.Forms.Label();
            this.totalOrderNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.plTitlebar = new System.Windows.Forms.Panel();
            this.lbOrderPrice = new System.Windows.Forms.Label();
            this.lbTotalTicketNumTag = new System.Windows.Forms.Label();
            this.lbLicense = new System.Windows.Forms.Label();
            this.lbOrderId = new System.Windows.Forms.Label();
            this.lbOrderPriceTag = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalTicketNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.lbCancel = new System.Windows.Forms.Label();
            this.lbSured = new System.Windows.Forms.Label();
            this.txtTotalTicketsNumber = new System.Windows.Forms.Label();
            this.btnRevert = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.ticketControlsList = new Demo.ControlsList();
            this.orderItemControlsList = new Demo.ControlsList();
            this.modulePagingNEW = new ModulePagingNEW();
            this.plTitlebar.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRevert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // totalTicketNum
            // 
            this.totalTicketNum.AutoSize = true;
            this.totalTicketNum.BackColor = System.Drawing.Color.Transparent;
            this.totalTicketNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalTicketNum.ForeColor = System.Drawing.Color.Red;
            this.totalTicketNum.Location = new System.Drawing.Point(171, 10);
            this.totalTicketNum.Name = "totalTicketNum";
            this.totalTicketNum.Size = new System.Drawing.Size(23, 12);
            this.totalTicketNum.TabIndex = 39;
            this.totalTicketNum.Text = "0张";
            // 
            // totalOrderNum
            // 
            this.totalOrderNum.AutoSize = true;
            this.totalOrderNum.BackColor = System.Drawing.Color.Transparent;
            this.totalOrderNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalOrderNum.ForeColor = System.Drawing.Color.Red;
            this.totalOrderNum.Location = new System.Drawing.Point(58, 10);
            this.totalOrderNum.Name = "totalOrderNum";
            this.totalOrderNum.Size = new System.Drawing.Size(23, 12);
            this.totalOrderNum.TabIndex = 37;
            this.totalOrderNum.Text = "0单";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label6.Location = new System.Drawing.Point(126, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "总票数:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label8.Location = new System.Drawing.Point(14, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "订单数:";
            // 
            // plTitlebar
            // 
            this.plTitlebar.BackgroundImage = global::Demo.Properties.Resources.titleBackgroundImg;
            this.plTitlebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plTitlebar.Controls.Add(this.totalTicketNum);
            this.plTitlebar.Controls.Add(this.lbOrderPrice);
            this.plTitlebar.Controls.Add(this.totalOrderNum);
            this.plTitlebar.Controls.Add(this.lbTotalTicketNumTag);
            this.plTitlebar.Controls.Add(this.label6);
            this.plTitlebar.Controls.Add(this.label8);
            this.plTitlebar.Controls.Add(this.lbLicense);
            this.plTitlebar.Controls.Add(this.lbOrderId);
            this.plTitlebar.Controls.Add(this.lbOrderPriceTag);
            this.plTitlebar.Controls.Add(this.label4);
            this.plTitlebar.Controls.Add(this.lbTotalTicketNum);
            this.plTitlebar.Controls.Add(this.label2);
            this.plTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitlebar.Location = new System.Drawing.Point(0, 0);
            this.plTitlebar.Name = "plTitlebar";
            this.plTitlebar.Size = new System.Drawing.Size(950, 32);
            this.plTitlebar.TabIndex = 44;
            // 
            // lbOrderPrice
            // 
            this.lbOrderPrice.AutoSize = true;
            this.lbOrderPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbOrderPrice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderPrice.ForeColor = System.Drawing.Color.Red;
            this.lbOrderPrice.Location = new System.Drawing.Point(569, 10);
            this.lbOrderPrice.Name = "lbOrderPrice";
            this.lbOrderPrice.Size = new System.Drawing.Size(0, 12);
            this.lbOrderPrice.TabIndex = 33;
            // 
            // lbTotalTicketNumTag
            // 
            this.lbTotalTicketNumTag.AutoSize = true;
            this.lbTotalTicketNumTag.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalTicketNumTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalTicketNumTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbTotalTicketNumTag.Location = new System.Drawing.Point(654, 10);
            this.lbTotalTicketNumTag.Name = "lbTotalTicketNumTag";
            this.lbTotalTicketNumTag.Size = new System.Drawing.Size(41, 12);
            this.lbTotalTicketNumTag.TabIndex = 34;
            this.lbTotalTicketNumTag.Text = "票数：";
            // 
            // lbLicense
            // 
            this.lbLicense.AutoSize = true;
            this.lbLicense.BackColor = System.Drawing.Color.Transparent;
            this.lbLicense.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLicense.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbLicense.Location = new System.Drawing.Point(447, 10);
            this.lbLicense.Name = "lbLicense";
            this.lbLicense.Size = new System.Drawing.Size(0, 12);
            this.lbLicense.TabIndex = 31;
            // 
            // lbOrderId
            // 
            this.lbOrderId.AutoSize = true;
            this.lbOrderId.BackColor = System.Drawing.Color.Transparent;
            this.lbOrderId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderId.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbOrderId.Location = new System.Drawing.Point(320, 10);
            this.lbOrderId.Name = "lbOrderId";
            this.lbOrderId.Size = new System.Drawing.Size(0, 12);
            this.lbOrderId.TabIndex = 46;
            // 
            // lbOrderPriceTag
            // 
            this.lbOrderPriceTag.AutoSize = true;
            this.lbOrderPriceTag.BackColor = System.Drawing.Color.Transparent;
            this.lbOrderPriceTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderPriceTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbOrderPriceTag.Location = new System.Drawing.Point(529, 10);
            this.lbOrderPriceTag.Name = "lbOrderPriceTag";
            this.lbOrderPriceTag.Size = new System.Drawing.Size(41, 12);
            this.lbOrderPriceTag.TabIndex = 32;
            this.lbOrderPriceTag.Text = "金额：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(262, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "订单号：";
            // 
            // lbTotalTicketNum
            // 
            this.lbTotalTicketNum.AutoSize = true;
            this.lbTotalTicketNum.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalTicketNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalTicketNum.ForeColor = System.Drawing.Color.Red;
            this.lbTotalTicketNum.Location = new System.Drawing.Point(703, 10);
            this.lbTotalTicketNum.Name = "lbTotalTicketNum";
            this.lbTotalTicketNum.Size = new System.Drawing.Size(0, 12);
            this.lbTotalTicketNum.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(396, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "彩种：";
            // 
            // panel
            // 
            this.panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel.BackgroundImage")));
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.Controls.Add(this.lbCancel);
            this.panel.Controls.Add(this.lbSured);
            this.panel.Controls.Add(this.txtTotalTicketsNumber);
            this.panel.Controls.Add(this.btnRevert);
            this.panel.Controls.Add(this.btnOk);
            this.panel.Controls.Add(this.btnCancel);
            this.panel.Location = new System.Drawing.Point(240, 31);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(710, 64);
            this.panel.TabIndex = 16;
            // 
            // lbCancel
            // 
            this.lbCancel.AutoSize = true;
            this.lbCancel.BackColor = System.Drawing.Color.Transparent;
            this.lbCancel.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbCancel.Location = new System.Drawing.Point(270, 10);
            this.lbCancel.Name = "lbCancel";
            this.lbCancel.Size = new System.Drawing.Size(18, 19);
            this.lbCancel.TabIndex = 54;
            this.lbCancel.Text = "0";
            // 
            // lbSured
            // 
            this.lbSured.AutoSize = true;
            this.lbSured.BackColor = System.Drawing.Color.Transparent;
            this.lbSured.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSured.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbSured.Location = new System.Drawing.Point(183, 10);
            this.lbSured.Name = "lbSured";
            this.lbSured.Size = new System.Drawing.Size(18, 19);
            this.lbSured.TabIndex = 53;
            this.lbSured.Text = "0";
            // 
            // txtTotalTicketsNumber
            // 
            this.txtTotalTicketsNumber.AutoSize = true;
            this.txtTotalTicketsNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalTicketsNumber.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTotalTicketsNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtTotalTicketsNumber.Location = new System.Drawing.Point(66, 10);
            this.txtTotalTicketsNumber.Name = "txtTotalTicketsNumber";
            this.txtTotalTicketsNumber.Size = new System.Drawing.Size(32, 19);
            this.txtTotalTicketsNumber.TabIndex = 52;
            this.txtTotalTicketsNumber.Text = "0%";
            // 
            // btnRevert
            // 
            this.btnRevert.BackColor = System.Drawing.Color.Transparent;
            this.btnRevert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRevert.BackgroundImage")));
            this.btnRevert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevert.Location = new System.Drawing.Point(569, 7);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(53, 25);
            this.btnRevert.TabIndex = 37;
            this.btnRevert.TabStop = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            this.btnRevert.MouseEnter += new System.EventHandler(this.btnRevert_MouseHover);
            this.btnRevert.MouseLeave += new System.EventHandler(this.btnRevert_MouseLeave);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Location = new System.Drawing.Point(626, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(73, 25);
            this.btnOk.TabIndex = 27;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.MouseEnter += new System.EventHandler(this.btnOk_MouseHover);
            this.btnOk.MouseLeave += new System.EventHandler(this.btnOk_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(512, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 25);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseHover);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            // 
            // ticketControlsList
            // 
            this.ticketControlsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.ticketControlsList.E = null;
            this.ticketControlsList.Gap = 0;
            this.ticketControlsList.GapX = 0;
            this.ticketControlsList.HideScrollbar = false;
            this.ticketControlsList.IsAutoHideScroll = false;
            this.ticketControlsList.IsItemOrder = false;
            this.ticketControlsList.Location = new System.Drawing.Point(240, 95);
            this.ticketControlsList.Margin = new System.Windows.Forms.Padding(4);
            this.ticketControlsList.Name = "ticketControlsList";
            this.ticketControlsList.Size = new System.Drawing.Size(710, 470);
            this.ticketControlsList.TabIndex = 41;
            // 
            // orderItemControlsList
            // 
            this.orderItemControlsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.orderItemControlsList.E = null;
            this.orderItemControlsList.Gap = 0;
            this.orderItemControlsList.GapX = 0;
            this.orderItemControlsList.HideScrollbar = false;
            this.orderItemControlsList.IsAutoHideScroll = false;
            this.orderItemControlsList.IsItemOrder = false;
            this.orderItemControlsList.Location = new System.Drawing.Point(0, 32);
            this.orderItemControlsList.Margin = new System.Windows.Forms.Padding(4);
            this.orderItemControlsList.Name = "orderItemControlsList";
            this.orderItemControlsList.Size = new System.Drawing.Size(240, 532);
            this.orderItemControlsList.TabIndex = 40;
            // 
            // modulePagingNEW
            // 
            this.modulePagingNEW.BackColor = System.Drawing.Color.Transparent;
            this.modulePagingNEW.BtnFirstClick = null;
            this.modulePagingNEW.BtnJumpClick = null;
            this.modulePagingNEW.BtnLastClick = null;
            this.modulePagingNEW.BtnNextClick = null;
            this.modulePagingNEW.BtnPreviousClick = null;
            this.modulePagingNEW.Enabled = false;
            this.modulePagingNEW.JumpPage = 0;
            this.modulePagingNEW.Location = new System.Drawing.Point(416, 536);
            this.modulePagingNEW.MaxPage = 0;
            this.modulePagingNEW.Name = "modulePagingNEW";
            this.modulePagingNEW.NowPage = 0;
            this.modulePagingNEW.Size = new System.Drawing.Size(646, 24);
            this.modulePagingNEW.TabIndex = 0;
            // 
            // TabManual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.plTitlebar);
            this.Controls.Add(this.ticketControlsList);
            this.Controls.Add(this.orderItemControlsList);
            this.Controls.Add(this.panel);
            this.Name = "TabManual";
            this.Size = new System.Drawing.Size(950, 565);
            this.Load += new System.EventHandler(this.CYTXLotteryManualTab_Load);
            this.plTitlebar.ResumeLayout(false);
            this.plTitlebar.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRevert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalTicketNum;
        private System.Windows.Forms.Label lbTotalTicketNumTag;
        private System.Windows.Forms.Label lbOrderPrice;
        private System.Windows.Forms.Label lbOrderPriceTag;
        private System.Windows.Forms.Label lbLicense;
        private System.Windows.Forms.PictureBox btnOk;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox btnRevert;
        private System.Windows.Forms.Label totalTicketNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalOrderNum;
        private System.Windows.Forms.Label label8;
        private ControlsList orderItemControlsList;
        private ControlsList ticketControlsList;
        private System.Windows.Forms.Label lbOrderId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtTotalTicketsNumber;
        private System.Windows.Forms.Panel plTitlebar;
        private System.Windows.Forms.Label lbCancel;
        private System.Windows.Forms.Label lbSured;
        private ModulePagingNEW modulePagingNEW;
    }
}