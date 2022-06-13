using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ItemMenuButtom : UserControl
    {
        private string _name;
        private string menuCode;
        private EventHandler _clickHandler;
        private bool selected = false;
        private Image selectedImg;
        private Image unselectedImg;

        public string MenuCode
        {
            get { return menuCode; }
            set
            { 
                menuCode = value;
                switch (menuCode)
                {
                    case "CONFIG_SYSTEM":
                        this.selectedImg = global::Demo.Properties.Resources.csszb;
                        this.unselectedImg = global::Demo.Properties.Resources.cssz;
                        break;
                    case "CONFIG_MACHINE":
                        this.selectedImg = global::Demo.Properties.Resources.cjszb1;
                        this.unselectedImg = global::Demo.Properties.Resources.cjsz1;
                        break;
                    case "CONFIG_ERROR_HANDLER":
                        this.selectedImg = global::Demo.Properties.Resources.cwszb;
                        this.unselectedImg = global::Demo.Properties.Resources.cwsz;
                        break;
                    case "CONFIG_AUDIO":
                        this.selectedImg = global::Demo.Properties.Resources.ypszb;
                        this.unselectedImg = global::Demo.Properties.Resources.ypsz;
                        break;
                    case "CONFIG_CMD_TEST":
                        this.selectedImg = global::Demo.Properties.Resources.xtszb;
                        this.unselectedImg = global::Demo.Properties.Resources.xtsz;
                        break;
                    default:
                        break;
                }
                this.picMenu.BackgroundImage = this.unselectedImg;
            }
        }
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
                this.lbName.Text = this._name;
            }
        }

        public EventHandler clickHandler
        {
            get { return this._clickHandler; }
            set
            {
                this._clickHandler = value;
                this.Click += this._clickHandler;
                this.picMenu.Click += this._clickHandler;
                this.lbName.Click += this._clickHandler;
            }
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected)
                {
                    if (this.BackgroundImage != global::Demo.Properties.Resources.xzzt1)
                    {
                        this.picMenu.BackgroundImage = this.selectedImg;
                        this.BackgroundImage = global::Demo.Properties.Resources.xzzt1;
                        this.lbName.ForeColor = Color.White;
                    }
                }
                else
                {
                    if (this.BackgroundImage != global::Demo.Properties.Resources.wxzzt)
                    {
                        this.picMenu.BackgroundImage = this.unselectedImg;
                        this.BackgroundImage = global::Demo.Properties.Resources.wxzzt;
                        this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    }
                }
            }
        }

        public ItemMenuButtom()
        {
            InitializeComponent();
        }

        public ItemMenuButtom(string menuCode, string name)
            : this()
        {
            this.MenuCode = menuCode;
            this.name = name;
        }
    }
}
