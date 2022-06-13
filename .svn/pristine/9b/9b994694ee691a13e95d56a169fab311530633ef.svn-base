using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ControlsList : UserControl
    {
        //当ControlList内部的控件高度不足满屏高度时，是否自动隐藏滚动条
        private bool isAutoHideScroll = false;

        //控件间距
        private int gap;
        //控件的横坐标
        private int gapX;
        private bool isItemOrder = false;
        
        //用来隐藏或显示分页控件的委托
        public delegate void ShowPaging(bool isVisible);
        public ShowPaging showPaging = null;

        public bool IsItemOrder
        {
            get { return isItemOrder; }
            set { isItemOrder = value; }
        }
        public int Gap
        {
            get { return gap; }
            set { gap = value; }
        }
        public int GapX
        {
            get { return gapX; }
            set { gapX = value; }
        }

        public bool IsAutoHideScroll
        {
            get { return isAutoHideScroll; }
            set { isAutoHideScroll = value; }
        }

        //控件容器controlList
        private Panel controlList = new Panel();

        public Panel ControlList
        {
            get { return controlList; }
            set { controlList = value; }
        }
        private String controlListLock = Guid.NewGuid().ToString();//资源锁
        public String ControlListLock
        {
            get { return controlListLock; }
        }
        //controlList中元素的个数
        public int Count
        {
            get
            {
                return this.controlList.Controls.Count;
            }
        }

        private bool hideScrollbar = false;

        public bool HideScrollbar
        {
            get { return hideScrollbar; }
            set
            {
                hideScrollbar = value;
                if (hideScrollbar)
                {
                    this.VScrollBar.Visible = false;
                    if (this.plParent.InvokeRequired)
                    {
                        this.plParent.Invoke(new EventHandler(delegate(object o, EventArgs e)
                        {
                            this.plParent.Controls.Remove(this.vScrollBar);
                            this.controlList.Width = this.plParent.Width;
                        }));
                    }
                    else
                    {
                        this.plParent.Controls.Remove(this.vScrollBar);
                        this.controlList.Width = this.plParent.Width;
                    }
                }
            }
        }
        //滚动条
        private VScrollBar vScrollBar = new VScrollBar();
        public VScrollBar VScrollBar
        {
            get { return vScrollBar; }
        }

        public ControlsList()
        {
            InitializeComponent();
        }

        public ControlsList(bool _isAutoHideScroll)
        {
            InitializeComponent();
            this.IsAutoHideScroll = _isAutoHideScroll;
        }

        //（临时方法）后期由用户自定义事件替换，根据控件的Size属性设置controlList和scrollBar的位置和大小
        public void Init()
        {
            InitializeScrol();
            InitializeControlList();
        }
        //初始化controlList
        private void InitializeControlList()
        {
            lock (this.ControlListLock)
            {
                this.controlList.Location = new System.Drawing.Point(0, 0);
                this.controlList.Name = "controlList";
                this.controlList.Size = new System.Drawing.Size(this.Size.Width - this.vScrollBar.Width, 0);
                this.controlList.TabIndex = 0;
                this.plParent.Controls.Add(this.controlList);
            }
        }

        //初始化
        private void InitializeScrol()
        {
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Width = 10;
            this.vScrollBar.Size = new System.Drawing.Size(this.vScrollBar.Width, this.Height);
            this.vScrollBar.TabIndex = 1;
            this.vScrollBar.Location = new System.Drawing.Point(this.Width - this.vScrollBar.Width, 0);
            this.vScrollBar.ScrollButton.MouseMove += new MouseEventHandler(this.vScrollBar_Scroll);
            this.plParent.Controls.Add(this.vScrollBar);
        }

        /// <summary>
        /// 判断控件类型是否是ItemOrder
        /// </summary>
        private void GetTypeOfItem(Control control)
        {
            if (typeof(ItemOrder) == control.GetType())
            {
                this.IsItemOrder = true;
            }
        }

        //向容器里添加一个控件
        public void Add(Control control)
        {
            if (control != null)
            {
                Sort(control);
                if (this.controlList.InvokeRequired)
                {
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        if (control.InvokeRequired)
                        {
                            control.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                            {
                                this.controlList.Controls.Add(control);
                            }));
                        }
                        else
                        {
                            this.controlList.Controls.Add(control);
                        }
                    }));
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {//重新计算所有控件的高度总和
                        this.SetHigh(heightColculate(this.controlList.Controls));
                    }));
                }
                else
                {
                    this.controlList.Controls.Add(control);
                    this.SetHigh(heightColculate(this.controlList.Controls));
                }

                //给ItemOrder控件添加拖动事件
                DragInitialize(control);

                //初始化ItemOrder的双向链表
                DoubleDirectionListInitialization();
            }
        }
        //初始化ItemOrder的双向链表
        private void DoubleDirectionListInitialization()
        {
            if (this.IsItemOrder)
            {
                if (this.controlList.Controls.Count > 1)
                {
                    int i = 0;
                    ItemOrder previous = null;
                    foreach (ItemOrder oi in this.controlList.Controls)
                    {
                        if (i == 0)
                        {
                            previous = oi;
                            i++;
                        }
                        else
                        {
                            oi.Previous = previous;
                            previous.Next = oi;
                            previous = oi;
                        }

                        oi.OriginalLocation = oi.Location;
                    }
                }
            }
        }

        //向容器里添加多个控件
        public void AddRange(IList<Control> list)
        {
            foreach (Control c in list)
            {
                Add(c);
            }
        }

        //向容器插入一个控件
        public void Insert(int index, Control c)
        {
            ControlCollection cc = this.controlList.Controls;

            IList<Control> cListTemp = new List<Control>();

            for (int i = 0; i < this.controlList.Controls.Count; i++)
            {
                if (i == index)
                {
                    cListTemp.Add(c);
                }
                cListTemp.Add(this.controlList.Controls[i]);
            }
            this.Clear();
            this.AddRange(cListTemp);
            //初始化ItemOrder的双向链表
            DoubleDirectionListInitialization();
        }

        //向容器插入多个控件
        public void InsertRange(int index, List<Control> cList)
        {
            IList<Control> cListTemp = new List<Control>();

            for (int i = 0; i <= this.controlList.Controls.Count; i++)
            {
                if (i == index)
                {
                    foreach (Control c in cList)
                    {
                        DragUnInitialize(c);
                        cListTemp.Add(c);
                    }
                }
                if (this.controlList.Controls.Count > 0 && i < this.controlList.Controls.Count)
                {
                    DragUnInitialize(this.controlList.Controls[i]);
                    cListTemp.Add(this.controlList.Controls[i]);
                }
            }

            this.Clear();
            this.AddRange(cListTemp);
        }

        //清除controlList的所有控件
        public void Clear()
        {
            if (this.controlList.InvokeRequired)
            {
                this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                {
                    this.controlList.Controls.Clear();
                    this.controlList.Location = new Point(0, 0);
                    this.vScrollBar.Value = 0;
                }));
            }
            else
            {
                this.controlList.Controls.Clear();
                this.controlList.Location = new Point(0, 0);
                this.vScrollBar.Value = 0;
            }
        }

        //返回当前一个contrlList中当前所有控件的List
        public List<Control> GetControlList()
        {
            List<Control> cList = new List<Control>();
            foreach (Control c in this.controlList.Controls)
            {
                cList.Add(c);
            }
            return cList;
        }

        //设置controlList的高度
        public void SetHigh(int high)
        {
            if (this.controlList.InvokeRequired)
            {
                this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                {
                    if (high <= this.Height)
                    {
                        this.controlList.Height = this.Height;
                    }
                    else
                    {
                        this.controlList.Height = high;
                        ScrollBarShow();
                        if (this.vScrollBar.Visible)
                        {
                            this.RefreshScrollBar();
                        }
                    }
                }));
            }
            else
            {
                if (high <= this.Height)
                {
                    this.controlList.Height = this.Height;
                }
                else
                {
                    this.controlList.Height = high;
                    ScrollBarShow();
                    if (this.vScrollBar.Visible)
                    {
                        this.RefreshScrollBar();
                    }
                }
            }
        }

        /// <summary>
        /// 刷新滚动条值
        /// </summary>
        private void RefreshScrollBar()
        {
            int value = (91 * (-this.controlList.Location.Y) / (this.controlList.Height - this.Height));
            if (value > 0 && value < 91)
            {
                if (this.vScrollBar.InvokeRequired)
                {

                    this.vScrollBar.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.vScrollBar.Value = value;
                    }));
                }
                else
                {
                    this.vScrollBar.Value = value;
                }
            }
        }

        //控件坐标控制（排序）
        public void Sort(object control)
        {
            int x = this.controlList.Location.X + this.GapX;
            int y = heightColculate(this.controlList.Controls);
            if (((Control)control).InvokeRequired)
            {
                ((Control)control).Invoke(new EventHandler(delegate(object o, EventArgs e)
                {
                    ((Control)control).Location = new Point(x, y);
                }));
            }
            else
            {
                ((Control)control).Location = new Point(x, y);
            }
        }

        //从Panel里移除一个控件
        public void RemoveAt(int index)
        {
            if (this.controlList.Controls != null)
            {
                if (this.controlList.Controls.Count > 0)
                {
                    int height = this.controlList.Controls[index].Height;

                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        if (this.controlList.Controls[0].GetType() == typeof(ItemOrder))
                        {
                            for (int i = index; i < this.controlList.Controls.Count; i++)
                            {
                                ItemOrder current = this.controlList.Controls[i] as ItemOrder;
                                current.Location = new Point(current.Location.X, current.Location.Y - height);
                                current.OriginalLocation = current.Location;
                            }

                            RemoveObjectFromLinkList(this.controlList.Controls[index] as ItemOrder);
                        }

                        this.controlList.Controls.RemoveAt(index);
                        this.SetHigh(heightColculate(this.controlList.Controls));
                    }));
                }
            }

            //lpPanel下边框与controlList下边框的纵坐标之差
            int gap = this.Location.Y + this.Height - this.controlList.Location.Y - this.controlList.Height;
            if (gap > 0 && this.controlList.Height > this.Height)
            {
                this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                {
                    this.controlList.Location = new Point(this.controlList.Location.X, this.controlList.Location.Y + gap);
                }));
            }

            //初始化ItemOrder的双向链表
            DoubleDirectionListInitialization();
        }

        /// <summary>
        /// 将ItemOrder从链表中移除
        /// </summary>
        /// <param name="itemOrder"></param>
        private void RemoveObjectFromLinkList(ItemOrder itemOrder)
        {
            if (itemOrder.Previous != null && itemOrder.Next != null)
            {
                itemOrder.Previous.Next = itemOrder.Next;
                itemOrder.Next.Previous = itemOrder.Previous;

                itemOrder.Previous = null;
                itemOrder.Next = null;
            }
            else if (itemOrder.Previous == null && itemOrder.Next != null)
            {
                itemOrder.Next.Previous = null;
                itemOrder.Next = null;

            }
            else if (itemOrder.Previous != null && itemOrder.Next == null)
            {
                itemOrder.Previous.Next = null;
                itemOrder.Previous = null;
            }

            itemOrder = null;
        }

        //从Panel里移除一个控件
        public void RemoveObj(object o)
        {
            int index = this.controlList.Controls.IndexOf((Control)o);
            RemoveAt(index);
        }

        //累加contrList里所有控件的高度
        private int heightColculate(ControlCollection controls)
        {
            int height = this.Gap/2;
            if (controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control controlItem in controls)
                {
                    if (controlItem.GetType() != typeof(ItemOrder))
                    {
                        if (controlItem.InvokeRequired)
                        {
                            controlItem.Invoke(new EventHandler(delegate(object o, EventArgs e)
                            {
                                if (controlItem.Dock == DockStyle.None)
                            {
                                controlItem.Location = new Point(this.GapX, height);
                            }
                            }));
                        }
                        else
                        {
                            if (controlItem.Dock == DockStyle.None)
                            {
                                controlItem.Location = new Point(this.GapX, height);
                            }
                        }
                        
                    }

                    if (controlItem.Visible)
                    {
                        height += (controlItem.Height + this.Gap);
                    }
                }
            }
            return height;
        }

        //滚动条
        private void vScrollBar_Scroll(object sender, MouseEventArgs e)
        {
            int num = this.controlList.Controls.Count;
            int x = this.plParent.Height;
            int y1 = 0;
            int y2 = heightColculate(this.controlList.Controls);
            int h = y2 - y1 - x;

            Control c = sender as Control;
            while (c.GetType() != typeof(VScrollBar))
            {
                c = c.Parent;
            }

            if (h < 0)
            {
                return;
            }
            if (((VScrollBar)c).IsMouseLeftButtonClickDownFlag)
            {
                this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                {
                    int Y = -((((VScrollBar)c).Value * h) / 91);
                    if (((VScrollBar)c).Value > 80)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, -h);
                        if (this.showPaging != null)
                        {
                            showPaging(true);//显示分页控件
                        }

                    }
                    else if (((VScrollBar)c).Value < 10)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, 0);
                        if (this.showPaging != null)
                        {
                            showPaging(false);//隐藏分页控件
                        }
                    }
                    else
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, Y);
                        if (this.showPaging != null)
                        {
                            showPaging(false);//隐藏分页控件
                        }
                    }                        //如果滚动条到最底部
                    //if (((VScrollBar)c).Value > 90)
                    //{
                    //    if (this.showPaging != null)
                    //    {
                    //        showPaging(true);//显示分页控件
                    //    }
                    //}
                    //else
                    //{
                    //    if (this.showPaging != null)
                    //    {
                    //        showPaging(false);//隐藏分页控件
                    //    }
                    //}
                }));
            }
        }

        public void traceThePrintingItemMethod(object o)
        {
            Control control = (Control)o;
            int x = this.Location.X;//外层控件坐标
            int y = this.Location.Y;//外层控件坐标
            int h = this.Height;//外层控件高度
            int x1 = this.controlList.Location.X;//内层控件坐标
            int y1 = this.controlList.Location.Y;//内层控件坐标
            int h1 = this.controlList.Height;//内层控件高度
            int topGap = y1;//内层控件外层控件上边框的坐标差
            int bottomGap = (y1 + h1) - h;//内层控件外层控件下边框的坐标差
            //目标位移（注：位移有正负）
            int space = control.Location.Y + y1;
            int length = (space) > 0 ? space : -space;
            if (h1 > h)
            {
                if (length > h)
                {
                    this.controlList.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                    {
                        this.controlList.Location = new Point(x1, control.Location.Y * (-1));
                    }));
                    this.RefreshScrollBar();
                }
                else
                {
                    for (int i = 0; i < length; length = length - 5)
                    {
                        int kedu = length > 5 ? 5 : length;//移到的刻度
                        //if (length > (this.Height * 2))
                        //{
                        //    kedu = length / 5;
                        //}

                        if (space > 0)//上移
                        {
                            if ((bottomGap - kedu) > 0 && (topGap - kedu) < 0)
                            {
                                this.controlList.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                {
                                    this.controlList.Location = new Point(x1, y1 - kedu);
                                }));

                                this.RefreshScrollBar();
                            }
                            else
                            {
                                //this.controlList.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                //{
                                //    this.controlList.Location = new Point(x1, y1 - kedu);
                                //}));

                                //this.RefreshScrollBar();
                                return;
                            }
                        }
                        else if (space < 0)//下移
                        {
                            if ((bottomGap + kedu) > 0 && (topGap + kedu) < 0)
                            {
                                this.controlList.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                {
                                    this.controlList.Location = new Point(x1, y1 + kedu);
                                }));
                                this.RefreshScrollBar();
                            }
                            else
                            {
                                //this.controlList.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                //{
                                //    this.controlList.Location = new Point(x1, y1 + kedu);
                                //}));
                                //this.RefreshScrollBar();
                                return;
                            }
                        }

                        y1 = this.controlList.Location.Y;
                        topGap = y1;
                        bottomGap = (y1 + h1) - h;

                        Thread.Sleep(10);
                    }
                }

            }
        }
        //把正在打印的订单锁定在界面的指定位置
        public void traceThePrintingItem(Control control)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(traceThePrintingItemMethod), control);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 鼠标滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            int space = 5;//滚轮滚动幅度
            int num = this.controlList.Controls.Count;
            int x = this.plParent.Height;
            int y1 = 0;
            int y2 = heightColculate(this.controlList.Controls);
            int h = y2 - y1 - x;
            if (h < 0)
            {
                return;
            }
            if (e.Delta < 0)//滚轮向下滚
            {
                if (this.vScrollBar.Value < (91 - space) && ((this.controlList.Location.Y + (this.controlList.Height - this.Height)) >= 0))
                {
                    this.vScrollBar.Value += space;//滚动条
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, -((this.vScrollBar.Value * h) / 91));
                    }));
                }
                else// if (this.vScrollBar.Value < 91 && this.vScrollBar.Value > (91 - space) && ((this.controlList.Location.Y + (this.controlList.Height - this.Height)) >= 0))
                {
                    this.vScrollBar.Value = 91;//滚动条
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, -((this.vScrollBar.Value * h) / 91));
                    }));
                }
            }
            else//滚轮向上滚
            {
                if (this.vScrollBar.Value >= space && this.controlList.Location.Y <= 0)
                {
                    this.vScrollBar.Value -= space;//滚动条
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, -((this.vScrollBar.Value * h) / 91));
                    }));
                }
                else// if (this.vScrollBar.Value > 0 && this.vScrollBar.Value < space && this.controlList.Location.Y <= 0)
                {
                    this.vScrollBar.Value = 0;//滚动条
                    this.controlList.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                    {
                        this.controlList.Location = new Point(this.controlList.Location.X, -((this.vScrollBar.Value * h) / 91));
                    }));
                }
            }
            if (this.vScrollBar.Value > 85)
            {
                if (this.showPaging != null)
                {
                    showPaging(true);//显示分页控件
                }
            }
            else
            {
                if (this.showPaging != null)
                {
                    showPaging(false);//隐藏分页控件
                }
            }
        }

        private void ControlsList_Load(object sender, EventArgs e)
        {
            this.Init();
            ScrollBarShow();
            this.MouseWheel += this.MouseWheelEvent;
        }

        public void ScrollBarShow()
        {
            //if (this.IsAutoHideScroll)
            //{
            //    if (this.heightColculate(this.controlList.Controls) > this.Height)
            //    {
            this.vScrollBar.Visible = true;
            //        if (this.ControlList.InvokeRequired)
            //        {
            //            this.ControlList.Invoke(new EventHandler(delegate(object o,EventArgs e) {
            //                this.ControlList.Width = this.Size.Width - this.VScrollBar.Width;
            //            }));
            //        }
            //    }
            //    else
            //    {
            //        this.vScrollBar.Visible = false;
            //        this.ControlList.Invoke(new EventHandler(delegate(object o, EventArgs e)
            //        {
            //            this.ControlList.Width = this.Size.Width;
            //        }));
                    
            //    }
            //}
        }





        private bool isMouseLeftButtonClickDownFlag = false;
        private int verticalCoordinateOfItem = 0;
        private MouseEventArgs e;
        public MouseEventArgs E
        {
            get { return e; }
            set { e = value; }
        }

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;

            while (!(c.GetType() == typeof(ItemOrder)))
            {
                c = c.Parent;
            }

            c.BringToFront();

            if ((((ItemOrder)c).LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()) || 
                ((ItemOrder)c).LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString())) && 
                (c.GetType() == typeof(ItemOrder)))
            {
                isMouseLeftButtonClickDownFlag = true;
                verticalCoordinateOfItem = e.Y;
                try
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Drag), c);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        void control_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.E = e;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void control_MouseUp(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            while (!(c.GetType() == typeof(ItemOrder)))
            {
                c = c.Parent;
            }
            isMouseLeftButtonClickDownFlag = false;
            ((ItemOrder)c).BackToOriginalLocation();
            FreshTheOrderOfItemsInControlsList(c as ItemOrder);
        }

        private void FreshTheOrderOfItemsInControlsList(ItemOrder c)
        {
            //找链表头部
            while (c.Previous != null)
            {
                c = c.Previous;
            }

            int i = 0;
            while (c != null)
            {
                this.controlList.Controls.SetChildIndex(c, i++);
                c = c.Next;
            }
        }

        private void DragUnInitialize(Control c)
        {
            if (this.IsItemOrder)
            {
                c.MouseDown -= control_MouseDown;
                c.MouseMove -= control_MouseMove;
                c.MouseUp -= control_MouseUp;
            }
        }

        private void DragInitialize(Control c)
        {
            if (this.IsItemOrder)
            {
                c.MouseDown += control_MouseDown;
                c.MouseMove += control_MouseMove;
                c.MouseUp += control_MouseUp;
            }
        }

        private void Drag(object o)
        {
            Control control = (Control)o;

            while (isMouseLeftButtonClickDownFlag)
            {
                if (this.E != null)
                {
                    if (this.E.Button == MouseButtons.Left)
                    {
                        control.Invoke(new EventHandler(delegate(object sender, EventArgs e)
                        {
                            if (control.Location.X != this.E.X || control.Location.Y != this.E.Y)
                            {
                                int verticalCoordinateOfItemOrder = (((Control)sender).Location.Y + this.E.Y - verticalCoordinateOfItem);
                                int top = 0;//第一个状态为AWAITING_PRINT的ItemOrder的纵坐标
                                ItemOrder temp = control as ItemOrder;
                                while (temp.Previous != null &&
                                        (temp.Previous.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()) ||
                                         temp.Previous.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString())))
                                {
                                    temp = temp.Previous;
                                }
                                top = temp.OriginalLocation.Y;

                                if (verticalCoordinateOfItemOrder >= top - 5 && verticalCoordinateOfItemOrder <= (this.controlList.Height - 45))
                                {
                                    control.Location = new Point(control.Location.X, verticalCoordinateOfItemOrder);

                                    //交换相邻的ItemOrder
                                    ItemOrder current = control as ItemOrder;
                                    ItemOrder previous = null;
                                    ItemOrder next = null;

                                    if (current.Previous != null)
                                    {
                                        previous = current.Previous as ItemOrder;
                                        if (((current.Location.Y - current.OriginalLocation.Y) < -current.Height) && ((current.Location.Y - current.OriginalLocation.Y) > -(current.Height * 2)))
                                        {
                                            //与前一个ItemOrder交换位置
                                            if (previous.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()) ||
                                                previous.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString()))
                                                current.Swap(previous);
                                        }
                                    }

                                    if (current.Next != null)
                                    {
                                        next = current.Next as ItemOrder;
                                        if (((current.Location.Y - current.OriginalLocation.Y) > current.Height) && ((current.Location.Y - current.OriginalLocation.Y) < (current.Height * 2)))
                                        {
                                            //与后一个ItemOrder交换位置
                                            if (next.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()) ||
                                                next.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString()))
                                                current.Swap(next);
                                        }
                                    }
                                }
                            }
                        }));
                    }
                }
            }
        }

        public void refreshLocationDelegate()
        {
            int Y = this.Gap / 2;//初始时控件的纵坐标
            foreach (Control c in this.controlList.Controls)
            {
                if (c.InvokeRequired)
                {
                    c.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        c.Location = new Point(this.GapX, Y);//初始时控件的横坐标
                    }));
                }
                else
                {
                    c.Location = new Point(this.GapX, Y);//初始时控件的横坐标
                }
                Y += (c.Height + this.Gap);
            }
            this.VScrollBar.Value = 0;
            this.SetHigh(Y); //this.controlList.Height = Y;
            this.controlList.Location = new Point(0, 0);
        }
        public void refreshLocation()
        {
            this.Invoke(new EventHandler(delegate(object sender, EventArgs e)
            {
                refreshLocationDelegate();
            }));
        }
    }
}