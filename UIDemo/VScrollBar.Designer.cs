namespace Demo
{
    partial class VScrollBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrollButton = new System.Windows.Forms.PictureBox();
            this.picBackgroundImgBottom = new System.Windows.Forms.PictureBox();
            this.picBackgroundImgTop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scrollButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImgBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImgTop)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollButton
            // 
            this.scrollButton.BackColor = System.Drawing.Color.Transparent;
            this.scrollButton.BackgroundImage = global::Demo.Properties.Resources.scrollbarButton;
            this.scrollButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.scrollButton.Location = new System.Drawing.Point(0, 0);
            this.scrollButton.Name = "scrollButton";
            this.scrollButton.Size = new System.Drawing.Size(8, 80);
            this.scrollButton.TabIndex = 0;
            this.scrollButton.TabStop = false;
            // 
            // picBackgroundImgBottom
            // 
            this.picBackgroundImgBottom.BackColor = System.Drawing.Color.Transparent;
            this.picBackgroundImgBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackgroundImgBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBackgroundImgBottom.Location = new System.Drawing.Point(0, 498);
            this.picBackgroundImgBottom.Name = "picBackgroundImgBottom";
            this.picBackgroundImgBottom.Size = new System.Drawing.Size(8, 2);
            this.picBackgroundImgBottom.TabIndex = 2;
            this.picBackgroundImgBottom.TabStop = false;
            // 
            // picBackgroundImgTop
            // 
            this.picBackgroundImgTop.BackColor = System.Drawing.Color.Transparent;
            this.picBackgroundImgTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackgroundImgTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picBackgroundImgTop.Location = new System.Drawing.Point(0, 0);
            this.picBackgroundImgTop.Name = "picBackgroundImgTop";
            this.picBackgroundImgTop.Size = new System.Drawing.Size(8, 2);
            this.picBackgroundImgTop.TabIndex = 1;
            this.picBackgroundImgTop.TabStop = false;
            // 
            // VScrollBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.scrollButton);
            this.Controls.Add(this.picBackgroundImgBottom);
            this.Controls.Add(this.picBackgroundImgTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VScrollBar";
            this.Size = new System.Drawing.Size(8, 500);
            this.Load += new System.EventHandler(this.VScrollBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrollButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImgBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundImgTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private System.Windows.Forms.PictureBox scrollButton;
        private System.Windows.Forms.PictureBox scrollButton;
        private System.Windows.Forms.PictureBox picBackgroundImgTop;
        private System.Windows.Forms.PictureBox picBackgroundImgBottom;
    }
}
