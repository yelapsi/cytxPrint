using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ItemBetDetails : UserControl
    {
        public int Index
        {
            set
            {
                this.lbIndex.Text = value.ToString();
            }
        }

        public string Details
        {
            set
            {
                this.txtDetails.Text = value;
                int height = this.txtDetails.Lines.Length * 23;
                this.txtDetails.Height = height;
                this.Height = height;
            }
        }

        public ItemBetDetails()
        {
            InitializeComponent();
        }

        private void txtDetails_TextChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object o,EventArgs e2) {
                    this.Height = this.txtDetails.Height;
                }));
            }
            else
            {
                this.Height = this.txtDetails.Height;
            }
        }

        private void ItemBetDetails_Load(object sender, EventArgs e)
        {
            this.Height = this.txtDetails.Height;
        }
    }
}
