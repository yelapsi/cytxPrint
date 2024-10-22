﻿namespace Demo
{
    partial class TabPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPrint));
            this.panelFirstItem = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSortByTicketNum = new System.Windows.Forms.Button();
            this.btnSortByTime = new System.Windows.Forms.Button();
            this.plTicketTitle = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.label_COM_State = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPercentage = new System.Windows.Forms.Label();
            this.lbOrderId = new System.Windows.Forms.Label();
            this.lbTotalTicketNum = new System.Windows.Forms.Label();
            this.lbOrderPrice = new System.Windows.Forms.Label();
            this.lbLicense = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalTicketNumTag = new System.Windows.Forms.Label();
            this.lbOrderPriceTag = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbJX = new System.Windows.Forms.Label();
            this.lbJXTag = new System.Windows.Forms.Label();
            this.stopTicketBtn = new System.Windows.Forms.Button();
            this.startTicketBtn = new System.Windows.Forms.Button();
            this.label_workWay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPortTag = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ticketItemControlsList = new Demo.ControlsList();
            this.orderItemControlsList = new Demo.ControlsList();
            this.progressBar = new Demo.ModuleProgressBar();
            this.moduleProgressMsg = new Demo.ModuleProgressMsg();
            this.modulePagingNEW = new Demo.ModulePagingNEW();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFirstItem
            // 
            this.panelFirstItem.Location = new System.Drawing.Point(42, 29);
            this.panelFirstItem.Name = "panelFirstItem";
            this.panelFirstItem.Size = new System.Drawing.Size(244, 50);
            this.panelFirstItem.TabIndex = 11;
            this.panelFirstItem.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Demo.Properties.Resources.top_x;
            this.panel1.Controls.Add(this.btnSortByTicketNum);
            this.panel1.Controls.Add(this.btnSortByTime);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 32);
            this.panel1.TabIndex = 21;
            // 
            // btnSortByTicketNum
            // 
            this.btnSortByTicketNum.BackColor = System.Drawing.Color.White;
            this.btnSortByTicketNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortByTicketNum.FlatAppearance.BorderSize = 0;
            this.btnSortByTicketNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortByTicketNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnSortByTicketNum.Location = new System.Drawing.Point(144, 6);
            this.btnSortByTicketNum.Name = "btnSortByTicketNum";
            this.btnSortByTicketNum.Size = new System.Drawing.Size(66, 20);
            this.btnSortByTicketNum.TabIndex = 8;
            this.btnSortByTicketNum.Text = "按票数";
            this.btnSortByTicketNum.UseVisualStyleBackColor = false;
            this.btnSortByTicketNum.Click += new System.EventHandler(this.btnSortByTicketNum_Click);
            // 
            // btnSortByTime
            // 
            this.btnSortByTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(172)))), ((int)(((byte)(82)))));
            this.btnSortByTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortByTime.FlatAppearance.BorderSize = 0;
            this.btnSortByTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortByTime.ForeColor = System.Drawing.Color.White;
            this.btnSortByTime.Location = new System.Drawing.Point(23, 6);
            this.btnSortByTime.Name = "btnSortByTime";
            this.btnSortByTime.Size = new System.Drawing.Size(66, 20);
            this.btnSortByTime.TabIndex = 9;
            this.btnSortByTime.Text = "按时间";
            this.btnSortByTime.UseVisualStyleBackColor = false;
            this.btnSortByTime.Click += new System.EventHandler(this.btnSortByTime_Click);
            // 
            // plTicketTitle
            // 
            this.plTicketTitle.BackColor = System.Drawing.Color.Transparent;
            this.plTicketTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plTicketTitle.BackgroundImage")));
            this.plTicketTitle.Location = new System.Drawing.Point(240, 133);
            this.plTicketTitle.Name = "plTicketTitle";
            this.plTicketTitle.Size = new System.Drawing.Size(710, 26);
            this.plTicketTitle.TabIndex = 19;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel.BackgroundImage")));
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel.Controls.Add(this.label_COM_State);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.txtPercentage);
            this.panel.Controls.Add(this.lbOrderId);
            this.panel.Controls.Add(this.lbTotalTicketNum);
            this.panel.Controls.Add(this.lbOrderPrice);
            this.panel.Controls.Add(this.lbLicense);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.progressBar);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.lbTotalTicketNumTag);
            this.panel.Controls.Add(this.lbOrderPriceTag);
            this.panel.Controls.Add(this.lbPort);
            this.panel.Controls.Add(this.lbJX);
            this.panel.Controls.Add(this.lbJXTag);
            this.panel.Controls.Add(this.stopTicketBtn);
            this.panel.Controls.Add(this.startTicketBtn);
            this.panel.Controls.Add(this.label_workWay);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.lbPortTag);
            this.panel.Controls.Add(this.moduleProgressMsg);
            this.panel.Controls.Add(this.modulePagingNEW);
            this.panel.Location = new System.Drawing.Point(240, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(710, 133);
            this.panel.TabIndex = 11;
            // 
            // label_COM_State
            // 
            this.label_COM_State.AutoSize = true;
            this.label_COM_State.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_COM_State.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label_COM_State.Location = new System.Drawing.Point(297, 11);
            this.label_COM_State.Name = "label_COM_State";
            this.label_COM_State.Size = new System.Drawing.Size(0, 12);
            this.label_COM_State.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(233, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "端口状态：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(42, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "已完成";
            // 
            // txtPercentage
            // 
            this.txtPercentage.AutoSize = true;
            this.txtPercentage.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtPercentage.Location = new System.Drawing.Point(47, 66);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(32, 19);
            this.txtPercentage.TabIndex = 24;
            this.txtPercentage.Text = "0%";
            // 
            // lbOrderId
            // 
            this.lbOrderId.AutoSize = true;
            this.lbOrderId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderId.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbOrderId.Location = new System.Drawing.Point(176, 45);
            this.lbOrderId.Name = "lbOrderId";
            this.lbOrderId.Size = new System.Drawing.Size(0, 12);
            this.lbOrderId.TabIndex = 44;
            // 
            // lbTotalTicketNum
            // 
            this.lbTotalTicketNum.AutoSize = true;
            this.lbTotalTicketNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalTicketNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTotalTicketNum.Location = new System.Drawing.Point(560, 45);
            this.lbTotalTicketNum.Name = "lbTotalTicketNum";
            this.lbTotalTicketNum.Size = new System.Drawing.Size(0, 12);
            this.lbTotalTicketNum.TabIndex = 35;
            // 
            // lbOrderPrice
            // 
            this.lbOrderPrice.AutoSize = true;
            this.lbOrderPrice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbOrderPrice.Location = new System.Drawing.Point(428, 45);
            this.lbOrderPrice.Name = "lbOrderPrice";
            this.lbOrderPrice.Size = new System.Drawing.Size(0, 12);
            this.lbOrderPrice.TabIndex = 33;
            // 
            // lbLicense
            // 
            this.lbLicense.AutoSize = true;
            this.lbLicense.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLicense.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbLicense.Location = new System.Drawing.Point(296, 45);
            this.lbLicense.Name = "lbLicense";
            this.lbLicense.Size = new System.Drawing.Size(0, 12);
            this.lbLicense.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(125, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "订单号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(257, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "彩种：";
            // 
            // lbTotalTicketNumTag
            // 
            this.lbTotalTicketNumTag.AutoSize = true;
            this.lbTotalTicketNumTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalTicketNumTag.Location = new System.Drawing.Point(521, 45);
            this.lbTotalTicketNumTag.Name = "lbTotalTicketNumTag";
            this.lbTotalTicketNumTag.Size = new System.Drawing.Size(41, 12);
            this.lbTotalTicketNumTag.TabIndex = 34;
            this.lbTotalTicketNumTag.Text = "票数：";
            // 
            // lbOrderPriceTag
            // 
            this.lbOrderPriceTag.AutoSize = true;
            this.lbOrderPriceTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderPriceTag.Location = new System.Drawing.Point(389, 45);
            this.lbOrderPriceTag.Name = "lbOrderPriceTag";
            this.lbOrderPriceTag.Size = new System.Drawing.Size(41, 12);
            this.lbOrderPriceTag.TabIndex = 32;
            this.lbOrderPriceTag.Text = "金额：";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbPort.Location = new System.Drawing.Point(193, 10);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(0, 12);
            this.lbPort.TabIndex = 30;
            // 
            // lbJX
            // 
            this.lbJX.AutoSize = true;
            this.lbJX.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbJX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.lbJX.Location = new System.Drawing.Point(45, 10);
            this.lbJX.Name = "lbJX";
            this.lbJX.Size = new System.Drawing.Size(0, 12);
            this.lbJX.TabIndex = 29;
            // 
            // lbJXTag
            // 
            this.lbJXTag.AutoSize = true;
            this.lbJXTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbJXTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbJXTag.Location = new System.Drawing.Point(4, 10);
            this.lbJXTag.Name = "lbJXTag";
            this.lbJXTag.Size = new System.Drawing.Size(41, 12);
            this.lbJXTag.TabIndex = 28;
            this.lbJXTag.Text = "机型：";
            // 
            // stopTicketBtn
            // 
            this.stopTicketBtn.BackColor = System.Drawing.Color.Transparent;
            this.stopTicketBtn.BackgroundImage = global::Demo.Properties.Resources.tz;
            this.stopTicketBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopTicketBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopTicketBtn.Enabled = false;
            this.stopTicketBtn.FlatAppearance.BorderSize = 0;
            this.stopTicketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopTicketBtn.Location = new System.Drawing.Point(565, 78);
            this.stopTicketBtn.Name = "stopTicketBtn";
            this.stopTicketBtn.Size = new System.Drawing.Size(105, 37);
            this.stopTicketBtn.TabIndex = 27;
            this.stopTicketBtn.UseVisualStyleBackColor = false;
            this.stopTicketBtn.Click += new System.EventHandler(this.stopTicketBtn_Click);
            // 
            // startTicketBtn
            // 
            this.startTicketBtn.BackColor = System.Drawing.Color.Transparent;
            this.startTicketBtn.BackgroundImage = global::Demo.Properties.Resources.ks;
            this.startTicketBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startTicketBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startTicketBtn.FlatAppearance.BorderSize = 0;
            this.startTicketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startTicketBtn.Location = new System.Drawing.Point(449, 78);
            this.startTicketBtn.Name = "startTicketBtn";
            this.startTicketBtn.Size = new System.Drawing.Size(105, 37);
            this.startTicketBtn.TabIndex = 26;
            this.startTicketBtn.UseVisualStyleBackColor = false;
            this.startTicketBtn.Click += new System.EventHandler(this.startTicketbtn_Click);
            // 
            // label_workWay
            // 
            this.label_workWay.AutoSize = true;
            this.label_workWay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_workWay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.label_workWay.Location = new System.Drawing.Point(446, 11);
            this.label_workWay.Name = "label_workWay";
            this.label_workWay.Size = new System.Drawing.Size(177, 12);
            this.label_workWay.TabIndex = 13;
            this.label_workWay.Text = "正在读取出票方式数据......";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(385, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "出票方式：";
            // 
            // lbPortTag
            // 
            this.lbPortTag.AutoSize = true;
            this.lbPortTag.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPortTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lbPortTag.Location = new System.Drawing.Point(129, 10);
            this.lbPortTag.Name = "lbPortTag";
            this.lbPortTag.Size = new System.Drawing.Size(65, 12);
            this.lbPortTag.TabIndex = 7;
            this.lbPortTag.Text = "工作端口：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = global::Demo.Properties.Resources.hh;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(230, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 33);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // ticketItemControlsList
            // 
            this.ticketItemControlsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.ticketItemControlsList.E = null;
            this.ticketItemControlsList.Gap = 0;
            this.ticketItemControlsList.GapX = 0;
            this.ticketItemControlsList.HideScrollbar = false;
            this.ticketItemControlsList.IsAutoHideScroll = false;
            this.ticketItemControlsList.IsItemOrder = false;
            this.ticketItemControlsList.Location = new System.Drawing.Point(240, 159);
            this.ticketItemControlsList.Margin = new System.Windows.Forms.Padding(4);
            this.ticketItemControlsList.Name = "ticketItemControlsList";
            this.ticketItemControlsList.Size = new System.Drawing.Size(710, 406);
            this.ticketItemControlsList.TabIndex = 20;
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
            this.orderItemControlsList.Location = new System.Drawing.Point(0, 33);
            this.orderItemControlsList.Margin = new System.Windows.Forms.Padding(4);
            this.orderItemControlsList.Name = "orderItemControlsList";
            this.orderItemControlsList.Size = new System.Drawing.Size(240, 532);
            this.orderItemControlsList.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Location = new System.Drawing.Point(106, 79);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(308, 16);
            this.progressBar.TabIndex = 40;
            this.progressBar.Value = 0;
            // 
            // moduleProgressMsg
            // 
            this.moduleProgressMsg.BackColor = System.Drawing.Color.Transparent;
            this.moduleProgressMsg.Location = new System.Drawing.Point(106, 105);
            this.moduleProgressMsg.Name = "moduleProgressMsg";
            this.moduleProgressMsg.Size = new System.Drawing.Size(315, 20);
            this.moduleProgressMsg.TabIndex = 46;
            // 
            // modulePagingNEW
            // 
            this.modulePagingNEW.BackColor = System.Drawing.Color.Transparent;
            this.modulePagingNEW.BtnFirstClick = null;
            this.modulePagingNEW.BtnJumpClick = null;
            this.modulePagingNEW.BtnLastClick = null;
            this.modulePagingNEW.BtnNextClick = null;
            this.modulePagingNEW.BtnPreviousClick = null;
            this.modulePagingNEW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modulePagingNEW.Enabled = false;
            this.modulePagingNEW.JumpPage = 0;
            this.modulePagingNEW.Location = new System.Drawing.Point(0, 109);
            this.modulePagingNEW.MaxPage = 0;
            this.modulePagingNEW.Name = "modulePagingNEW";
            this.modulePagingNEW.NowPage = 0;
            this.modulePagingNEW.Size = new System.Drawing.Size(710, 24);
            this.modulePagingNEW.TabIndex = 0;
            // 
            // TabPrint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ticketItemControlsList);
            this.Controls.Add(this.plTicketTitle);
            this.Controls.Add(this.orderItemControlsList);
            this.Controls.Add(this.panel);
            this.Name = "TabPrint";
            this.Size = new System.Drawing.Size(950, 565);
            this.Load += new System.EventHandler(this.TabPrint_Load);
            this.panel1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelFirstItem;
        private System.Windows.Forms.Label lbPortTag;
        private System.Windows.Forms.Label label_workWay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbJX;
        private System.Windows.Forms.Label lbJXTag;
        private System.Windows.Forms.Label lbTotalTicketNum;
        private System.Windows.Forms.Label lbTotalTicketNumTag;
        private System.Windows.Forms.Label lbOrderPrice;
        private System.Windows.Forms.Label lbOrderPriceTag;
        private System.Windows.Forms.Label lbLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plTicketTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbOrderId;
        private System.Windows.Forms.Label txtPercentage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSortByTicketNum;
        private System.Windows.Forms.Button btnSortByTime;
        private System.Windows.Forms.Button stopTicketBtn;
        private System.Windows.Forms.Button startTicketBtn;
        private ModuleProgressMsg moduleProgressMsg;
        private ModuleProgressBar progressBar;
        private ControlsList orderItemControlsList;
        private ControlsList ticketItemControlsList;
        private ModulePagingNEW modulePagingNEW;
        private System.Windows.Forms.Label label_COM_State;
        private System.Windows.Forms.Label label4;
    }
}
