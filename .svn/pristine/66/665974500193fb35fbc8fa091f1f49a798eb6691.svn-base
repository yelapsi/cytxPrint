using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.BLL.log;
using System.Collections.Generic;

namespace Demo
{
    public partial class UnitMyConfig : UserControl
    {
        public UnitMyConfig()
        {
            InitializeComponent();
        }

        private void UnitMyConfig_Load(object sender, EventArgs e)
        {
            //服务器地址
            this.labsysconfig.Text = "系统参数-"+GlobalConstants.SERVER_TYPE_MAP [ Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE ] ];
            //机型选择
            foreach (KeyValuePair<string,string> item in GlobalConstants.PRINTER_MODEL_MAP)
	        {
                ComboboxItem cbItem = new ComboboxItem(item.Key, item.Value);
                this.cbPrinterModel.Items.Add(cbItem);
                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL].Equals(item.Key.ToString()))
                {
                    this.cbPrinterModel.SelectedItem = cbItem;
                }
	        }
            
            //保存数据时间
            foreach (KeyValuePair<string,string> item in GlobalConstants.DataKeepTimeDic)
	        {
                ComboboxItem cbItem = new ComboboxItem(item.Key, item.Value);
                this.cbDataKeepTime.Items.Add(cbItem);
                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME].Equals(item.Key.ToString()))
                {
                    this.cbDataKeepTime.SelectedItem = cbItem;
                }
	        }

            //地区选择
            foreach (KeyValuePair<string,string> item in PCodeConstant.PCODE_MAP)
	        {
                ComboboxItem cbItem = new ComboboxItem(item.Key, item.Value);
                this.cbLocation.Items.Add(cbItem);
                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(item.Key.ToString()))
                {
                    this.cbLocation.SelectedItem = cbItem;
                }
	        }

            //出票方式
            foreach (KeyValuePair<string, string> item in GlobalConstants.PRINT_TYPE_MAP)
            {
                ComboboxItem cbItem = new ComboboxItem(item.Key, item.Value);
                this.cbPrintType.Items.Add(cbItem);
                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE].Equals(item.Key.ToString()))
                {
                    this.cbPrintType.SelectedItem = cbItem;
                }
            }
            
            //自动向服务器回馈出票结果
            this.chIsAutoFeedback.Checked = Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK].Equals("1") ? true : false;
        }

        /// <summary>
        /// 修改系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //string strTemp = Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE];
            //Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE] = ((ComboboxItem)this.cbServerUrl.SelectedItem).Key.ToString();
            Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL] = ((ComboboxItem)this.cbPrinterModel.SelectedItem).Key.ToString();
            Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME] = ((ComboboxItem)this.cbDataKeepTime.SelectedItem).Key.ToString();
            Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE] = ((ComboboxItem)this.cbLocation.SelectedItem).Key.ToString();
            Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE] = ((ComboboxItem)this.cbPrintType.SelectedItem).Key.ToString();
            Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK] = this.chIsAutoFeedback.Checked?"1":"0";

            try
            {
                MsgBox.MsgDialogResult result = MsgBox.getInstance().Show("是否确定要进行修改?", "提示", MsgBox.MyButtons.OKCancel);
                if (result == MsgBox.MsgDialogResult.OK)
                {
                    if (new SystemSettingsController().updateSystemConfig(new Dictionary<String, String>() { 
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK]}}))
                    {
                        Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE = ((ComboboxItem)this.cbPrintType.SelectedItem).Key.Equals(Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER) || ((ComboboxItem)this.cbPrintType.SelectedItem).Key.Equals(Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER_QRCODE);
                        LogUtil.getInstance().addLogDataToQueue("修改系统参数成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                        //Global.sysconfig = scontroller.getSysConfig();
                        MsgBox.getInstance().Show("修改系统参数成功!", "提示", MsgBox.MyButtons.OK);
                    }
                    else
                    {
                        LogUtil.getInstance().addLogDataToQueue("修改系统参数失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                        MsgBox.getInstance().Show("修改系统设置错误!", "提示", MsgBox.MyButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                LogUtil.getInstance().addLogDataToQueue("修改系统参数异常!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue("修改系统参数异常!" + ex.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ex.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModificationEnter;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModification;
        }
    }
}
