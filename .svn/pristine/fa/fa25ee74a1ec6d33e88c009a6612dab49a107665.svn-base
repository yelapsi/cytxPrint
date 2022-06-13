using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Demo
{
    public partial class VScrollBar : UserControl
    {
        private int value;
        private MouseEventArgs e;
        private int verticalCoordinateOfscrollButton = 0;
        private bool isMouseLeftButtonClickDownFlag = false;

        public VScrollBar()
        {
            InitializeComponent();
        }

        private void VScrollBar_Load(object sender, EventArgs e)
        {
            InitializeComponent02();
        }

        void control_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseLeftButtonClickDownFlag = true;
            verticalCoordinateOfscrollButton = e.Y;
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(fun), sender);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.E = e;
            }

            if (this.IsMouseLeftButtonClickDownFlag)
            {
                this.Value = 91 * ((Control)sender).Location.Y / (this.Height - this.ScrollButton.Height);
            }
        }

        void control_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseLeftButtonClickDownFlag = false;
        }
        
        private void InitializeComponent02()
        {
            this.ScrollButton.Width = this.Width;
            this.scrollButton.MouseDown += control_MouseDown;
            this.scrollButton.MouseMove += control_MouseMove;
            this.scrollButton.MouseUp += control_MouseUp;
        }

        private void fun(object o)
        {
            Control control = (Control)o;
            if (control.InvokeRequired)
            {
                control.Invoke(new EventHandler(delegate(object sender, EventArgs e)
                {
                    control.BringToFront();
                }));
            }
            else
            {
                control.BringToFront();
            }

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
                                int verticalCoordinateOfscrollButtonTemp = (((Control)sender).Location.Y + this.E.Y - verticalCoordinateOfscrollButton);
                                if (verticalCoordinateOfscrollButtonTemp >= 0 && verticalCoordinateOfscrollButtonTemp <= (this.Height - this.scrollButton.Height))
                                {
                                    control.Location = new Point(control.Location.X, verticalCoordinateOfscrollButtonTemp);
                                }
                            }
                        }));
                    }
                }
            }
        }

        public int Value
        {
            get { return this.value; }
            set
            {
                if (value < 0 || value > 91)
                {
                    throw new Exception("Value must be a number between 0 and 91!");
                }

                this.value = value;
                int gap = this.Height - this.scrollButton.Height;
                if (gap >= 0 && gap <= this.Height && !this.IsMouseLeftButtonClickDownFlag)
                {
                    if (this.scrollButton.InvokeRequired)
                    {
                        this.scrollButton.Invoke(new EventHandler(delegate(object sender, EventArgs e)
                        {
                            this.scrollButton.Location = new System.Drawing.Point(0, gap * this.value / 91);
                        }));
                    }
                    else
                    {
                        this.scrollButton.Location = new System.Drawing.Point(0, gap * this.value / 91);
                    }
                }
            }
        }

        public PictureBox ScrollButton
        {
            get { return this.scrollButton; }
        }

        public bool IsMouseLeftButtonClickDownFlag
        {
            get { return isMouseLeftButtonClickDownFlag; }
        }

        public MouseEventArgs E
        {
            get { return e; }
            set { e = value; }
        }

        //背景图
        public Image BackgroundImageTop
        {
            set
            {
                this.picBackgroundImgTop.BackgroundImageLayout = ImageLayout.Stretch;
                this.picBackgroundImgTop.BackgroundImage = value;
            }
        }
        public Image BackgroundImageMiddle
        {
            set
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = value;
                this.Width = this.BackgroundImage.Width;
            }
        }
        public Image BackgroundImageBottom
        {
            set
            {
                this.picBackgroundImgBottom.BackgroundImageLayout = ImageLayout.Stretch;
                this.picBackgroundImgBottom.BackgroundImage = value;
            }
        }

        public Image BackgroundImageScrollBar
        {
            set
            {
                this.scrollButton.BackgroundImage = value;
                this.scrollButton.Size = this.scrollButton.BackgroundImage.Size;
            }
        }
    }
}
