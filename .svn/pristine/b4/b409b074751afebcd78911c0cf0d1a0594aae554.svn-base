using Maticsoft.Common.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo
{
    public partial class PanelMachinesList : UserControl
    {
        private List<store_machine> macList = new List<store_machine>();

        public PanelMachinesList()
        {
            InitializeComponent();
        }

        public void addMachine(List<store_machine> macListNew)
        {
            if (macListNew != null)
            {
                if (macListNew.Count > 0)
                {
                    this.macList.AddRange(macListNew);

                    foreach (store_machine mac in macListNew)
                    {
                        Button btnMachine = new Button();
                        btnMachine.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        btnMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                        btnMachine.Size = new System.Drawing.Size(70, 70);
                        btnMachine.Location = new System.Drawing.Point(3 + (this.macList.Count-1) * btnMachine.Width, 3);
                        btnMachine.Name = string.Format("btnMac{0}", this.macList.Count + 1);
                        btnMachine.TabIndex = this.macList.Count + 1;
                        btnMachine.Text = mac.machine_name;
                        btnMachine.UseVisualStyleBackColor = true;
                        btnMachine.Click += btnMachine_Click;

                        this.Controls.Add(btnMachine);
                    }
                }
            }
        }

        private void btnMachine_Click(object sender, EventArgs e)
        {
            this.Visible = !this.Visible;
        }
    }
}
