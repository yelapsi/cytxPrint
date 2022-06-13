using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ModuleMachineButtonHolder : UserControl
    {
        private ItemMachineButton currentMachine;
        private IList<store_machine> storeMachineList;

        public ModuleMachineButtonHolder()
        {
            InitializeComponent();
        }

        private void ModuleMachineButtonHolder_Load(object sender, EventArgs e)
        {
            
        }

        public ItemMachineButton CurrentMachine
        {
            get { return currentMachine; }
            set
            {
                currentMachine = value;
                if (null != currentMachine)
                {
                    this.txtAutoTurnOffAfterComplete.Text = currentMachine.Machine.is_compl_auto_stop.ToString().Equals(
                        GlobalConstants.TrueFalseSign.TRUE) ? "是" : "否";
                    this.txtBigTicketPassword.Text = string.IsNullOrEmpty(currentMachine.Machine.big_ticket_pass.ToString())?"":"******";
                    this.txtBigTicketPrice.Text = currentMachine.Machine.big_ticket_amount.ToString();
                    this.txtCheckBit.Text = currentMachine.Machine.com_parity.ToString();
                    this.txtDataBit.Text = currentMachine.Machine.com_databits.ToString();
                    this.txtIncessantPrint.Text = currentMachine.Machine.is_continuous_ticket.ToString().Equals(
                        GlobalConstants.TrueFalseSign.TRUE) ? "是" : "否";
                    this.txtIsAutoPrint.Text = currentMachine.Machine.is_auto_ticket.ToString().Equals(
                        GlobalConstants.TrueFalseSign.TRUE) ? "是" : "否";
                    this.txtIsFeedback.Text = currentMachine.Machine.is_feed_back.ToString().Equals(
                        GlobalConstants.TrueFalseSign.TRUE)?"是":"否";
                    this.txtMachineName.Text = currentMachine.Machine.machine_name.ToString();
                    this.txtMachineType.Text = GlobalConstants.machineTypeDictionary[currentMachine.Machine.machine_type]; 
                    this.txtSerialPort.Text = currentMachine.Machine.com_name.ToString();
                    this.txtSpeedLevel.Text = GlobalConstants.SpeedLevelDictionary[ currentMachine.Machine.speed_level.ToString()];
                    this.txtStopBit.Text = currentMachine.Machine.com_stopbits.ToString();
                    this.txtTerminalNumber.Text = currentMachine.Machine.terminal_number.ToString();
                    this.txtVelocity.Text = currentMachine.Machine.com_baudrate.ToString();
                }
            }
        }

        public IList<store_machine> StoreMachineList
        {
            get { return storeMachineList; }
            set
            {
                storeMachineList = value;
                if (null != storeMachineList)
                {
                    int machineIndex = 1;
                    foreach (store_machine machine in storeMachineList)
                    {
                        ItemMachineButton machimeBtn = new ItemMachineButton();
                        machimeBtn.MachineName = machineIndex + "号彩机";
                        machimeBtn.Location = new Point((10 * machineIndex + machimeBtn.Width * (machineIndex - 1)), 0);
                        machimeBtn.Machine = machine;
                        this.plButtonHolder.Controls.Add(machimeBtn);
                        if (machineIndex == 1)
                        {
                            machimeBtn.Selected = true;
                        }
                        else
                        {
                            machimeBtn.Selected = false;
                        }
                        machineIndex++;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmConfigPopupAddMachines frmConfigPopupAddMachines = new FrmConfigPopupAddMachines(currentMachine.Machine);
            frmConfigPopupAddMachines.ShowDialog();

            //重新赋值，刷新界面
            this.CurrentMachine = this.currentMachine;
        }
    }
}
