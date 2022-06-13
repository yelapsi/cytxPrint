using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;

namespace Demo
{
    public partial class FrmCompareTicketInfoShow : Form
    {
        private Point mPoint = new Point();
        private lottery_ticket lt = null;
        public FrmCompareTicketInfoShow()
        {
            InitializeComponent();
        }
        public FrmCompareTicketInfoShow(lottery_ticket lticket)
        {
            InitializeComponent();
            this.lt = lticket;
        }

        private void FrmCompareTicketInfoShow_Load(object sender, EventArgs e)
        {
            this.controlsListBetDetails.Gap = 20;
            this.controlsListBetDetails.BackColor = Color.White;
            this.controlsListTiketInfor.BackColor = Color.White;
            this.controlsListBetDetails.VScrollBar.BackColor = Color.White;
            this.controlsListTiketInfor.VScrollBar.BackColor = Color.White;
            //富文本框高度自适应
            this.rTextBoxTicketInfo.ContentsResized += rTextBoxTicketInfo_ContentsResized;
            //初始化投注信息区域
            this.labLicenseName.Text = LicenseContants.licenseId2NameDictionary[this.lt.license_id.ToString()];
            this.labBetMoney.Text = this.lt.bet_price.ToString() + "元";
            this.labPlayName.Text = PlayTypeFactory.getInstance(this.lt.license_id.ToString()).getTypeName(this.lt.play_type.Split('-')[0]);
            this.labBetNum.Text = this.lt.bet_num.ToString() + "注";
            this.labMultiple.Text = this.lt.multiple + "倍";

            //数字彩显示期号
            if (!this.lt.issue.Equals("1"))
            {
                this.labIssue.Text = this.lt.issue;
            }
            else
            {
                this.labIssueTitle.Visible = false;
                this.labIssue.Visible = false;
            }

            string[] betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArray(this.lt.bet_code, this.lt.license_id.ToString(), this.lt.play_type);

            string[] betCodeTemp = betCode2ShowArray[1].Split(new string[] { "\r\n"}, StringSplitOptions.None);

            for (int i = 0; i < betCodeTemp.Length; i++)
            {
                ItemBetDetails itemBetDetails = new ItemBetDetails();
                itemBetDetails.Index = i + 1;
                itemBetDetails.Details = betCodeTemp[i];
                this.controlsListBetDetails.Add(itemBetDetails);
            }
            

            String tInfo = SysUtil.dbStrToTicketInfo(this.lt.ticket_info);
            //tInfo += ("\n" + tInfo);
            this.rTextBoxTicketInfo.Text = tInfo.Replace("<b>", "").Replace("</b>", "");

            while (tInfo.Contains("<b>") && tInfo.Contains("</b>"))
            {
                int startindex = 0, endindex = 0;
                startindex = tInfo.IndexOf("<b>");
                endindex = tInfo.IndexOf("</b>");
                if (startindex < endindex)
                {
                    this.rTextBoxTicketInfo.Select(startindex, endindex - startindex - 3);
                    this.rTextBoxTicketInfo.SelectionFont = new Font(this.rTextBoxTicketInfo.SelectionFont, FontStyle.Bold);

                    //先移除结束标签再移除开始标签，否则要考虑移除开始标签对结束标签位置的影响
                    tInfo = tInfo.Remove(endindex, 4).Remove(startindex, 3);
                }
                else
                { //多出了一个</b>的情况
                    tInfo = tInfo.Remove(endindex, 4);
                }
            }

            this.rTextBoxTicketInfo.SelectAll();
            this.rTextBoxTicketInfo.SelectionAlignment = HorizontalAlignment.Center;
            this.rTextBoxTicketInfo.Select(0, 0);

           
            this.InitScrollBar();
        }

        /// <summary>
        /// 富文本框高度自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void rTextBoxTicketInfo_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.rTextBoxTicketInfo.Height = e.NewRectangle.Height + 10;
        }
        

        /// <summary>
        /// 设置滚动条外观
        /// </summary>
        private void InitScrollBar()
        {
            //controlsListBetDetails
            this.controlsListBetDetails.VScrollBar.BackgroundImageTop = global::Demo.Properties.Resources.backgroundImgTop;
            this.controlsListBetDetails.VScrollBar.BackgroundImageMiddle = global::Demo.Properties.Resources.backgroundImgMiddle;
            this.controlsListBetDetails.VScrollBar.BackgroundImageBottom = global::Demo.Properties.Resources.backgroundImgBottom;
            this.controlsListBetDetails.VScrollBar.BackgroundImageScrollBar = global::Demo.Properties.Resources.backgroundImgTopScrollbar;
            this.controlsListBetDetails.VScrollBar.Location = new System.Drawing.Point(this.controlsListBetDetails.Width - this.controlsListBetDetails.VScrollBar.Width, 0);

            //controlsListTiketInfor
            this.controlsListTiketInfor.VScrollBar.BackgroundImageTop = global::Demo.Properties.Resources.backgroundImgTop;
            this.controlsListTiketInfor.VScrollBar.BackgroundImageMiddle = global::Demo.Properties.Resources.backgroundImgMiddle;
            this.controlsListTiketInfor.VScrollBar.BackgroundImageBottom = global::Demo.Properties.Resources.backgroundImgBottom;
            this.controlsListTiketInfor.VScrollBar.BackgroundImageScrollBar = global::Demo.Properties.Resources.backgroundImgTopScrollbar;
            this.controlsListTiketInfor.VScrollBar.Location = new System.Drawing.Point(this.controlsListTiketInfor.Width - this.controlsListTiketInfor.VScrollBar.Width, 0);
            this.rTextBoxTicketInfo.ScrollBars = RichTextBoxScrollBars.None;
           // this.rTextBoxTicketInfo.Height = this.rTextBoxTicketInfo.Lines.Length * 28;
            this.controlsListTiketInfor.Add(this.rTextBoxTicketInfo);
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void FrmCompareTicketInfoShow_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void FrmCompareTicketInfoShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
    }
}
