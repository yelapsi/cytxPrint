using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmTxtShow : Form
    {
        public System.Windows.Forms.TextBox Txt
        {
            get { return txtContent; }
            set { txtContent = value; }
        }

        public FrmTxtShow()
        {
            InitializeComponent();
        }

        private void FrmClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnCloseEnter;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnClose;
        }
    }
}
