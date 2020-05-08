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
    public partial class Settings : Form
    {
        MainForm Form;
        MainForm.Appearance st;
        public Settings(Form form, MainForm.Appearance state)
        {
            InitializeComponent();
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            //btnCancel.DialogResult = DialogResult.OK;

            st = state;
            Form = (MainForm)form;

            switch (state)
            {
                case MainForm.Appearance.ShortSongs: radioButton1.Checked = true;
                    break;
                case MainForm.Appearance.MediumSongs: radioButton2.Checked = true;
                    break;
                case MainForm.Appearance.AllSongs: radioButton3.Checked = true;
                    break;
            }
        }

        private void UpdateBtns()
        {
            if (radioButton1.Checked)
            {
                Form.CurState = MainForm.Appearance.ShortSongs;
            }
            else if (radioButton2.Checked)
            {
                Form.CurState = MainForm.Appearance.MediumSongs;
            }
            else
            {
                Form.CurState = MainForm.Appearance.AllSongs;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBtns();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBtns();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBtns();

        }

        private void zeroitMetroButton1_Click(object sender, EventArgs e)
        {

        }

        private void zeroitMetroButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void zeroitMetroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
