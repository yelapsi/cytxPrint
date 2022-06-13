using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModuleCornerMark : UserControl
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                this._number = value;
                if (this.lbNumber.InvokeRequired)
                {
                    this.lbNumber.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        if (value > 0)
                        {
                            this.Visible = true;
                            if (!this.lbNumber.Text.Equals(value.ToString()))
                            {
                                int len = value.ToString().Length;                                
                                if (len == 1)
                                {
                                    this.lbNumber.Text = value.ToString();
                                    this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit1;
                                }
                                else if (len == 2)
                                {
                                    this.lbNumber.Text = value.ToString();
                                    this.lbNumber.Location = new Point((this.lbNumber.Location.X), this.lbNumber.Location.Y);
                                    this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit2;
                                    this.Size = this.BackgroundImage.Size;
                                }
                                else
                                {
                                    this.lbNumber.Text = "";
                                    this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit3;
                                    this.Size = this.BackgroundImage.Size;
                                }
                            }
                        }
                        else
                        {
                            this.Visible = false;
                        }
                    }));
                }
                else
                {
                    if (value > 0 )
                    {
                        this.Visible = true;
                        if (!this.lbNumber.Text.Equals(value.ToString()))
                        {
                            int len = value.ToString().Length;                            
                            if (len == 1)
                            {
                                this.lbNumber.Text = value.ToString();
                                this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit1;
                            }
                            else if (len == 2)
                            {
                                this.lbNumber.Text = value.ToString();
                                this.lbNumber.Location = new Point((this.lbNumber.Location.X), this.lbNumber.Location.Y);
                                this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit2;
                                this.Size = this.BackgroundImage.Size;
                            }
                            else
                            {
                                this.lbNumber.Text = "";
                                this.BackgroundImage = global::Demo.Properties.Resources.cornerMark_bit3;
                                this.Size = this.BackgroundImage.Size;
                            }
                        }
                    }
                    else
                    {
                        this.Visible = false;
                    }
                }
            }
        }

        public Label lbCornerMark
        {
            get
            {
                return this.lbNumber;
            }
        }

        public ModuleCornerMark()
        {
            InitializeComponent();
        }

        private void ModuleCornerMark_Load(object sender, EventArgs e)
        {
            this.Number = this._number;
        }
    }
}
