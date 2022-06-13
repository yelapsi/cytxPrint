using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModuleProgressBar : UserControl
    {
        private int value;
        public int Value
        {
            get { return this.value; }
            set
            {//百分比
                if (value <= 100)
                {
                    this.value = value;
                    fun(this.value);
                }
            }
        }
        public void Init()
        {
            this.bar.Size = this.Size;
            fun(this.value);
            //this.bar.Location = new Point(this.bar.Location.X - this.bar.Size.Width, this.bar.Location.Y);
        }
        public ModuleProgressBar()
        {
            InitializeComponent();
            this.Value = 0;
        }

        public void Increase(int value)
        {
            if (this.bar.Location.X <= 0)
            {
                this.bar.Location = new Point(this.bar.Location.X + value, this.bar.Location.Y);
            }
        }

        public void fun(int value)
        {
            float percentage = value*(1F) / 100;
            int fullLength = this.Width;

            this.bar.Location = new Point(((int)(fullLength * percentage - this.bar.Width)), this.bar.Location.Y);
        }

        private void AmazingProgressBar_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
