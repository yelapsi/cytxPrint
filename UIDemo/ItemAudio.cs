﻿using System;
using System.Windows.Forms;

namespace Demo
{
    public partial class ItemAudio : UserControl
    {
        private string audioFileFullName;

        private bool selected = false;

        public ItemAudio()
        {
            InitializeComponent();
        }

        private void btnSaveAudio_MouseEnter(object sender, EventArgs e)
        {
            this.btnSaveOrSelected.BackgroundImage = global::Demo.Properties.Resources.btnSaveEnter;
        }

        private void btnSaveAudio_MouseLeave(object sender, EventArgs e)
        {
            this.btnSaveOrSelected.BackgroundImage = global::Demo.Properties.Resources.btnSave;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButton.Checked && !this.Selected)
            {
                this.BtnSave.Visible = false;
            }
        }

        public string AudioFileFullName
        {
            get { return audioFileFullName; }
            set { audioFileFullName = value; }
        }

        public RadioButton RadioButton
        {
            get { return radioButton; }
        }

        public Button BtnSave
        {
            get { return this.btnSaveOrSelected; }
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected)
                {
                    this.btnSaveOrSelected.BackgroundImage = global::Demo.Properties.Resources.btnSelected;
                    this.btnSaveOrSelected.Enabled = false;
                    this.btnSaveOrSelected.Visible = true;
                }
                else
                {
                    this.btnSaveOrSelected.BackgroundImage = global::Demo.Properties.Resources.btnSave;
                    this.btnSaveOrSelected.Enabled = true;
                }
            }
        }
    }
}
