using System.Windows.Forms;

namespace Demo
{
    public partial class CheckBoxEx : CheckBox
    {
        public CheckBoxEx():base()
        {}

        private Maticsoft.Common.SingleUpload.GuessFootball guessFootball = null;

        public Maticsoft.Common.SingleUpload.GuessFootball GuessFootball
        {
            get { return guessFootball; }
            set { guessFootball = value; }
        }
    }
}
