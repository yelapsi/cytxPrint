using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Maticsoft.Controller;
using Maticsoft.Common;
using Maticsoft.Common.Util;
using Maticsoft.Common.model;

namespace Demo
{
    public partial class UnitConfigStoreMachine : UserControl
    {
        public UnitConfigStoreMachine()
        {
            InitializeComponent();
        }

        //加载彩机设置界面时要先初始化一些值
        private void sysParamConfig_Load(object sender, EventArgs e)
        {
            initStoreMachineDGV();
        }
        
        /// <summary>
        /// 初始化彩机列表区域
        /// </summary>
        private void initStoreMachineDGV(){
            //初始化已有彩机
            this.moduleMachineButtonHolder.StoreMachineList = Global.storeMachineList;
        }
    }
}
