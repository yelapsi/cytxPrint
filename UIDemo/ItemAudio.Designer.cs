﻿namespace Demo
{
    partial class ItemAudio
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
            this.radioButton = new System.Windows.Forms.RadioButton();
            this.btnSaveOrSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton
            // 
            this.radioButton.AutoSize = true;
            this.radioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton.Location = new System.Drawing.Point(34, 6);
            this.radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton.Name = "radioButton";
            this.radioButton.Size = new System.Drawing.Size(14, 13);
            this.radioButton.TabIndex = 0;
            this.radioButton.TabStop = true;
            this.radioButton.UseVisualStyleBackColor = true;
            this.radioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // btnSaveOrSelected
            // 
            this.btnSaveOrSelected.BackgroundImage = global::Demo.Properties.Resources.btnSave;
            this.btnSaveOrSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveOrSelected.FlatAppearance.BorderSize = 0;
            this.btnSaveOrSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrSelected.Location = new System.Drawing.Point(643, -1);
            this.btnSaveOrSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveOrSelected.Name = "btnSaveOrSelected";
            this.btnSaveOrSelected.Size = new System.Drawing.Size(42, 24);
            this.btnSaveOrSelected.TabIndex = 2;
            this.btnSaveOrSelected.UseVisualStyleBackColor = true;
            this.btnSaveOrSelected.Visible = false;
            this.btnSaveOrSelected.MouseEnter += new System.EventHandler(this.btnSaveAudio_MouseEnter);
            this.btnSaveOrSelected.MouseLeave += new System.EventHandler(this.btnSaveAudio_MouseLeave);
            // 
            // ItemAudio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Demo.Properties.Resources.ItemAudio;
            this.Controls.Add(this.btnSaveOrSelected);
            this.Controls.Add(this.radioButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItemAudio";
            this.Size = new System.Drawing.Size(703, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton;
        private System.Windows.Forms.Button btnSaveOrSelected;
    }
}
