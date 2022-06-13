using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Controller;

namespace Demo
{
    public partial class ItemSpreadWindow : UserControl
    {
        private bool spread = true;
        private int originalHeight;
        private ControlsList holder;

        private error_handling errorhand;
        private SystemSettingsController scontroller = new SystemSettingsController();

        public ItemSpreadWindow(error_handling eh)
        {
            InitializeComponent();
            this.errorhand = eh;
        }

        private void ItemSpreadWindow_Load(object sender, EventArgs e)
        {
            this.OriginalHeight = this.plBody.Height;
            this.Height = this.plHead.Height;
            this.plBody.Height = 0;

            this.labErrorTypeMsg.Text = this.errorhand.error_msg;
            this.selectHandlerWay = this.errorhand.handle_code ;

            this.extendFun();
        }

        private void plHead_Click(object sender, EventArgs e)
        {
            this.Spread = !this.Spread;
            try
            {
                ThreadPool.QueueUserWorkItem(spreadBody);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void fun(object o)
        {
           this.Holder.refreshLocationDelegate();
        }

        private void shrinkFun()
        {
            this.labErrorTypeMsg.ForeColor = Color.DimGray;
            //this.labErrorTypeMsg.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Height = this.plHead.Height;
            if (null != this.Holder)
                this.Holder.refreshLocationDelegate();
        }

        private void extendFun()
        {
            this.labErrorTypeMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(145)))), ((int)(((byte)(227)))));
            //this.labErrorTypeMsg.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Height = this.plHead.Height + this.OriginalHeight;
            if (null != this.Holder)
                this.Holder.refreshLocationDelegate();
        }

        private void spreadBody(object param)
        {
            if (this.Spread)
            {
                if (this.plBody.InvokeRequired)
                {
                    this.plBody.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.plHead.BackgroundImage = global::Demo.Properties.Resources.SpreadWindowOpen;
                        shrinkFun();
                    }));
                }
                else
                {
                    shrinkFun();
                }
            }
            else
            {
                if (this.plBody.InvokeRequired)
                {
                    this.plBody.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.plHead.BackgroundImage = global::Demo.Properties.Resources.SpreadWindowClose;
                        extendFun();
                    }));
                }
                else
                {
                    extendFun();
                }
            }
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updatebtn_Click(object sender, EventArgs e)
        {
            this.errorhand.handle_code = this.selectHandlerWay;
            try
            {
                if (this.scontroller.updateErrorHandling(this.errorhand))
                {
                    MsgBox.getInstance().Show("修改成功！", "提示", MsgBox.MyButtons.OK);
                }
                else
                {
                    MsgBox.getInstance().Show("修改失败！", "提示", MsgBox.MyButtons.OK);
                }
            }
            catch (Exception)
            {
                MsgBox.getInstance().Show("修改失败！", "提示", MsgBox.MyButtons.OK);
            }
        }
        public bool Spread
        {
            get { return spread; }
            set { spread = value; }
        }
        public int OriginalHeight
        {
            get { return originalHeight; }
            set { originalHeight = value; }
        }
        public ControlsList Holder
        {
            get { return holder; }
            set { holder = value; }
        }
        public Int64 selectHandlerWay
        {
            set
            {
                switch (value)
                {
                    case 1: this.radioBtnWay1.Checked = true; break;
                    case 2: this.radioBtnWay2.Checked = true; break;
                    case 3: this.radioBtnWay3.Checked = true; break;
                    case 4: this.radioBtnWay4.Checked = true; break;
                    default: this.radioBtnWay5.Checked = true; break;
                }
            }
            get
            {
                return this.radioBtnWay1.Checked ? 1 :
                    (this.radioBtnWay2.Checked ? 2 :
                    (this.radioBtnWay3.Checked ? 3 :
                    (this.radioBtnWay4.Checked ? 4 : 5)));
            }
        }

        private void updatebtn_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModificationEnter; 
        }

        private void updatebtn_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModification;
        }
    }
}
