using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common;
using Maticsoft.Common.model.httpmodel;
using Maticsoft.Common.Util;
using Maticsoft.Controller;

namespace Demo
{
    public partial class FrmPassEnter : Form
    {
        public FrmPassEnter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 点击确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tBoxPass.Text.ToLower().Equals("9061mgw"))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }

            this.Close();
        }
    }
}
