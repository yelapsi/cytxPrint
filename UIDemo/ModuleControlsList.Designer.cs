namespace Demo
{
    partial class ControlsList
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
            this.plParent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plParent
            // 
            this.plParent.BackColor = System.Drawing.Color.Transparent;
            this.plParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plParent.Location = new System.Drawing.Point(0, 0);
            this.plParent.Name = "plParent";
            this.plParent.Size = this.Size;
            this.plParent.TabIndex = 0;
            // 
            // ControlsList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.plParent);
            this.Name = "ControlsList";
            this.Load += new System.EventHandler(this.ControlsList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plParent;
    }
}
