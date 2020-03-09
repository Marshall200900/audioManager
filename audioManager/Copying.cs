using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace audioManager
{
    public partial class Copying : Form
    {
        public string path;
        public Copying(List<int> ids)
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void Copying_Load(object sender, EventArgs e)
        {

        }

        private void Copying_Shown(object sender, EventArgs e)
        {
            
        }

        private void label1_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void label1_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void zeroitMetroButton1_Click(object sender, EventArgs e)
        {


            btnBegin.Enabled = false;
            List<string> files = Directory.GetFiles(path.ToString()).ToList();
            foreach (var file in files)
            {
                File.Copy(file, @"D:\music\" + file.Split('\\').Last());
            }
            Dispose();
        }

        private void zeroitMetroButton2_Click(object sender, EventArgs e)
        {
            Dispose();

        }
    }
}
