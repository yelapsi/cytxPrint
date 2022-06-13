namespace Demo
{
    partial class ModuleProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleProgressBar));
            this.bar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bar)).BeginInit();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bar.BackgroundImage")));
            this.bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bar.Location = new System.Drawing.Point(0, 0);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(315, 17);
            this.bar.TabIndex = 0;
            this.bar.TabStop = false;
            // 
            // ModuleProgressBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bar);
            this.Name = "ModuleProgressBar";
            this.Size = new System.Drawing.Size(315, 17);
            this.Load += new System.EventHandler(this.AmazingProgressBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bar;
    }
}
