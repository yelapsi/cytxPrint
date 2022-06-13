using Maticsoft.Common;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Demo
{
    public partial class UnitConfigAudio : UserControl
    {
        SystemSettingsController systemSettingsController = new SystemSettingsController ( );
        //3种音频文件 （错漏票、未出票和手工/反馈）
        int type = 0;
        //当前选中的音频文件
        private RadioButton checkedRadioButton = new RadioButton();
        //保存后的音频文件
        private ItemAudio currentItemAudio = new ItemAudio();

        public UnitConfigAudio()
        {
            InitializeComponent();

            this.audioControlsList.ControlList.BackColor = Color.White;
            this.audioControlsList.Gap = 10;
        }

        private void UnitConfigAudio_Load(object sender, EventArgs e)
        {
            try
            {
                //加载音频文件
                FileInfo[] fsi = Global.AUDIO_FILES_BASEDIR.GetFiles();

                //加载无提示音选项
                ItemAudio itemAudioMute = new ItemAudio();
                itemAudioMute.RadioButton.Text = "无提示音";
                itemAudioMute.AudioFileFullName = "";
                this.audioControlsList.Add(itemAudioMute);

                //选中系统当前音频文件
                if (String.IsNullOrEmpty(Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER]))
                {
                    itemAudioMute.RadioButton.Checked = true;
                    this.CheckedRadioButton = itemAudioMute.RadioButton;
                    //当前系统的音频文件的ItemAudio控件
                    this.CurrentItemAudio = itemAudioMute;
                }
                itemAudioMute.BtnSave.Click += this.btnSaveAudio_Click;
                itemAudioMute.RadioButton.CheckedChanged += radioButton_CheckedChanged;

                //加载有提示音选项
                for (int i = 0; i < fsi.Length; i++)
                {
                    if (SysUtil.isAudioFile(fsi[i].Extension))
                    {
                        ItemAudio itemAudio = new ItemAudio();
                        itemAudio.RadioButton.Text = fsi[i].Name.Replace(fsi[i].Extension, "");
                        itemAudio.AudioFileFullName = fsi[i].Name;
                        this.audioControlsList.Add(itemAudio);
                        //选中系统当前音频文件
                        if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ]
                            .Contains ( itemAudio.RadioButton.Text ) )
                        {
                            itemAudio.RadioButton.Checked = true;
                            this.CheckedRadioButton = itemAudio.RadioButton;
                            //当前系统的音频文件的ItemAudio控件
                            this.CurrentItemAudio = itemAudio;
                        }

                        itemAudio.BtnSave.Click += this.btnSaveAudio_Click;
                        itemAudio.RadioButton.CheckedChanged += radioButton_CheckedChanged;
                    }
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 切换tab时重新确定当前系统音频
        /// </summary>
        private void UnitConfigAudioTabChange(string audioPath)
        {
            int i = 0;
            bool isContinue = true;
            try
            {
                foreach (ItemAudio itemAudio in this.audioControlsList.ControlList.Controls)
                {
                    //选中系统当前音频文件
                    if (itemAudio.AudioFileFullName.Contains(audioPath) && isContinue)
                    {
                        itemAudio.RadioButton.Checked = true;
                        this.CheckedRadioButton = itemAudio.RadioButton;
                        //当前系统的音频文件的ItemAudio控件
                        this.CurrentItemAudio = itemAudio;
                        isContinue = false;
                        i++;
                    }
                    else
                    {
                        itemAudio.RadioButton.Checked = false;
                    }
                }

                if (i <= 0)
                {
                    ItemAudio itemAudio = this.audioControlsList.ControlList.Controls[0] as ItemAudio;
                    itemAudio.RadioButton.Checked = true;
                    this.CheckedRadioButton = itemAudio.RadioButton;
                    this.CurrentItemAudio = itemAudio;
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 选中音频事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            //修改保存按钮文字 保存后显示“选中”
            string strPath = "";
            switch (this.type)
            {
                case 0:
                    strPath = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ];
                    break;
                case 1:
                    strPath = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR ];
                    break;
                default:
                    strPath = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL ];
                    break;
            }

            if (String.IsNullOrEmpty(((ItemAudio)(((RadioButton)sender).Parent)).AudioFileFullName))
            {
                if (((RadioButton)sender).Checked)
                {
                    ((ItemAudio)(((RadioButton)sender).Parent)).BtnSave.Visible = true;
                    this.CheckedRadioButton.Checked = false;
                    this.CheckedRadioButton = sender as RadioButton;
                }
                else
                {
                    if (!((ItemAudio)(((RadioButton)sender).Parent)).Selected)
                    {
                        ((ItemAudio)(((RadioButton)sender).Parent)).BtnSave.Visible = false;
                    }
                }

                if ((((ItemAudio)(((RadioButton)sender).Parent)).AudioFileFullName).Equals(strPath))
                {
                    (((ItemAudio)(((RadioButton)sender).Parent)).BtnSave).Enabled = false;
                    ((ItemAudio)(((RadioButton)sender).Parent)).Selected = true;
                }
                else
                {
                    (((ItemAudio)(((RadioButton)sender).Parent)).BtnSave).Enabled = true;
                    ((ItemAudio)(((RadioButton)sender).Parent)).Selected = false;
                }
                return;
            }

            //从文件夹读取文件名列表
            FileSystemInfo[] fsi = Global.AUDIO_FILES_BASEDIR.GetFileSystemInfos();

            //选中该音频
            if (((RadioButton)sender).Checked)
            {
                ((ItemAudio)(((RadioButton)sender).Parent)).BtnSave.Visible = true;//显示保存按钮
                foreach (FileSystemInfo fileSystemInfo in fsi)
                {
                    if (fileSystemInfo.Name.Contains(((RadioButton)sender).Text))
                    {
                        this.CheckedRadioButton.Checked = false;
                        this.CheckedRadioButton = sender as RadioButton;
                    }
                }

                try
                {
                    //试听开始
                    if (!String.IsNullOrEmpty(((ItemAudio)(((RadioButton)sender).Parent)).AudioFileFullName))
                    {
                        System.Media.SoundPlayer sp = new SoundPlayer();
                        sp.SoundLocation = Global.AUDIO_FILES_BASEDIR.FullName + ((ItemAudio)(((RadioButton)sender).Parent)).AudioFileFullName;
                        sp.Play();
                    }
                }
                catch
                {}
            }
            else
            {
                if (((ItemAudio)(((RadioButton)sender).Parent)).Selected)
                {
                    ((ItemAudio)(((RadioButton)sender).Parent)).Selected = false;
                }
            }

            //修改保存按钮文字 保存后显示“已保存”
            if ((((ItemAudio)(((RadioButton)sender).Parent)).AudioFileFullName).Equals(strPath))
            {
                (((ItemAudio)(((RadioButton)sender).Parent)).BtnSave).Enabled = false;
                ((ItemAudio)(((RadioButton)sender).Parent)).Selected = true;
            }
            else
            {
                (((ItemAudio)(((RadioButton)sender).Parent)).BtnSave).Enabled = true;
                ((ItemAudio)(((RadioButton)sender).Parent)).Selected = false;
            }
        }

        /// <summary>
        /// 保存音频事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveAudio_Click(object sender, EventArgs e)
        {
            this.CurrentItemAudio.BtnSave.Visible = false;
            Dictionary<String, String> kv = new Dictionary<string, string> ( );

            switch ( this.type )
            {
                case 0:
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ] =
                        ( ( ItemAudio ) ( ( Button ) sender ).Parent ).AudioFileFullName;
                    kv.Add ( GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER, 
                        Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ] );
                    break;
                case 1:
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR ] =
                        ( ( ItemAudio ) ( ( Button ) sender ).Parent ).AudioFileFullName;
                    kv.Add ( GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR,
                        Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR ] );
                    break;
                default:
                    Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL ] =
                        ( ( ItemAudio ) ( ( Button ) sender ).Parent ).AudioFileFullName;
                    kv.Add ( GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL,
                        Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL ] );
                    break;
            }

            this.systemSettingsController.updateSystemConfig ( kv );
            ( ( ItemAudio ) ( ( Button ) sender ).Parent ).Selected = true;
            ( ( Button ) sender ).Enabled = false;
            this.CurrentItemAudio = ( ( Button ) sender ).Parent as ItemAudio;
        }

        public ItemAudio CurrentItemAudio
        {
            get { return currentItemAudio; }
            set
            {
                if (!currentItemAudio.Equals(value))
                {
                    currentItemAudio.Selected = false;
                    currentItemAudio.BtnSave.Visible = false;
                }
                currentItemAudio = value;
                currentItemAudio.Selected = true;
                currentItemAudio.BtnSave.Visible = true;
            }
        }

        public RadioButton CheckedRadioButton
        {
            get { return checkedRadioButton; }
            set { checkedRadioButton = value; }
        }

        private void lbErrorTone_Click(object sender, EventArgs e)
        {
            this.lbErrorTone.ForeColor = System.Drawing.Color.White;
            this.lbErrorTone.Image = global::Demo.Properties.Resources.audioTab;

            this.lbHasOrderTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbHasOrderTone.Image = null;

            this.lbConfirmOrderTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbConfirmOrderTone.Image = null;

            type = 0;
            this.UnitConfigAudioTabChange ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ] );
        }

        private void lbHasOrderTone_Click(object sender, EventArgs e)
        {
            this.lbErrorTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbErrorTone.Image = null;

            this.lbHasOrderTone.ForeColor = System.Drawing.Color.White;
            this.lbHasOrderTone.Image = global::Demo.Properties.Resources.audioTab;

            this.lbConfirmOrderTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbConfirmOrderTone.Image = null;

            type = 1;
            this.UnitConfigAudioTabChange ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR ] );
        }

        private void lbConfirmOrderTone_Click(object sender, EventArgs e)
        {
            this.lbErrorTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbErrorTone.Image = null;

            this.lbHasOrderTone.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbHasOrderTone.Image = null;

            this.lbConfirmOrderTone.ForeColor = System.Drawing.Color.White;
            this.lbConfirmOrderTone.Image = global::Demo.Properties.Resources.audioTab;

            type = 2;
            this.UnitConfigAudioTabChange ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL ] );
        }
    }
}