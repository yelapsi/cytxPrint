using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemManualOrder : UserControl
    {
        private int bet_state;
        private long left_time;
        private bool selected;
        private EventHandler clicked;
        private lottery_order lotteryOrder;
        public long COMPLETE_TICKET_NUM { get; set; }

        public ItemManualOrder()
        {
            InitializeComponent();
        }

        public ItemManualOrder(lottery_order lo)
        {
            InitializeComponent();
            this.LotteryOrder = lo;
            this.COMPLETE_TICKET_NUM = lo.ticket_num + lo.errticket_num + lo.canceled_num;
        }

        private void ManualOrderItem_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);   //实例化Timer类，设置间隔时间为1000毫秒；   
            timer.Elapsed += new System.Timers.ElapsedEventHandler(theout); //到达时间的时候执行事件；   
            timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
            Init(this.LotteryOrder);
        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            if (this.Left_time > 0)
            {
                this.Left_time--;
            }
        }


        private void Init(lottery_order lottery_order)
        {
            this.pic1.Image = SysUtil.GetLicenseImg((lottery_order.license_id >= 100 && lottery_order.license_id < 200) ? "101" : lottery_order.license_id.ToString());

            this.lb1.Text = this.LotteryOrder.username;
            TimeSpan span = (TimeSpan)(Convert.ToDateTime(lottery_order.stop_time) - DateTime.Now);
            this.Left_time = (long)span.TotalSeconds;
            this.lb3.Text = this.LotteryOrder.total_tickets_num.ToString();
            this.lb4.Text = this.LotteryOrder.id.ToString();
            this.Pattern(int.Parse(this.LotteryOrder.bet_state));//设置控件为'正在打印'的样式
        }

        //把控件设置为'正在打印'样式
        private void Pattern(int betState)
        {
            switch (betState)
            {
                case GlobalConstants.ORDER_TICKET_STATE.PRINTTING://正在打印（正常票）
                    this.lb1.ForeColor = Color.White;
                    this.lb2.ForeColor = Color.White;
                    this.lb3.ForeColor = Color.White;
                    this.plTicket.BackgroundImage = global::Demo.Properties.Resources.w_piao;
                    this.BackgroundImage = global::Demo.Properties.Resources.l_x_bg;
                    break;
                case GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT://等待打印（错漏票）
                    this.lb1.ForeColor = Color.White;
                    this.lb2.ForeColor = Color.White;
                    this.lb3.ForeColor = Color.White;
                    this.plTicket.BackgroundImage = global::Demo.Properties.Resources.w_piao;
                    this.BackgroundImage = null;
                    this.BackColor = Color.Yellow;
                    break;
                case GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING://正在打印（错漏票）
                    this.lb1.ForeColor = Color.White;
                    this.lb2.ForeColor = Color.White;
                    this.lb3.ForeColor = Color.White;
                    this.plTicket.BackgroundImage = global::Demo.Properties.Resources.w_piao;
                    this.BackgroundImage = null;
                    this.BackColor = Color.Red;
                    break;
                case GlobalConstants.ORDER_TICKET_STATE.PAUSE://正在打印（错漏票）
                    this.lb1.ForeColor = Color.White;
                    this.lb2.ForeColor = Color.White;
                    this.lb3.ForeColor = Color.White;
                    this.plTicket.BackgroundImage = global::Demo.Properties.Resources.w_piao;
                    this.BackgroundImage = null;
                    this.BackColor = Color.Green;
                    break;
                default:
                    break;
            }
        }

        private void lb3_TextChanged(object sender, EventArgs e)
        {
            int charNum = this.Lb3.Text.Length;
            switch (charNum)
            {
                case 1:
                    this.Lb3.Location = new Point(9, this.Lb3.Location.Y);
                    break;
                case 2:
                    this.Lb3.Location = new Point(6, this.Lb3.Location.Y);
                    break;
                case 3:
                    this.Lb3.Location = new Point(5, this.Lb3.Location.Y);
                    break;
                case 4:
                    this.Lb3.Location = new Point(3, this.Lb3.Location.Y);
                    break;
                default:
                    this.Lb3.Location = new Point(0, this.Lb3.Location.Y);
                    break;
            }
        }

        public lottery_order LotteryOrder
        {
            get { return lotteryOrder; }
            set { lotteryOrder = value; }
        }


        public int betState
        {
            get { return bet_state; }
            set
            {
                bet_state = value;
                this.Pattern(bet_state);
            }
        }

        public long Left_time
        {
            get { return left_time; }
            set
            {
                left_time = value < 0 ? 0 : value;
                if (this.lb2.InvokeRequired)
                {
                    this.Lb2.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.Lb2.Text = this.left_time == 0 ? "有逾期票" : DateUtil.secondToHHmmss(this.left_time, 1);
                    }));
                }
                else
                {
                    this.Lb2.Text = this.left_time == 0 ? "有逾期票" : DateUtil.secondToHHmmss(this.left_time, 1);
                }
            }
        }

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

        public PictureBox Pic1
        {
            get { return this.pic1; }
        }

        public Panel PlTicket
        {
            get { return this.plTicket; }
        }
        public EventHandler Clicked
        {
            get { return this.clicked; }
            set
            {
                this.clicked += value;
                this.Click += this.clicked;
                this.lb1.Click += this.clicked;
                this.lb2.Click += this.clicked;
                this.lb3.Click += this.clicked;
                this.lb4.Click += this.clicked;
                this.pic1.Click += this.clicked;
                this.plTicket.Click += this.clicked;
            }
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected)
                {
                    this.BackgroundImage = global::Demo.Properties.Resources.hover_x;
                }
                else
                {
                    this.BackgroundImage = global::Demo.Properties.Resources.l_bg;
                }
            }
        }
    }
}
