using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common.Util;
using Maticsoft.Common;
using Maticsoft.Controller;
using Maticsoft.BLL.ScanPortImage;

namespace Demo
{
    public partial class TabConfig : UserControl
    {
        SystemSettingsController syscon = new SystemSettingsController ( );
        Point location = new Point(15, 10);
        private ItemMenuButtom configBtn = new ItemMenuButtom();
        //写成公有对象 因为该控件clear的时候 串口需要关闭
        UnitConfigCMDTest unitConfigCMDTest = null;
        UnitConfigCMDTestForPrinter unitConfigCMDTestForPrinter = null;

        public TabConfig()
        {
            InitializeComponent();
        }

        private void TabConfig_Load(object sender, EventArgs e)
        {
            UnitMyConfig unitMyConfig = new UnitMyConfig();
            unitMyConfig.Location = location;
            this.configSettingAreaPanel.Controls.Add(unitMyConfig);
            AddEvents();
            this.menuControlsList.HideScrollbar = true;
        }

        /// <summary>
        /// 添加标签的点击事件
        /// </summary>
        private void AddEvents()
        {
            ItemMenuButtom mbcs = new ItemMenuButtom("CONFIG_SYSTEM", "系统设置");
            mbcs.clickHandler += new EventHandler(delegate(object sender, EventArgs e)
            {
                ClosePort();
                Selected(sender);
                this.configSettingAreaPanel.Controls.Clear();
                UnitMyConfig unitMyConfig = new UnitMyConfig();
                unitMyConfig.Location = location;
                this.configSettingAreaPanel.Controls.Add(unitMyConfig);
            });
            Selected(mbcs);
            this.menuControlsList.Add(mbcs);

            ItemMenuButtom mbcm = new ItemMenuButtom("CONFIG_MACHINE", "我的彩机");
            mbcm.clickHandler += new EventHandler(delegate(object sender, EventArgs e)
            {
                ClosePort();
                Selected(sender);
                this.configSettingAreaPanel.Controls.Clear();
                UnitConfigStoreMachine ucsm = new UnitConfigStoreMachine();
                ucsm.Location = location;
                this.configSettingAreaPanel.Controls.Add(ucsm);
            });
            this.menuControlsList.Add(mbcm);

            ItemMenuButtom mbceh = new ItemMenuButtom("CONFIG_ERROR_HANDLER", "错误设置");
            mbceh.clickHandler += new EventHandler(delegate(object sender, EventArgs e)
            {
                ClosePort();
                Selected(sender);
                this.configSettingAreaPanel.Controls.Clear();
                UnitConfigErrorHandlerPage u =new UnitConfigErrorHandlerPage();
                u.Location = new Point(15,0);
                this.configSettingAreaPanel.Controls.Add(u);
            });
            this.menuControlsList.Add(mbceh);

            ItemMenuButtom imbAudio = new ItemMenuButtom("CONFIG_AUDIO", "音频设置");
            imbAudio.clickHandler += new EventHandler(delegate(object sender, EventArgs e)
            {
                ClosePort();
                Selected(sender);
                this.configSettingAreaPanel.Controls.Clear();
                UnitConfigAudio u = new UnitConfigAudio();
                u.Location = new Point(15, 0);
                this.configSettingAreaPanel.Controls.Add(u);
            });
            this.menuControlsList.Add(imbAudio);

            ItemMenuButtom mbcmd = new ItemMenuButtom("CONFIG_CMD_TEST", "命令测试");
            mbcmd.clickHandler += new EventHandler(delegate(object sender, EventArgs e)
            {
                ClosePort();
                Selected(sender);
                this.configSettingAreaPanel.Controls.Clear();

                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE].Equals(Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.MACHINE))
                {
                    unitConfigCMDTest = new UnitConfigCMDTest();
                    unitConfigCMDTest.Location = new Point(-2, 0);
                    this.configSettingAreaPanel.Controls.Add(unitConfigCMDTest);
                }
                else
                {
                    unitConfigCMDTestForPrinter = new UnitConfigCMDTestForPrinter();
                    unitConfigCMDTestForPrinter.Location = new Point(-2, 0);
                    this.configSettingAreaPanel.Controls.Add(unitConfigCMDTestForPrinter);
                }
            });
            this.menuControlsList.Add(mbcmd);
        }

        //关闭UnitConfigCMDTest控件的串口
        public void ClosePort()
        {
            if (unitConfigCMDTest != null)
            {
                unitConfigCMDTest = null;
            }
        }

        private void Selected(object sender)
        {
            Control c = (Control)sender;
            while (c.GetType() != typeof(ItemMenuButtom))
            {
                c = c.Parent;
            }
            configBtn = c as ItemMenuButtom;
            foreach (ItemMenuButtom btnMenu in this.menuControlsList.ControlList.Controls)
            {
                if (btnMenu.Selected)
                {
                    btnMenu.Selected = false;
                }
            }
            configBtn.Selected = true;
        }

        private void radBtnPrintingChanel01_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            SPImageGlobal.IS_PRINT_SCAN_IMAGE = rb.Checked;
            try
            {
                this.syscon.updateSystemConfig ( new System.Collections.Generic.Dictionary<
                    String, String> ( ) { { GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE, rb.Checked?
                                              GlobalConstants.PRINT_TYPE.MACHINE:GlobalConstants.PRINT_TYPE.PRINTER} } );
            }
            catch ( Exception)
            { }
        }
    }
}
