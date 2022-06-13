using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ItemKey : UserControl
    {
        //键盘按钮显示的的文字
        private string textKey = "";

        //点击是传输的文字——字符串
        private string valueStr = "";

        //按钮获取焦点后的背景图片
        private Image backgroundImageFoused = null;

        //按钮失去焦点后的背景图片
        private Image backgroundImageUnFoused = null;

        public ItemKey()
        {
            InitializeComponent();
            
        }

        private void ItemKey_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 使子控件位于父控件中心
        /// </summary>
        /// <param name="childControl"></param>
        /// <param name="parentControl"></param>
        public void CenteringControl(Control childControl,Control parentControl)
        {
            //子控件坐标
            int x = 0;
            int y = 0;
            if (childControl != null && parentControl != null)
            {
                if (childControl.Parent.Equals(parentControl))
                {
                    x = (parentControl.Size.Width - childControl.Size.Width) / 2;
                    y = (parentControl.Size.Height - childControl.Size.Height) / 2;
                    childControl.Location = new Point(x,y);
                }
            }
        }

        /// <summary>
        /// 鼠标在控件上触发的事件（例如：更换背景图）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemKey_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = this.BackgroundImageFoused;
            this.lbKeyText.ForeColor = Color.White;
        }
        
        /// <summary>
        /// 鼠标离开控件时触发的事件（例如：更换背景图）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemKey_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = this.BackgroundImageUnFoused;
            this.lbKeyText.ForeColor = Color.Black;
        }

        public string TextKey
        {
            get { return textKey; }
            set
            {
                textKey = value;
                this.lbKeyText.Text = textKey;
            }
        }

        public string ValueStr
        {
            get { return valueStr; }
            set
            {
                valueStr = value;
            }
        }

        public Image BackgroundImageFoused
        {
            get { return backgroundImageFoused; }
            set { backgroundImageFoused = value; }
        }

        public Image BackgroundImageUnFoused
        {
            get
            {
                return backgroundImageUnFoused; 
            }
            set { backgroundImageUnFoused = value; }
        }

        public System.Windows.Forms.Label LbKeyText
        {
            get { return lbKeyText; }
            set { lbKeyText = value; }
        }
    }
}
