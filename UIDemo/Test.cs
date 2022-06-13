using Maticsoft.Common;
using Maticsoft.Common.model.httpmodel;
using Maticsoft.Common.SingleUpload;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            string test = @"{'OrderId':'z09131201110020161019130940','QRCodeUrl':'weixin://wxpay/bizpayurl?pr=5RW7kvB','tickets':[{'HeadNo':'1','LotteryTypeId':'1','nums':1,'TicketIds':'z09131201110020161019130940-1-1'},{'HeadNo':'2','LotteryTypeId':'2','Nums':1,'TicketIds':'z09131201110020161019130940-2-2'},{'HeadNo':'3','LotteryTypeId':'3','Nums':1,'TicketIds':'z09131201110020161019130940-3-3'},{'HeadNo':'4','LotteryTypeId':'4','Nums':1,'TicketIds':'z09131201110020161019130940-4-4'},{'HeadNo':'5','LotteryTypeId':'5','Nums':1,'TicketIds':'z09131201110020161019130940-5-5'},{'HeadNo':'6','LotteryTypeId':'6','Nums':1,'TicketIds':'z09131201110020161019130940-6-6'},{'HeadNo':'7','LotteryTypeId':'7','Nums':1,'TicketIds':'z09131201110020161019130940-7-7'},{'HeadNo':'8','LotteryTypeId':'8','Nums':1,'TicketIds':'z09131201110020161019130940-8-8'}]}";

            C006ContentAck c = (C006ContentAck)JSonHelper.JsonToC006ContentAck(test);
        }
    }
}
