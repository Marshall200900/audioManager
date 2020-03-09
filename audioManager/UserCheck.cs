using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace audioManager
{
    public partial class UserCheck : Form
    {
        public UserCheck()
        {
            InitializeComponent();
            btnYes.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Abort;
            btnNo.DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
