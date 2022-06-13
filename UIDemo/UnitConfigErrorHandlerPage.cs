using System;
using System.Windows.Forms;
using Maticsoft.Common;
using Maticsoft.Common.model;
using System.Drawing;
using System.IO;
using Maticsoft.Controller;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class UnitConfigErrorHandlerPage : UserControl
    {
        //当前选中的音频文件
        private RadioButton checkedRadioButton = new RadioButton();
        //保存后的音频文件
        private ItemAudio currentItemAudio = new ItemAudio();         

        public UnitConfigErrorHandlerPage()
        {
            InitializeComponent();
        }

        private void UnitConfigErrorHandlerPage_Load(object sender, EventArgs e)
        {
            //this.errorControlsList.ControlList.BackColor = Color.White;
            //this.errorControlsList.Gap = 10;
            if (null != Global.errorhandlist && Global.errorhandlist.Count > 0)
            {
                ItemSpreadWindow spreadWindow = new ItemSpreadWindow(Global.errorhandlist[0]);
                //spreadWindow.Holder = this.errorControlsList;
                this.panelspread.Controls.Add(spreadWindow);
            }

            //try
            //{
            //    //加载音频文件                
            //    FileInfo[] fsi = Global.AUDIO_FILES_BASEDIR.GetFiles();

            //    //加载无提示音选项
            //    ItemAudio itemAudioMute = new ItemAudio();
            //    itemAudioMute.RadioButton.Text = "无提示音";
            //    itemAudioMute.AudioFileFullName = "";
            //    this.errorControlsList.Add(itemAudioMute);
            //    //选中系统当前音频文件
            //    if (String.IsNullOrEmpty(Global.sysconfig.audio_file_fullname))
            //    {
            //        itemAudioMute.RadioButton.Checked = true;
            //        this.CheckedRadioButton = itemAudioMute.RadioButton;
            //        //当前系统的音频文件的ItemAudio控件
            //        this.CurrentItemAudio = itemAudioMute;
            //    }
            //    itemAudioMute.BtnSave.Click += this.btnSaveAudio_Click;
            //    itemAudioMute.RadioButton.CheckedChanged += radioButton_CheckedChanged;

            //    //加载有提示音选项
            //    for (int i = 0; i < fsi.Length; i++)
            //    {
            //        try
            //        {
            //            if (SysUtil.isAudioFile(fsi[i].Extension))
            //            {
            //                ItemAudio itemAudio = new ItemAudio();
            //                itemAudio.RadioButton.Text = fsi[i].Name.Replace(fsi[i].Extension, "");
            //                itemAudio.AudioFileFullName = fsi[i].Name;
            //                this.errorControlsList.Add(itemAudio);
            //                //选中系统当前音频文件
            //                if (Global.sysconfig.audio_file_fullname.Contains(itemAudio.RadioButton.Text))
            //                {
            //                    itemAudio.RadioButton.Checked = true;
            //                    this.CheckedRadioButton = itemAudio.RadioButton;
            //                    //当前系统的音频文件的ItemAudio控件
            //                    this.CurrentItemAudio = itemAudio;
            //                }

            //                itemAudio.BtnSave.Click += this.btnSaveAudio_Click;
            //                itemAudio.RadioButton.CheckedChanged += radioButton_CheckedChanged;
            //            }                         
            //        }
            //        catch (Exception)
            //        {}                    
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

    }
}
