namespace Demo
{
    partial class ModulePaging
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
            this.cbIndex = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lbTotalPageNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbIndex
            // 
            this.cbIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIndex.FormattingEnabled = true;
            this.cbIndex.Location = new System.Drawing.Point(216, 2);
            this.cbIndex.Name = "cbIndex";
            this.cbIndex.Size = new System.Drawing.Size(44, 20);
            this.cbIndex.TabIndex = 3;
            this.cbIndex.SelectedIndexChanged += new System.EventHandler(this.cbIndex_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(195, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "第";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(264, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "页";
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.White;
            this.btnLast.BackgroundImage = global::Demo.Properties.Resources.lastPage;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(150, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(37, 22);
            this.btnLast.TabIndex = 5;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.lastPage);
            this.btnLast.MouseLeave += new System.EventHandler(this.btnLast_MouseLeave);
            this.btnLast.MouseHover += new System.EventHandler(this.btnLast_MouseHover);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.White;
            this.btnFirst.BackgroundImage = global::Demo.Properties.Resources.firstPage;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(1, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(37, 22);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.firstPage);
            this.btnFirst.MouseLeave += new System.EventHandler(this.btnFirst_MouseLeave);
            this.btnFirst.MouseHover += new System.EventHandler(this.btnFirst_MouseHover);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BackgroundImage = global::Demo.Properties.Resources.nextPage;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(98, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 22);
            this.btnNext.TabIndex = 1;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.nextPage);
            this.btnNext.MouseLeave += new System.EventHandler(this.btnNext_MouseLeave);
            this.btnNext.MouseHover += new System.EventHandler(this.btnNext_MouseHover);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.BackgroundImage = global::Demo.Properties.Resources.previousPage;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(46, 1);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(44, 22);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.previousPage);
            this.btnPrevious.MouseLeave += new System.EventHandler(this.btnPrevious_MouseLeave);
            this.btnPrevious.MouseHover += new System.EventHandler(this.btnPrevious_MouseHover);
            // 
            // lbTotalPageNumber
            // 
            this.lbTotalPageNumber.AutoSize = true;
            this.lbTotalPageNumber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalPageNumber.Location = new System.Drawing.Point(290, 4);
            this.lbTotalPageNumber.Name = "lbTotalPageNumber";
            this.lbTotalPageNumber.Size = new System.Drawing.Size(0, 17);
            this.lbTotalPageNumber.TabIndex = 8;
            // 
            // ModulePaging
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbTotalPageNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.cbIndex);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Name = "ModulePaging";
            this.Size = new System.Drawing.Size(380, 24);
            this.Load += new System.EventHandler(this.ModulePaging_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cbIndex;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalPageNumber;
    }
}
