using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmInit : Form
    {
        public FrmInit()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnCloseEnter;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnClose;
        }

        private void btnUpdateSysParam_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModificationEnter;
        }

        private void btnUpdateSysParam_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSaveModification;
        }

        private void FrmInit_Load ( object sender, EventArgs e )
        {
            //服务器选择
            foreach ( KeyValuePair<string,string> item in GlobalConstants.SERVER_TYPE_MAP )
            {
                ComboboxItem cbItem = new ComboboxItem ( item.Key, item.Value );
                this.cBoxServer.Items.Add ( cbItem );
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE ].Equals ( item.Key.ToString ( ) ) )
                {
                    this.cBoxServer.SelectedItem = cbItem;
                }
            }
            //机型选择
            foreach ( KeyValuePair<string,string> item in GlobalConstants.PRINTER_MODEL_MAP )
            {
                ComboboxItem cbItem = new ComboboxItem ( item.Key, item.Value );
                this.cbPrinterModel.Items.Add ( cbItem );
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL ].Equals ( item.Key.ToString ( ) ) )
                {
                    this.cbPrinterModel.SelectedItem = cbItem;
                }
            }

            //保存数据时间
            foreach ( KeyValuePair<string,string> item in GlobalConstants.DataKeepTimeDic )
            {
                ComboboxItem cbItem = new ComboboxItem ( item.Key, item.Value );
                this.cbDataKeepTime.Items.Add ( cbItem );
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME ].Equals ( item.Key.ToString ( ) ) )
                {
                    this.cbDataKeepTime.SelectedItem = cbItem;
                }
            }

            //地区选择
            foreach ( KeyValuePair<string,string> item in PCodeConstant.PCODE_MAP )
            {
                ComboboxItem cbItem = new ComboboxItem ( item.Key, item.Value );
                this.cbLocation.Items.Add ( cbItem );
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE ].Equals ( item.Key.ToString ( ) ) )
                {
                    this.cbLocation.SelectedItem = cbItem;
                }
            }

            //出票方式
            foreach ( KeyValuePair<string, string> item in GlobalConstants.PRINT_TYPE_MAP )
            {
                ComboboxItem cbItem = new ComboboxItem ( item.Key, item.Value );
                this.cbPrintType.Items.Add ( cbItem );
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE ].Equals ( item.Key.ToString ( ) ) )
                {
                    this.cbPrintType.SelectedItem = cbItem;
                }
            }

            //自动向服务器回馈出票结果
            this.chIsAutoFeedback.Checked = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK ].Equals ( "1" ) ? true : false;
        }

        private void btnUpdateSysParam_Click ( object sender, EventArgs e )
        {
            try
            {
                MsgBox.MsgDialogResult result = MsgBox.getInstance ( ).Show ( "是否确定要进行修改?", "提示", MsgBox.MyButtons.OKCancel );
                if ( result == MsgBox.MsgDialogResult.OK )
                {
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE ] = ( ( ComboboxItem ) this.cBoxServer.SelectedItem ).Key.ToString ( );
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL ] = ( ( ComboboxItem ) this.cbPrinterModel.SelectedItem ).Key.ToString ( );
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME ] = ( ( ComboboxItem ) this.cbDataKeepTime.SelectedItem ).Key.ToString ( );
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE ] = ( ( ComboboxItem ) this.cbLocation.SelectedItem ).Key.ToString ( );
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE ] = ( ( ComboboxItem ) this.cbPrintType.SelectedItem ).Key.ToString ( );
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK ] = this.chIsAutoFeedback.Checked ? "1" : "0";

                    if ( new SystemSettingsController ( ).updateSystemConfig ( new Dictionary<String, String> ( ) { 
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE]},
                        {GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK,Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK]}} ) )
                    {
                        Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE = ( ( ComboboxItem ) this.cbPrintType.SelectedItem ).Key.Equals ( Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER ) || ( ( ComboboxItem ) this.cbPrintType.SelectedItem ).Key.Equals ( Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER_QRCODE );     
                        MsgBox.getInstance ( ).Show ( "修改系统参数成功!", "提示", MsgBox.MyButtons.OK );
                        this.Close ( );
                    }
                    else
                    {
                        MsgBox.getInstance ( ).Show ( "修改系统设置错误!", "提示", MsgBox.MyButtons.OK );
                    }
                }
            }
            catch ( Exception ex )
            {
                MsgBox.getInstance ( ).Show ( ex.Message, "提示", MsgBox.MyButtons.OK );
            }
        }
    }
}
