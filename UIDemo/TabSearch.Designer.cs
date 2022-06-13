namespace Demo
{
    partial class TabSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitleOperation = new System.Windows.Forms.Label();
            this.lbTitleTime = new System.Windows.Forms.Label();
            this.lbTitleDetails = new System.Windows.Forms.Label();
            this.lbTitleLicense = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbLicense = new System.Windows.Forms.ComboBox();
            this.cBoxOrderState = new System.Windows.Forms.ComboBox();
            this.tbOrderId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.controlsList = new Demo.ControlsList();
            this.moduleTitlebar = new Demo.ModuleTitlebar();
            this.modulePagingNEW = new ModulePagingNEW();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BackgroundImage = global::Demo.Properties.Resources.topBackImg01;
            this.panel1.Controls.Add(this.lbTitleOperation);
            this.panel1.Controls.Add(this.lbTitleTime);
            this.panel1.Controls.Add(this.lbTitleDetails);
            this.panel1.Controls.Add(this.lbTitleLicense);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 30);
            this.panel1.TabIndex = 11;
            // 
            // lbTitleOperation
            // 
            this.lbTitleOperation.AutoSize = true;
            this.lbTitleOperation.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleOperation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleOperation.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleOperation.Location = new System.Drawing.Point(844, 9);
            this.lbTitleOperation.Name = "lbTitleOperation";
            this.lbTitleOperation.Size = new System.Drawing.Size(29, 12);
            this.lbTitleOperation.TabIndex = 9;
            this.lbTitleOperation.Text = "操作";
            // 
            // lbTitleTime
            // 
            this.lbTitleTime.AutoSize = true;
            this.lbTitleTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleTime.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleTime.Location = new System.Drawing.Point(689, 9);
            this.lbTitleTime.Name = "lbTitleTime";
            this.lbTitleTime.Size = new System.Drawing.Size(53, 12);
            this.lbTitleTime.TabIndex = 8;
            this.lbTitleTime.Text = "出票时间";
            // 
            // lbTitleDetails
            // 
            this.lbTitleDetails.AutoSize = true;
            this.lbTitleDetails.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleDetails.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleDetails.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleDetails.Location = new System.Drawing.Point(345, 9);
            this.lbTitleDetails.Name = "lbTitleDetails";
            this.lbTitleDetails.Size = new System.Drawing.Size(53, 12);
            this.lbTitleDetails.TabIndex = 7;
            this.lbTitleDetails.Text = "彩种详情";
            // 
            // lbTitleLicense
            // 
            this.lbTitleLicense.AutoSize = true;
            this.lbTitleLicense.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleLicense.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitleLicense.ForeColor = System.Drawing.Color.DimGray;
            this.lbTitleLicense.Location = new System.Drawing.Point(48, 9);
            this.lbTitleLicense.Name = "lbTitleLicense";
            this.lbTitleLicense.Size = new System.Drawing.Size(53, 12);
            this.lbTitleLicense.TabIndex = 6;
            this.lbTitleLicense.Text = "彩种名称";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.cbLicense);
            this.panel2.Controls.Add(this.cBoxOrderState);
            this.panel2.Controls.Add(this.tbOrderId);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 34);
            this.panel2.TabIndex = 13;
            // 
            // cbLicense
            // 
            this.cbLicense.BackColor = System.Drawing.Color.White;
            this.cbLicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicense.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbLicense.FormattingEnabled = true;
            this.cbLicense.Location = new System.Drawing.Point(42, 4);
            this.cbLicense.Name = "cbLicense";
            this.cbLicense.Size = new System.Drawing.Size(93, 25);
            this.cbLicense.TabIndex = 6;
            // 
            // cBoxOrderState
            // 
            this.cBoxOrderState.BackColor = System.Drawing.Color.White;
            this.cBoxOrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxOrderState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBoxOrderState.FormattingEnabled = true;
            this.cBoxOrderState.Location = new System.Drawing.Point(196, 4);
            this.cBoxOrderState.Name = "cBoxOrderState";
            this.cBoxOrderState.Size = new System.Drawing.Size(93, 25);
            this.cBoxOrderState.TabIndex = 17;
            // 
            // tbOrderId
            // 
            this.tbOrderId.BackColor = System.Drawing.Color.White;
            this.tbOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOrderId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOrderId.ForeColor = System.Drawing.Color.Black;
            this.tbOrderId.Location = new System.Drawing.Point(350, 5);
            this.tbOrderId.Name = "tbOrderId";
            this.tbOrderId.Size = new System.Drawing.Size(93, 23);
            this.tbOrderId.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(159, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "状态：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "彩种：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(313, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "单号：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::Demo.Properties.Resources.btnSearch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearch.Location = new System.Drawing.Point(887, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(49, 24);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseHover);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // controlsList
            // 
            this.controlsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(244)))));
            this.controlsList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsList.E = null;
            this.controlsList.Gap = 0;
            this.controlsList.GapX = 0;
            this.controlsList.HideScrollbar = false;
            this.controlsList.IsAutoHideScroll = false;
            this.controlsList.IsItemOrder = false;
            this.controlsList.Location = new System.Drawing.Point(0, 96);
            this.controlsList.Margin = new System.Windows.Forms.Padding(4);
            this.controlsList.Name = "controlsList";
            this.controlsList.Size = new System.Drawing.Size(950, 462);
            this.controlsList.TabIndex = 10;
            // 
            // moduleTitlebar
            // 
            this.moduleTitlebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moduleTitlebar.BackgroundImage")));
            this.moduleTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleTitlebar.Location = new System.Drawing.Point(0, 0);
            this.moduleTitlebar.Name = "moduleTitlebar";
            this.moduleTitlebar.remind = null;
            this.moduleTitlebar.Size = new System.Drawing.Size(950, 32);
            this.moduleTitlebar.TabIndex = 12;
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
            this.modulePagingNEW.Location = new System.Drawing.Point(0, 0);
            this.modulePagingNEW.MaxPage = 0;
            this.modulePagingNEW.Name = "modulePagingNEW";
            this.modulePagingNEW.NowPage = 0;
            this.modulePagingNEW.Size = new System.Drawing.Size(940, 24);
            this.modulePagingNEW.TabIndex = 0;
            // 
            // TabSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.controlsList);
            this.Controls.Add(this.moduleTitlebar);
            this.Name = "TabSearch";
            this.Size = new System.Drawing.Size(950, 558);
            this.Load += new System.EventHandler(this.TabSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsList controlsList;
        private System.Windows.Forms.Label lbTitleOperation;
        private System.Windows.Forms.Label lbTitleTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitleDetails;
        private System.Windows.Forms.Label lbTitleLicense;
        private ModuleTitlebar moduleTitlebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbLicense;
        private ModulePagingNEW modulePagingNEW = new ModulePagingNEW();
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOrderId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxOrderState;
        private System.Windows.Forms.Label label3;
    }
}
