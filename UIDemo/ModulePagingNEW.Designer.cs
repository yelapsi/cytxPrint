namespace Demo
{
    partial class ModulePagingNEW
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
            this.lbTotalPageNumber = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBoxNowPage = new System.Windows.Forms.TextBox();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTotalPageNumber
            // 
            this.lbTotalPageNumber.AutoSize = true;
            this.lbTotalPageNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalPageNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalPageNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbTotalPageNumber.Location = new System.Drawing.Point(260, 4);
            this.lbTotalPageNumber.Name = "lbTotalPageNumber";
            this.lbTotalPageNumber.Size = new System.Drawing.Size(98, 17);
            this.lbTotalPageNumber.TabIndex = 8;
            this.lbTotalPageNumber.Text = "第{0}页，共{1}页";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Demo.Properties.Resources.framework;
            this.panel1.Controls.Add(this.tBoxNowPage);
            this.panel1.Location = new System.Drawing.Point(190, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(29, 22);
            this.panel1.TabIndex = 11;
            // 
            // tBoxNowPage
            // 
            this.tBoxNowPage.BackColor = System.Drawing.Color.White;
            this.tBoxNowPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tBoxNowPage.Location = new System.Drawing.Point(1, 3);
            this.tBoxNowPage.Name = "tBoxNowPage";
            this.tBoxNowPage.Size = new System.Drawing.Size(27, 14);
            this.tBoxNowPage.TabIndex = 9;
            this.tBoxNowPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBoxNowPage.TextChanged += new System.EventHandler(this.tBoxNowPage_TextChanged);
            // 
            // btnJump
            // 
            this.btnJump.BackgroundImage = global::Demo.Properties.Resources.locatePage;
            this.btnJump.FlatAppearance.BorderSize = 0;
            this.btnJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJump.Location = new System.Drawing.Point(218, 1);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(38, 22);
            this.btnJump.TabIndex = 10;
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.MouseLeave += new System.EventHandler(this.btnJump_MouseLeave);
            this.btnJump.MouseHover += new System.EventHandler(this.btnJump_MouseHover);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.White;
            this.btnLast.BackgroundImage = global::Demo.Properties.Resources.lastPage;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Enabled = false;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(150, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(37, 22);
            this.btnLast.TabIndex = 5;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.MouseLeave += new System.EventHandler(this.btnLast_MouseLeave);
            this.btnLast.MouseHover += new System.EventHandler(this.btnLast_MouseHover);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.BackgroundImage = global::Demo.Properties.Resources.firstPage;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Enabled = false;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(1, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(37, 22);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.MouseLeave += new System.EventHandler(this.btnFirst_MouseLeave);
            this.btnFirst.MouseHover += new System.EventHandler(this.btnFirst_MouseHover);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BackgroundImage = global::Demo.Properties.Resources.nextPage;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Enabled = false;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(98, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 22);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.MouseLeave += new System.EventHandler(this.btnNext_MouseLeave);
            this.btnNext.MouseHover += new System.EventHandler(this.btnNext_MouseHover);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.BackgroundImage = global::Demo.Properties.Resources.previousPage;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(46, 1);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(44, 22);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.MouseLeave += new System.EventHandler(this.btnPrevious_MouseLeave);
            this.btnPrevious.MouseHover += new System.EventHandler(this.btnPrevious_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lbTotalPageNumber);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnJump);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Location = new System.Drawing.Point(143, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 24);
            this.panel2.TabIndex = 12;
            // 
            // ModulePagingNEW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Name = "ModulePagingNEW";
            this.Size = new System.Drawing.Size(646, 24);
            this.Load += new System.EventHandler(this.ModulePagingNEW_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lbTotalPageNumber;
        private System.Windows.Forms.TextBox tBoxNowPage;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
