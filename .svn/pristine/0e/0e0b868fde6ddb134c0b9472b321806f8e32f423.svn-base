using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common.Util;
using Maticsoft.Common;
using Maticsoft.Controller.Scheduler;
using Maticsoft.Common.model;
using System.Runtime.InteropServices;
using Maticsoft.BLL.ScanPortImage;

namespace Demo
{
    public partial class UnitConfigCMDTestForPrinter : UserControl
    {
        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_GetSDKVersion(byte[] ListFilePath);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_GetSupportPrinters(byte[] lpPrinters, Int32 len);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_ConnectDevices(string prtName, String port, int timeout);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_CloseDevices(int objCode);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_QueryStatus(int objCode);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageStart(int objCode, bool graphicMode, int width, int height);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageEnd(int objCode, int tm);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_CtrlBlackMark(int objCode);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_PrintText(int objCode, string szText);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_Print1DBarcode(int objCode, int bcType, int iWidth, int iHeight, int hri, string strData);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_Print2DBarcode(int objCode, int type2D, string strPrint, int version, int ecc, int size);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 ASCII_CtrlCutPaper(int objCode, int cutWay, int postion);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PageSend(int objCode);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PrintFile(int objCode, string szPath);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_PrintBMPBuffer(int objCode, int width, int height, byte[] buffer);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_QueryPrinterFirmware(int objCode, byte[] szFirmware, int len);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_StartRecord(string path);

        [DllImport("PrintSDK.dll", CharSet = CharSet.Unicode)]
        public static extern Int32 CON_EndRecord();

        private string m_strPath;
        public SerialPortInfo SPINFO { get; set; }

        public UnitConfigCMDTestForPrinter()
        {
            InitializeComponent();
        }

        private void UnitConfigCMDTestForPrinter_Load(object sender, EventArgs e)
        {
            //初始化串口下拉框
            foreach (Scheduler sh in Scheduler.SerialInteriorSchedulerList)
            {
                ComboboxItem item = new ComboboxItem(sh, sh.SPINFO.SLIP_PRINTER.M_NAME);
                this.cBoxCOM.Items.Add(item);
            }

            if (this.cBoxCOM.Items.Count > 0)
            {
                this.cBoxCOM.SelectedIndex = 0;
                this.SPINFO = ((Scheduler)((ComboboxItem)this.cBoxCOM.Items[0]).Key).SPINFO;
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult ds = this.openFileDialog.ShowDialog();
            if (ds != System.Windows.Forms.DialogResult.OK)
            {
                m_strPath = "";
                return;
            }
            m_strPath = this.openFileDialog.FileName;
            this.textFilePath.Text = m_strPath;
        }

        /// <summary>
        /// 打印文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintFile_Click(object sender, EventArgs e)
        {
            if (m_strPath != "")
            {
                SPImageGlobal.CON_PrintFile(SPINFO.SLIP_PRINTER.M_OBJID, m_strPath);
                SPImageGlobal.ASCII_CtrlCutPaper(SPINFO.SLIP_PRINTER.M_OBJID, 66, 50);
                SPImageGlobal.CON_PageSend(SPINFO.SLIP_PRINTER.M_OBJID);
            }
        }

        /// <summary>
        /// 状态按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnState_Click(object sender, EventArgs e)
        {
            consoleList.Items.Add(SPINFO.SLIP_PRINTER.printerState[SPINFO.SLIP_PRINTER.M_STATE]);
        }

        /// <summary>
        /// 打印文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintTxt_Click(object sender, EventArgs e)
        {
            Int32 repeat, tryCnt;
            string strRepeat;
            strRepeat = textRepat.Text;
            if (string.IsNullOrEmpty(strRepeat))
            {
                strRepeat = "1";
            }
            repeat = Convert.ToInt32(strRepeat);
            int iRet;
            for (int i = 0; i < repeat; ++i)
            {
                if (!radioPaperLabel.Checked)
                {
                    iRet = CON_PageStart(SPINFO.SLIP_PRINTER.M_STATE, false, 0, 0);

                    if (radioPaperBlack.Checked)
                        ASCII_CtrlBlackMark(SPINFO.SLIP_PRINTER.M_STATE);

                    SPImageGlobal.ASCII_PrintText(SPINFO.SLIP_PRINTER.M_OBJID, "www.cp020.com\r\n");
                    SPImageGlobal.ASCII_Print1DBarcode(SPINFO.SLIP_PRINTER.M_OBJID, 73, 1, 50, 2, "CODE128 TEST");
                    SPImageGlobal.ASCII_Print2DBarcode(SPINFO.SLIP_PRINTER.M_OBJID, 2, "北京彩游天下网络科技有限公司", 1, 1, 9);
                    SPImageGlobal.ASCII_CtrlCutPaper(SPINFO.SLIP_PRINTER.M_OBJID, 66, 50);
                }

                CON_PageEnd(SPINFO.SLIP_PRINTER.M_OBJID, 0);

                tryCnt = 3;//最多试3次
                while (tryCnt > 0)
                {
                    if (SPImageGlobal.CON_PageSend(this.SPINFO.SLIP_PRINTER.M_OBJID) != 0)
                    {
                        break;
                    }
                    //
                    // 如果发送打印失败，可以再次调用CON_PageSend
                    // 函数来继续上次未完成的打印任务，本次操作定义最大
                    // 操作次数为3次
                    tryCnt--;
                }
            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.consoleList.Items.Clear();
        }

        /// <summary>
        /// 打印图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintImg_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打印缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintCache_Click(object sender, EventArgs e)
        {
            try
            {
                //二进制图片数据流必须是黑白位图
                System.IO.FileStream fs = new System.IO.FileStream(textFilePath.Text, System.IO.FileMode.Open);

                //读取固定长度的文件头来确认文件信息，重要的是获取到图片的宽度和高度
                byte[] imgHeader = new byte[62];
                byte[] imgData = new byte[fs.Length - 62];
                fs.Read(imgHeader, 0, (int)imgHeader.Length);
                int width = imgHeader[0x15] * 256 * 256 * 256 + imgHeader[0x14] * 256 * 256 + imgHeader[0x13] * 256 + imgHeader[0x12];
                int height = imgHeader[0x19] * 256 * 256 * 256 + imgHeader[0x18] * 256 * 256 + imgHeader[0x17] * 256 + imgHeader[0x16];

                //读取图片位图数据，为后面的发送数据做准备
                fs.Read(imgData, 0, (int)imgData.Length);

                //
                //注意: 此处的操作流程是系统标准格式的图片缓存文件为黑白位图
                //调色板信息与打印机相反，开发者可以根据当前环境需要考虑是否
                //需要取反，以便实现正常打印效果。
                for (int i = 0; i < imgData.Length; ++i)
                    imgData[i] = (byte)~imgData[i];

                SPImageGlobal.CON_PrintBMPBuffer(SPINFO.SLIP_PRINTER.M_OBJID, width, height, imgData);

                //if (checkCut.Checked)
                SPImageGlobal.ASCII_CtrlCutPaper(SPINFO.SLIP_PRINTER.M_OBJID, 66, 0);
                SPImageGlobal.CON_PageSend(SPINFO.SLIP_PRINTER.M_OBJID);

                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
