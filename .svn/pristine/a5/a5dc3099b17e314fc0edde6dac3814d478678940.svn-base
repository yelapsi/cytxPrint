using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common.model;

namespace Demo
{
    public partial class ItemMachineButton : UserControl
    {
        private bool selected = false;
        private store_machine machine;

        public ItemMachineButton()
        {
            InitializeComponent();
        }

        private void btn_Selected(object sender, EventArgs e)
        {
            this.Selected = true;
        }

        private void MachineButton_Load(object sender, EventArgs e)
        {
            this.Click += btn_Selected;
            this.label1.Click += btn_Selected;
            if (this.Selected)
            {
                this.BackgroundImage = global::Demo.Properties.Resources.xuanzhong;
                this.label1.ForeColor = Color.White;
            }
            else
            {
                this.BackgroundImage = global::Demo.Properties.Resources.weixuanzhong;
                this.label1.ForeColor = Color.Black;
            }
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;

                    Control c = this as Control;
                    while (c.GetType() != typeof(ModuleMachineButtonHolder))
                    {
                        c = c.Parent;
                    }
                    if (((ModuleMachineButtonHolder)c).CurrentMachine != null)
                        ((ModuleMachineButtonHolder)c).CurrentMachine.Selected = false;
                    ((ModuleMachineButtonHolder)c).CurrentMachine = this;

                    if (selected)
                    {
                        this.BackgroundImage = global::Demo.Properties.Resources.xuanzhong;
                        this.label1.ForeColor = Color.White;
                    }
                    else
                    {
                        this.BackgroundImage = global::Demo.Properties.Resources.weixuanzhong;
                        this.label1.ForeColor = Color.Black;
                    }
                }
            }
        }
        public store_machine Machine
        {
            get { return machine; }
            set { machine = value; }
        }
        public string MachineName
        {
            get { return this.label1.Text; }
            set
            {
                this.label1.Text = value;
            }
        }
    }
}
