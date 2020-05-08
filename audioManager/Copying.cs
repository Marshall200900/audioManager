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
        private List<int> ids;
        public Copying(List<int> ids)
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
            btnBegin.DialogResult = DialogResult.OK;
            this.ids = ids;
            
        }

        private void Copying_Load(object sender, EventArgs e)
        {

        }

        private void Copying_Shown(object sender, EventArgs e)
        {
            label1.Text = "Выбрано песен: " + ids.Count;
            label2.Text = "Выбранный путь: " + path;
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
            string errors = "";
            List<string> paths = new List<string>();
            foreach(int id in ids)
            {
                paths.Add(SqlDatabase.GetFullPath(id));

                
            }

            foreach (var file in paths)
            {
                try
                {
                    File.Copy(file, path + '\\' + file.Split('\\').Last());
                }
                catch (Exception)
                {
                    errors += file.Split('\\').Last() + " ";
                }

            }
            if (errors == "")
            {
                MessageBox.Show("Копирование закончено!");
            }
            else
            {
                MessageBox.Show("Копирование закончено!+\nНе пересены песни с id:" +errors);

            }
            Close();
        }

        private void zeroitMetroButton2_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
