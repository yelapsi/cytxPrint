namespace Demo
{
    partial class TabConfig
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
            this.configSettingAreaPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.moduleTitlebar = new Demo.ModuleTitlebar();
            this.menuControlsList = new Demo.ControlsList();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // configSettingAreaPanel
            // 
            this.configSettingAreaPanel.Location = new System.Drawing.Point(178, 32);
            this.configSettingAreaPanel.Name = "configSettingAreaPanel";
            this.configSettingAreaPanel.Size = new System.Drawing.Size(772, 550);
            this.configSettingAreaPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.pictureBox1.Location = new System.Drawing.Point(177, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 553);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // moduleTitlebar
            // 
            this.moduleTitlebar.BackgroundImage = global::Demo.Properties.Resources.zccjb;
            this.moduleTitlebar.Location = new System.Drawing.Point(0, 0);
            this.moduleTitlebar.Name = "moduleTitlebar";
            this.moduleTitlebar.remind = null;
            this.moduleTitlebar.Size = new System.Drawing.Size(950, 32);
            this.moduleTitlebar.TabIndex = 5;
            // 
            // menuControlsList
            // 
            this.menuControlsList.BackColor = System.Drawing.Color.White;
            this.menuControlsList.E = null;
            this.menuControlsList.Gap = 0;
            this.menuControlsList.GapX = 0;
            this.menuControlsList.HideScrollbar = false;
            this.menuControlsList.IsAutoHideScroll = false;
            this.menuControlsList.IsItemOrder = false;
            this.menuControlsList.Location = new System.Drawing.Point(0, 30);
            this.menuControlsList.Name = "menuControlsList";
            this.menuControlsList.Size = new System.Drawing.Size(177, 562);
            this.menuControlsList.TabIndex = 3;
            // 
            // TabConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.moduleTitlebar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuControlsList);
            this.Controls.Add(this.configSettingAreaPanel);
            this.Name = "TabConfig";
            this.Size = new System.Drawing.Size(948, 585);
            this.Load += new System.EventHandler(this.TabConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel configSettingAreaPanel;
        private ControlsList menuControlsList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ModuleTitlebar moduleTitlebar;
    }
}
