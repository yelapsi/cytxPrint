namespace Demo
{
    partial class LocationPanel
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "北京";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "上海";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "天津";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "长沙";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(85, 53);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 44);
            this.button5.TabIndex = 4;
            this.button5.Text = "河北";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(167, 53);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 44);
            this.button6.TabIndex = 5;
            this.button6.Text = "贵州";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 103);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(76, 44);
            this.button7.TabIndex = 6;
            this.button7.Text = "武汉";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // LocationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "LocationPanel";
            this.Size = new System.Drawing.Size(249, 329);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}
