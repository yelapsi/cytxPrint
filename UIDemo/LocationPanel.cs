using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class LocationPanel : UserControl
    {
        Control control = null;
        public LocationPanel()
        {
            InitializeComponent();
        }

        public LocationPanel(Control c)
        {
            InitializeComponent();
            control = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
        }
    }
}
