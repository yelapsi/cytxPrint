using System.Windows.Forms;
using System.Drawing;

namespace Demo
{
    public partial class FrmPopup : Form
    {
        public FrmPopup()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {            
            this.Dispose();
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btn_MouseHover(object sender, System.EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.popupFocuse;
            ((Control)sender).ForeColor = Color.White;
        }

        private void btn_MouseLeave(object sender, System.EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.xzw;
            ((Control)sender).ForeColor = Color.Black;
        }
    }
}
