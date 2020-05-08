using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace audioManager
{
    public partial class Constructor : Form
    {
        public string result = "";
        public SqlCommand cmd;
        public Constructor()
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zeroitMetroButton1_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int date1 = 0;
            int date2 = 0;
            try
            {
                if (year.Text.Contains('-'))
                {
                    date1 = int.Parse(year.Text.Split('-')[0]);
                    date2 = int.Parse(year.Text.Split('-')[1]);

                }
                else
                {
                    date1 = int.Parse(year.Text);
                    date2 = date1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введена дата");
                return;
            }

            SqlCommand command = new SqlCommand(Properties.Resources.constructorQuery);
            command.Parameters.AddWithValue("@date1", date1);
            command.Parameters.AddWithValue("@date2", date2);
            command.Parameters.AddWithValue("@album_name", album.Text);
            cmd = command;

            switch (combo.Text)
            {
                case "Название": result = "song_name";
                    break;
                case "Альбом": result = "album";
                    break;
                case "Все поля": result = "*";
                    break;
            }

        }
    }
}
