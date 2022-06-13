using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModuleTotalTicketsPrice : UserControl
    {
        private string _value;

        public Label Lb1
        {
            get { return this.lb1; }
        }
        public Label Lb2
        {
            get { return this.lb2; }
        }
        public Label Lb3
        {
            get { return this.lb3; }
        }
        public Label Lb4
        {
            get { return this.lb4; }
        }
        public Label Lb5
        {
            get { return this.lb5; }
        }
        public Label Lb6
        {
            get { return this.lb6; }
        }
        public Label Lb7
        {
            get { return this.lb7; }
        }

        public string value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (null != value)
                {
                    if (_value.Length > 7)
                    {
                        _value = _value.Substring(0, 7);
                    }
                    else if (_value.Length < 7)
                    {
                        int len = 7 - _value.Length;
                        for (int i = 0; i < len; i++)
                        {
                            _value = "0" + _value;
                        }
                    }
                    char[] numArr = _value.ToCharArray();
                    this.Lb1.Text = numArr[6].ToString();
                    this.Lb2.Text = numArr[5].ToString();
                    this.Lb3.Text = numArr[4].ToString();
                    this.Lb4.Text = numArr[3].ToString();
                    this.Lb5.Text = numArr[2].ToString();
                    this.Lb6.Text = numArr[1].ToString();
                    this.Lb7.Text = numArr[0].ToString();
                }
            }
        }

        public ModuleTotalTicketsPrice()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.value = "0";
        }
    }
}
