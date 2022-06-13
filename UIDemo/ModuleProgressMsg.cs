using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModuleProgressMsg : UserControl
    {
        private String[] stateMsg = new String[] {"等待出票","正在出票"};
        private int state = 0;
        private int allticket = 0;
        private int printticket = 0;

        public ModuleProgressMsg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载控件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModuleProgressMsg_Load(object sender, EventArgs e)
        {

        }

         /// <summary>
        /// 初始化位置
        /// </summary>
        private void initPosition()
        {
            this.Invoke(new EventHandler(delegate(object o, EventArgs e)
            {
                this.labPrintState.Text = stateMsg[(this.state == 0 || this.state == 1) ? this.state : 0];
                this.labAllTicketNum.Text = this.allticket.ToString();
                this.labCompTicketNum.Text = this.printticket.ToString();

                this.labTextTwo.Location = new Point(this.labAllTicketNum.Location.X + this.labAllTicketNum.Width, 0);
                this.labCompTicketNum.Location = new Point(this.labTextTwo.Location.X + this.labTextTwo.Width, 0);
                this.labTextThree.Location = new Point(this.labCompTicketNum.Location.X + this.labCompTicketNum.Width, 0);
            }));            
        }

        /// <summary>
        /// 刷新位置
        /// </summary>
        /// <param name="comTicketNum"></param>
        public void refreshPosition(int state, int allticket, int comTicketNum)
        {
            this.state = state;
            this.allticket = allticket;
            this.printticket = comTicketNum;

            this.Invoke(new EventHandler(delegate(object o, EventArgs e)
            {
                this.labPrintState.Text = stateMsg[(this.state == 0 || this.state == 1) ? this.state : 0];
                this.labAllTicketNum.Text = this.allticket.ToString();
                this.labCompTicketNum.Text = this.printticket.ToString();

                this.labTextTwo.Location = new Point(this.labAllTicketNum.Location.X + this.labAllTicketNum.Width, 0);
                this.labCompTicketNum.Location = new Point(this.labTextTwo.Location.X + this.labTextTwo.Width, 0);
                this.labTextThree.Location = new Point(this.labCompTicketNum.Location.X + this.labCompTicketNum.Width, 0);
            }));           
        }
    }
}
