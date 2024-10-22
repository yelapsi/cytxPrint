﻿using Maticsoft.Common;
using Maticsoft.Common.SingleUpload;
using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmJcSingleLoad : Form
    {
        private TabUploadTxt tabUploadTxt;

        public FrmJcSingleLoad()
        {
            InitializeComponent();
        }

        public FrmJcSingleLoad(TabUploadTxt tabUploadTxt)
            : this()
        {
            this.tabUploadTxt = tabUploadTxt;
        }

        private void FrmJcSingleLoad_Load(object sender, EventArgs e)
        {
            try
            {
                int x = 0;
                int y = 0;
                int maxMatchNum = 0;
                Label preLabel = null;
                string currentDate = "";

                string response = HTTPHelper.HttpHandler("", "http://collection.cp020.com/global/schudle/9/schedules.js").Replace("var schedules = ", "");

                List<GuessFootball> gfList = (List<GuessFootball>)JSonHelper.JsonToGuessFootballList<List<GuessFootball>>(response);
                gfList.Sort();

                foreach (GuessFootball gf in gfList)
                {
                    string strDate = gf.id.ToString().Substring(0, 8);
                    string strIndex = gf.id.ToString().Substring(8, 3);

                    CheckBoxEx c = new CheckBoxEx();
                    c.Width = 1000;
                    c.Text = gf.id.ToString();// strIndex;
                    c.GuessFootball = gf;
                    c.CheckedChanged += new System.EventHandler(this.checkedChanged);

                    if (!currentDate.Equals(strDate))
                    {
                        currentDate = strDate;
                        if (preLabel != null)
                        {
                            preLabel.Text = string.Format(preLabel.Text, maxMatchNum);
                            maxMatchNum = 0;
                        }

                        preLabel = new Label();
                        preLabel.Width = this.tableLayoutPanel.Width;
                        preLabel.Text = currentDate + "  " + DateUtil.data2weekDayCStrTranslation(currentDate) + "  " + string.Format("截止时间：({0}", gf.stopTime) + ")  {0}场比赛可投注";
                        this.tableLayoutPanel.SetColumnSpan(preLabel, 4);

                        preLabel.Text += string.Format("(x:{0},y:{1})", 0, y);//test

                        x = 0;
                        y++;
                        //this.tableLayoutPanel.Controls.Add(preLabel, x, y);
                        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                    }
                    
                    int m = x;
                    int n = y;

                    x++;
                    x = x % 4;
                    if (0 == x)
                    {
                        y++;

                        this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                    }

                    c.Text += string.Format("(x:{0},y:{1})", m, n);//test
                    this.tableLayoutPanel.Controls.Add(c, m, n);
                    maxMatchNum++;
                }

                foreach (GuessFootball gf in gfList)
                {
                    CheckBoxEx c = new CheckBoxEx();
                    c.Width = 1000;
                    c.Text = gf.id.ToString();// strIndex;
                    c.GuessFootball = gf;
                    c.CheckedChanged += new System.EventHandler(this.checkedChanged);

                    this.controlsList1.Add(c);
                }
                //preLabel.Text = string.Format(preLabel.Text, maxMatchNum);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            if (((CheckBoxEx)sender).Checked)
            {
                tabUploadTxt.gfList.Add(((CheckBoxEx)(sender)).GuessFootball);
            }
            else
            {
                tabUploadTxt.gfList.Remove(((CheckBoxEx)(sender)).GuessFootball);
            }
        }
    }
}
