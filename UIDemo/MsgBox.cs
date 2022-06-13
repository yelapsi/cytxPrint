using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class MsgBox : Form
    {
        private MsgBox()
        {
            InitializeComponent();
        }

        private MsgDialogResult CYReturnButton;
        private CountdownTextType ctType;
        Timer timer = new Timer();

        private String msgtext;
        public String Msgtext
        {
            get { return msgtext; }
            set { 
                msgtext = value;
                this.lbMessage.Text = msgtext;

                int LblNum = msgtext.Length;   //Label内容长度
                int RowNum = 20;           //每行显示的字数
                int RowHeight = 21;           //每行的高度
                int ColNum = (LblNum - (LblNum / RowNum) * RowNum) == 0 ? (LblNum / RowNum) : (LblNum / RowNum) + 1;   //列数
                this.lbMessage.AutoSize = false;    //设置AutoSize
                this.lbMessage.Width = 350;          //设置显示宽度
                this.lbMessage.Height = RowHeight * ColNum;           //设置显示高度
            }
        }

        /// <summary>
        /// 按钮类型
        /// </summary>
        public enum MyButtons
        {
            OK,
            OKCancel,
            OKIgnore
        }

        public enum MsgDialogResult
        {
            OK,
            Cancel
        }

        /// <summary>
        /// 倒计时提示类型
        /// </summary>
        public enum CountdownTextType { 
        OK,Stop,Ignore
        }

        private static Dictionary<CountdownTextType, String> CountdownTextDictionary = new Dictionary<CountdownTextType, string>() { 
        { CountdownTextType.OK,"{0}秒后自动选择确定!"},
        { CountdownTextType.Stop,"{0}秒后自动选择停止出票!"},
        { CountdownTextType.Ignore,"{0}秒后自动选择忽略!"}};

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        public static MsgBox getInstance()
        {
            return new MsgBox();
         }

        /// <summary>
        /// Message: Text to display in the message box.
        /// </summary>
        public MsgDialogResult Show(string Message)
        {
            this.Msgtext = Message;
            this.btnCancel.Visible = false;
            this.ShowDialog();
            return CYReturnButton;
        }

        /// <summary>
        /// Title: Text to display in the title bar of the messagebox.
        /// </summary>
        public MsgDialogResult Show(string Message, string Title)
        {
            this.labfrmTitle.Text = Title;
            this.Msgtext = Message;

            this.btnCancel.Visible = false;

            this.ShowDialog();
            return CYReturnButton;
        }

        /// <summary>
        /// MButtons: Display MyButtons on the message box.
        /// </summary>
        public MsgDialogResult Show(string Message, string Title, MyButtons MButtons)
        {
            this.labfrmTitle.Text = Title;
            this.Msgtext = Message; //Set the text of the MessageBox
            buttonStatements(MButtons); // ButtonStatements method is responsible for showing the appropreiate buttons
            this.ShowDialog(); // Show the MessageBox as a Dialog.
            return CYReturnButton; // Return the button click as an Enumerator
        }

        private void buttonStatements(MyButtons MButtons)
        {
            switch (MButtons)
            {
                case MyButtons.OK:
                    this.btnCancel.Visible = false;
                    break;
                case MyButtons.OKCancel:
                    this.btnCancel.Text = "取消";
                    break;
                case MyButtons.OKIgnore:
                    this.btnCancel.Text = "忽略";
                    break;
                default:
                    break;
            }
        }

        

        /// <summary>
        /// 自带倒计时，倒计时结束后自动选择
        /// </summary>
        /// <param name="MessageFormat"></param>
        /// <param name="Title"></param>
        /// <param name="MButtons"></param>
        /// <param name="showStr"></param>
        /// <param name="MIcon"></param>
        /// <param name="Countdown"></param>
        /// <returns></returns>
        public MsgDialogResult Show(String msg, string Title, CountdownTextType ctType, MyButtons MButtons, Int64 Countdown, MsgDialogResult dresult)
        {
            this.timer.Interval = 1000;
            this.timer.Tick += t_Tick;
            
            this.ctType = ctType;

            this.countdowns = Countdown;
            this.labfrmTitle.Text = Title;
            this.lbMessage.Text = msg+"，请选择：";
            this.labCountdownText.Text = String.Format(MsgBox.CountdownTextDictionary[ctType], this.countdowns.ToString()); //Set the text of the MessageBox

            buttonStatements(MButtons);

            //设置返回默认值
            CYReturnButton = dresult;

            this.timer.Enabled = true;
            this.timer.Start();
            this.ShowDialog();

            return CYReturnButton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void t_Tick(object sender, EventArgs e)
        {
            if (this.countdowns > 0)
            {
                this.lbMessage.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                {
                    this.labCountdownText.Text = String.Format(MsgBox.CountdownTextDictionary[ctType], this.countdowns.ToString());
                }));

                this.countdowns--;
            }
            else
            {
                this.timer.Enabled = false;
                this.timer.Stop();
                this.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            CYReturnButton = MsgDialogResult.OK;
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CYReturnButton = MsgDialogResult.Cancel;
            this.Dispose();
            this.Close();
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.popupFocuse;
            ((Control)sender).ForeColor = Color.White;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.xzw;
            ((Control)sender).ForeColor = Color.Black;
        }

        public long countdowns { get; set; }
    }
}
