namespace Demo
{
    partial class FrmJcSingleLoad
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.controlsList1 = new Demo.ControlsList();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoScroll = true;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(570, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(359, 234);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // controlsList1
            // 
            this.controlsList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.controlsList1.E = null;
            this.controlsList1.Gap = 0;
            this.controlsList1.GapX = 0;
            this.controlsList1.HideScrollbar = false;
            this.controlsList1.IsAutoHideScroll = false;
            this.controlsList1.IsItemOrder = false;
            this.controlsList1.Location = new System.Drawing.Point(55, 71);
            this.controlsList1.Name = "controlsList1";
            this.controlsList1.Size = new System.Drawing.Size(281, 389);
            this.controlsList1.TabIndex = 0;
            // 
            // FrmJcSingleLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 579);
            this.Controls.Add(this.controlsList1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FrmJcSingleLoad";
            this.Text = "FrmJcSingleLoad";
            this.Load += new System.EventHandler(this.FrmJcSingleLoad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private ControlsList controlsList1;

    }
}