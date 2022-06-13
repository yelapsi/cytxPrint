using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModuleTitlebar : UserControl
    {
        public ModuleTitlebar()
        {
            InitializeComponent();
        }


        private String _remind;
        public String remind
        {
            get { return this._remind; }             
            set {
                this._remind = value;
                if (this.lbRemind.InvokeRequired)
                {
                    this.lbRemind.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.lbRemind.Text = value;
                    }));
                }
                else {
                    this.lbRemind.Text = value;
                }
                
            } }
    }
}
