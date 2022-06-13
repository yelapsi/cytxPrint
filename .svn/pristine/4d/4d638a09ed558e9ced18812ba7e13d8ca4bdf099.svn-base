using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common;
using Maticsoft.Common.model;
using System.IO.Ports;
using Maticsoft.Common.Util;
using Maticsoft.BLL.log;
using Maticsoft.Controller.Scheduler;

namespace Demo
{
    public partial class UnitConfigCMDTest : UserControl,IDisposable
    {
        public UnitConfigCMDTest()
        {
            InitializeComponent();
        }

        private void UnitConfigCMDTest_Load(object sender, EventArgs e)
        {
            //初始化串口下拉框
            foreach ( Scheduler sh in Scheduler.SerialInteriorSchedulerList )
            {
                ComboboxItem item = new ComboboxItem ( sh, sh.SPINFO.MacInfo.machine_name + "/" + sh.SPINFO.Sp.PortName);
                this.cBoxCOM.Items.Add(item);
            }

            if (this.cBoxCOM.Items.Count > 0)
            {
                this.cBoxCOM.SelectedIndex = 0;
            }
            

            this.itemKeyA.LbKeyText.Click += itemKey_Click;
            this.itemKeyRight.LbKeyText.Click += itemKey_Click;
            this.itemKeyDown.LbKeyText.Click += itemKey_Click;
            this.itemKeyLeft.LbKeyText.Click += itemKey_Click;
            this.itemKeyPageDown.LbKeyText.Click += itemKey_Click;
            this.itemKeyDotUp.LbKeyText.Click += itemKey_Click;
            this.itemKeyEquality.LbKeyText.Click += itemKey_Click;
            this.itemKeyComma.LbKeyText.Click += itemKey_Click;
            this.itemKeySingleQuoteLeft.LbKeyText.Click += itemKey_Click;
            this.itemKeySemicolon.LbKeyText.Click += itemKey_Click;
            this.itemKeySign.LbKeyText.Click += itemKey_Click;
            this.itemKeyDel.LbKeyText.Click += itemKey_Click;
            this.itemKeyTab.LbKeyText.Click += itemKey_Click;
            this.itemKeyEnd.LbKeyText.Click += itemKey_Click;
            this.itemKeyUp.LbKeyText.Click += itemKey_Click;
            this.itemKeyZero.LbKeyText.Click += itemKey_Click;
            this.itemKeyPageUp.LbKeyText.Click += itemKey_Click;
            this.itemKeyCapsLock.LbKeyText.Click += itemKey_Click;
            this.itemKeyBackslash.LbKeyText.Click += itemKey_Click;
            this.itemKeySlash.LbKeyText.Click += itemKey_Click;
            this.itemKeySquareBracketsRight.LbKeyText.Click += itemKey_Click;
            this.itemKeySquareBracketsLeft.LbKeyText.Click += itemKey_Click;
            this.itemKeyIns.LbKeyText.Click += itemKey_Click;
            this.itemKeyEsc.LbKeyText.Click += itemKey_Click;
            this.itemKeyThree.LbKeyText.Click += itemKey_Click;
            this.itemKeyTwo.LbKeyText.Click += itemKey_Click;
            this.itemKeyOne.LbKeyText.Click += itemKey_Click;
            this.itemKeyDot.LbKeyText.Click += itemKey_Click;
            this.itemKeyZ.LbKeyText.Click += itemKey_Click;
            this.itemKeyY.LbKeyText.Click += itemKey_Click;
            this.itemKeyX.LbKeyText.Click += itemKey_Click;
            this.itemKeyW.LbKeyText.Click += itemKey_Click;
            this.itemKeyV.LbKeyText.Click += itemKey_Click;
            this.itemKeyU.LbKeyText.Click += itemKey_Click;
            this.itemKeyT.LbKeyText.Click += itemKey_Click;
            this.itemKeyS.LbKeyText.Click += itemKey_Click;
            this.itemKeySix.LbKeyText.Click += itemKey_Click;
            this.itemKeyFive.LbKeyText.Click += itemKey_Click;
            this.itemKeyFour.LbKeyText.Click += itemKey_Click;
            this.itemKeyEnter.LbKeyText.Click += itemKey_Click;
            this.itemKeyR.LbKeyText.Click += itemKey_Click;
            this.itemKeyQ.LbKeyText.Click += itemKey_Click;
            this.itemKeyP.LbKeyText.Click += itemKey_Click;
            this.itemKeyO.LbKeyText.Click += itemKey_Click;
            this.itemKeyN.LbKeyText.Click += itemKey_Click;
            this.itemKeyM.LbKeyText.Click += itemKey_Click;
            this.itemKeyL.LbKeyText.Click += itemKey_Click;
            this.itemKeyK.LbKeyText.Click += itemKey_Click;
            this.itemKeyJ.LbKeyText.Click += itemKey_Click;
            this.itemKeyNine.LbKeyText.Click += itemKey_Click;
            this.itemKeyEight.LbKeyText.Click += itemKey_Click;
            this.itemKeySeven.LbKeyText.Click += itemKey_Click;
            this.itemKeyBackspace.LbKeyText.Click += itemKey_Click;
            this.itemKeyI.LbKeyText.Click += itemKey_Click;
            this.itemKeyH.LbKeyText.Click += itemKey_Click;
            this.itemKeyG.LbKeyText.Click += itemKey_Click;
            this.itemKeyF.LbKeyText.Click += itemKey_Click;
            this.itemKeyE.LbKeyText.Click += itemKey_Click;
            this.itemKeyD.LbKeyText.Click += itemKey_Click;
            this.itemKeyC.LbKeyText.Click += itemKey_Click;
            this.itemKeyB.LbKeyText.Click += itemKey_Click;
            this.itemKeyA.LbKeyText.Click += itemKey_Click;
            this.itemKeyMinus.LbKeyText.Click += itemKey_Click;
            this.itemKeyPlus.LbKeyText.Click += itemKey_Click;
            this.itemKey_F12.LbKeyText.Click += itemKey_Click;
            this.itemKey_F11.LbKeyText.Click += itemKey_Click;
            this.itemKey_F10.LbKeyText.Click += itemKey_Click;
            this.itemKey_F9.LbKeyText.Click += itemKey_Click;
            this.itemKey_F8.LbKeyText.Click += itemKey_Click;
            this.itemKey_F7.LbKeyText.Click += itemKey_Click;
            this.itemKey_F6.LbKeyText.Click += itemKey_Click;
            this.itemKey_F5.LbKeyText.Click += itemKey_Click;
            this.itemKey_F4.LbKeyText.Click += itemKey_Click;
            this.itemKey_F3.LbKeyText.Click += itemKey_Click;
            this.itemKey_F2.LbKeyText.Click += itemKey_Click;
            this.itemKey_F1.LbKeyText.Click += itemKey_Click;
        }


        private void itemKey_Click(object sender, EventArgs e)
        {
            if ( Global.IS_WORKING )
            {
                MsgBox.getInstance().Show(String.Format("检测到首页点击了开始出票,不能进行命令发送!", ""), "提醒", MsgBox.MyButtons.OK);
                return;
            }

            if ( !( ( Scheduler ) ( ( ComboboxItem ) this.cBoxCOM.SelectedItem ).Key ).SPINFO.Sp.IsOpen )
            {
                MsgBox.getInstance().Show(String.Format("未打开串口", ""), "错误", MsgBox.MyButtons.OK);
                return;
            }

            String keyText = ((ItemKey)((Label)sender).Parent).ValueStr;
            byte[] sendcmd = new byte[256];
            int cmd_length = 0, sendcmdlength = 0;

            //直接发送命令
            if (!this.panelCMD.Enabled)
            {
                byte[] dataCommand = null;
                //需要特殊转换的
                if (GlobalConstants.keyBoardKeyValue.ContainsKey(keyText))
                {
                    dataCommand = new byte[] { GlobalConstants.keyBoardKeyValue[keyText]};
                    cmd_length = 1;
                }
                else
                {
                    dataCommand = CommandProcessor.betDataToCommand(keyText, out cmd_length);
                }
                //组装命令                
                Array.Copy(dataCommand, 0, sendcmd, sendcmdlength, cmd_length);
                sendcmdlength += cmd_length;
                sendcmd = CommandProcessor.packCommand(sendcmd, GlobalConstants.cmdSign_KV[GlobalConstants.BASE_CMD.KEYBOARD], sendcmdlength);
                String cmd = CommandProcessor.bytesToHexString(sendcmd);
                bool b = SerialPortUtil.writeData ( ( ( Scheduler ) ( ( ComboboxItem ) this.cBoxCOM.SelectedItem ).Key ).SPINFO.Sp, sendcmd, sendcmdlength + 10 );
                //记录信息
                LogUtil.getInstance().addLogDataToQueue("命令测试,发送命令:" + cmd.Substring(0, (sendcmdlength + 10) * 2) + (b ? "成功!" : "失败!"), GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
            }
            else
            {
                this.txtBoxSend.Text += keyText;
            }
        }


        /// <summary>
        /// 启用禁用命令编辑区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "启用")
            {
                if ( !( ( Scheduler ) ( ( ComboboxItem ) this.cBoxCOM.SelectedItem ).Key ).SPINFO.Sp.IsOpen )
                {
                    MsgBox.getInstance().Show(String.Format("未打开串口", ""), "错误", MsgBox.MyButtons.OK);
                    return;
                }

                FrmPassEnter frm = new FrmPassEnter();
                DialogResult result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ((Button)sender).Text = "禁用";
                }
                else if (result == DialogResult.No)
                {
                    MsgBox.getInstance().Show(String.Format("密码错误", ""), "错误", MsgBox.MyButtons.OK);
                    return;
                }
                else
                {
                    return;
                }
                
            }
            else
            {
                ((Button)sender).Text = "启用";
            }

            this.panelCMD.Enabled = !this.panelCMD.Enabled;
        }

        private void btnRefreshCOM_Click ( object sender, EventArgs e )
        {
            this.labComState.Text = ( ( Scheduler ) ( ( ComboboxItem ) this.cBoxCOM.SelectedItem ).Key ).SPINFO.Sp.IsOpen ? "串口打开" : "串口关闭";
        }

        private void cBoxCOM_SelectedIndexChanged ( object sender, EventArgs e )
        {
            this.labComState.Text = ( ( Scheduler ) ( ( ComboboxItem ) this.cBoxCOM.SelectedItem ).Key ).SPINFO.Sp.IsOpen ? "串口打开" : "串口关闭";
        }

    }
}
