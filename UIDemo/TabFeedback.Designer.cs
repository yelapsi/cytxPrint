namespace Demo
{
    partial class TabFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabFeedback));
            this.plFeedbackTitle = new System.Windows.Forms.Panel();
            this.btnSort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTitleOperation = new System.Windows.Forms.Label();
            this.lbTitleTime = new System.Windows.Forms.Label();
            this.lbTitleDetails = new System.Windows.Forms.Label();
            this.lbTitleLicense = new System.Windows.Forms.Label();
            this.plBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.PictureBox();
            this.btnFeedbackAll = new System.Windows.Forms.Button();
            this.feedbackList = new Demo.ControlsList();
            this.moduleTitlebar = new Demo.ModuleTitlebar();
            this.picBoxWaiting = new System.Windows.Forms.PictureBox();
            this.plFeedbackTitle.SuspendLayout();
            this.modulePagingNEW = new ModulePagingNEW();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWaiting)).BeginInit();
            this.SuspendLayout();
            // 
            // plFeedbackTitle
            // 
            this.plFeedbackTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plFeedbackTitle.BackgroundImage = global::Demo.Properties.Resources.line_3;
            this.plFeedbackTitle.Controls.Add(this.btnSort);
            this.plFeedbackTitle.Controls.Add(this.label2);
            this.plFeedbackTitle.Controls.Add(this.lbTitleOperation);
            this.plFeedbackTitle.Controls.Add(this.lbTitleTime);
            this.plFeedbackTitle.Controls.Add(this.lbTitleDetails);
            this.plFeedbackTitle.Controls.Add(this.lbTitleLicense);
            this.plFeedbackTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.plFeedbackTitle.Location = new System.Drawing.Point(0, 32);
            this.plFeedbackTitle.Name = "plFeedbackTitle";
            this.plFeedbackTitle.Size = new System.Drawing.Size(950, 30);
            this.plFeedbackTitle.TabIndex = 4;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(907, 3);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(23, 23);
            this.btnSort.TabIndex = 7;
            this.btnSort.Text = "排";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Visible = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(790, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "详情";
            // 
            // lbTitleOperation
            // 
            this.lbTitleOperation.AutoSize = true;
            this.lbTitleOperation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleOperation.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleOperation.Location = new System.Drawing.Point(872, 9);
            this.lbTitleOperation.Name = "lbTitleOperation";
            this.lbTitleOperation.Size = new System.Drawing.Size(29, 12);
            this.lbTitleOperation.TabIndex = 5;
            this.lbTitleOperation.Text = "操作";
            // 
            // lbTitleTime
            // 
            this.lbTitleTime.AutoSize = true;
            this.lbTitleTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleTime.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleTime.Location = new System.Drawing.Point(697, 9);
            this.lbTitleTime.Name = "lbTitleTime";
            this.lbTitleTime.Size = new System.Drawing.Size(53, 12);
            this.lbTitleTime.TabIndex = 4;
            this.lbTitleTime.Text = "出票时间";
            // 
            // lbTitleDetails
            // 
            this.lbTitleDetails.AutoSize = true;
            this.lbTitleDetails.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleDetails.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleDetails.Location = new System.Drawing.Point(415, 9);
            this.lbTitleDetails.Name = "lbTitleDetails";
            this.lbTitleDetails.Size = new System.Drawing.Size(53, 12);
            this.lbTitleDetails.TabIndex = 3;
            this.lbTitleDetails.Text = "彩种详情";
            // 
            // lbTitleLicense
            // 
            this.lbTitleLicense.AutoSize = true;
            this.lbTitleLicense.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleLicense.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleLicense.Location = new System.Drawing.Point(49, 9);
            this.lbTitleLicense.Name = "lbTitleLicense";
            this.lbTitleLicense.Size = new System.Drawing.Size(53, 12);
            this.lbTitleLicense.TabIndex = 2;
            this.lbTitleLicense.Text = "彩种名称";
            // 
            // plBottom
            // 
            this.plBottom.BackColor = System.Drawing.Color.Transparent;
            this.plBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plBottom.BackgroundImage")));
            this.plBottom.Controls.Add(this.label1);
            this.plBottom.Controls.Add(this.checkBoxAll);
            this.plBottom.Controls.Add(this.btnFeedbackAll);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 525);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(950, 40);
            this.plBottom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "全选";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.BackgroundImage = global::Demo.Properties.Resources.mxz;
            this.checkBoxAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAll.Location = new System.Drawing.Point(21, 12);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(16, 16);
            this.checkBoxAll.TabIndex = 20;
            this.checkBoxAll.TabStop = false;
            this.checkBoxAll.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // btnFeedbackAll
            // 
            this.btnFeedbackAll.BackColor = System.Drawing.Color.Transparent;
            this.btnFeedbackAll.BackgroundImage = global::Demo.Properties.Resources.feedbackAll1;
            this.btnFeedbackAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFeedbackAll.FlatAppearance.BorderSize = 0;
            this.btnFeedbackAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedbackAll.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFeedbackAll.ForeColor = System.Drawing.Color.White;
            this.btnFeedbackAll.Location = new System.Drawing.Point(821, 4);
            this.btnFeedbackAll.Name = "btnFeedbackAll";
            this.btnFeedbackAll.Size = new System.Drawing.Size(89, 32);
            this.btnFeedbackAll.TabIndex = 1;
            this.btnFeedbackAll.UseVisualStyleBackColor = false;
            this.btnFeedbackAll.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // feedbackList
            // 
            this.feedbackList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.feedbackList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.feedbackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbackList.E = null;
            this.feedbackList.Gap = 0;
            this.feedbackList.GapX = 0;
            this.feedbackList.HideScrollbar = false;
            this.feedbackList.IsAutoHideScroll = true;
            this.feedbackList.IsItemOrder = false;
            this.feedbackList.Location = new System.Drawing.Point(0, 62);
            this.feedbackList.Margin = new System.Windows.Forms.Padding(4);
            this.feedbackList.Name = "feedbackList";
            this.feedbackList.Size = new System.Drawing.Size(950, 463);
            this.feedbackList.TabIndex = 6;
            this.feedbackList.Load += new System.EventHandler(this.feedbackList_Load);
            // 
            // moduleTitlebar
            // 
            this.moduleTitlebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moduleTitlebar.BackgroundImage")));
            this.moduleTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleTitlebar.Location = new System.Drawing.Point(0, 0);
            this.moduleTitlebar.Name = "moduleTitlebar";
            this.moduleTitlebar.remind = null;
            this.moduleTitlebar.Size = new System.Drawing.Size(950, 32);
            this.moduleTitlebar.TabIndex = 7;
            // 
            // picBoxWaiting
            // 
            this.picBoxWaiting.BackColor = System.Drawing.Color.White;
            this.picBoxWaiting.Image = global::Demo.Properties.Resources.waiting;
            this.picBoxWaiting.Location = new System.Drawing.Point(455, 255);
            this.picBoxWaiting.Name = "picBoxWaiting";
            this.picBoxWaiting.Size = new System.Drawing.Size(35, 35);
            this.picBoxWaiting.TabIndex = 8;
            this.picBoxWaiting.TabStop = false;
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
            this.modulePagingNEW.Location = new System.Drawing.Point(285, 497);
            this.modulePagingNEW.MaxPage = 0;
            this.modulePagingNEW.Name = "modulePagingNEW";
            this.modulePagingNEW.NowPage = 0;
            this.modulePagingNEW.Size = new System.Drawing.Size(940, 24);
            this.modulePagingNEW.TabIndex = 0;
            // 
            // TabFeedback
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.picBoxWaiting);
            this.Controls.Add(this.feedbackList);
            this.Controls.Add(this.plFeedbackTitle);
            this.Controls.Add(this.moduleTitlebar);
            this.Controls.Add(this.plBottom);
            this.Name = "TabFeedback";
            this.Size = new System.Drawing.Size(950, 565);
            this.Load += new System.EventHandler(this.CYTXLotteryFeedbackTab_Load);
            this.plFeedbackTitle.ResumeLayout(false);
            this.plFeedbackTitle.PerformLayout();
            this.plBottom.ResumeLayout(false);
            this.plBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWaiting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plFeedbackTitle;
        private System.Windows.Forms.Label lbTitleOperation;
        private System.Windows.Forms.Label lbTitleTime;
        private System.Windows.Forms.Label lbTitleDetails;
        private System.Windows.Forms.Label lbTitleLicense;
        private System.Windows.Forms.Panel plBottom;
        private System.Windows.Forms.Button btnFeedbackAll;
        private ControlsList feedbackList;
        private System.Windows.Forms.PictureBox checkBoxAll;
        private System.Windows.Forms.Label label1;
        private ModuleTitlebar moduleTitlebar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSort;
        private ModulePagingNEW modulePagingNEW;
        private System.Windows.Forms.PictureBox picBoxWaiting;
    }
}
