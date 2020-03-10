using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;
using System.Threading;

namespace audioManager
{
    public partial class MainForm : Form
    {
        bool changed = false;
        string changingCell = "";
        List<int> rowsToSave = new List<int>();
        List<int> rowsToImport = new List<int>();
        List<string> columnsToSave = new List<string>();
        public enum State
        {
            ShortSongs,
            MediumSongs,
            AllSongs,
            Albums,
            Authors,
            ToImport
        }
        public State CurState = State.MediumSongs;
        public MainForm()
        {
            SqlDatabase.Connect();
            InitializeComponent();
            UpdateTable();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=DESKTOP-TP148UI;Initial Catalog=\"Music Library\";Integrated Security=True";
            //string queryString = @"select song_name, album_name from songs
            //                        left join songs_in_albums
            //                        on songs.song_id = songs_in_albums.song_id left join albums on songs_in_albums.album_id = albums.album_id; ";

            //using (SqlConnection connection =
            //new SqlConnection(connectionString))
            //{
            //    // Create the Command and Parameter objects.
            //    SqlCommand command = new SqlCommand(queryString, connection);
                
            //    // Open the connection in a try/catch block. 
            //    // Create and execute the DataReader, writing the result
            //    // set to the console window.
            //    try
            //    {
            //        table.Columns.Add("genre_id", "genre_id");
            //        table.Columns.Add("genre_name", "genre_name");

            //        connection.Open();
            //        SqlDataReader reader = command.ExecuteReader();
                    
            //        while (reader.Read())
            //        {
            //            table.Rows.Add(reader[0], reader[1]);
            //        }
            //        reader.Close();
                    
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    Console.ReadLine();
            //}
    }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void добавитьФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "d:\\music";
                openFileDialog.Filter = "Music files (*.mp3, *.flac, *.wav)|*.mp3;*.flac;*.wav";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach(var filename in openFileDialog.FileNames)
                    {
                        //Get the path of specified file
                        filePath = filename;

                        var file = TagLib.File.Create(filePath);

                        SqlDatabase.AddFile(file);
                    }
                   

                    UpdateTable();
                }
            }
        }

        private void добавитьПапкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {
                string[] extentions = { ".flac", ".mp3", ".wav"};
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.SelectedPath;
                    DirectoryInfo d = new DirectoryInfo(filePath);
                    List<TagLib.File> files = new List<TagLib.File>();
                    foreach (var file in d.GetFiles())
                    {

                        if (extentions.Contains(file.Extension))
                        {
                            files.Add(TagLib.File.Create(file.FullName));
                        }
                    }
                    
                    SqlDatabase.AddFiles(files);
                    UpdateTable();
                }
            }

        }

        private void loadallsongs_Click(object sender, EventArgs e)
        {

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int songIndex = table.Columns["song_name"].Index;
            int albumindex = table.Columns["album_name"].Index;
            int authorIndex = table.Columns["author_name"].Index;
            foreach (DataGridViewRow row in table.Rows)
            {

                if (!row.Cells[songIndex].Value.ToString().ToLower().Contains(searchBox.Text.ToLower()) 
                    && !row.Cells[albumindex].Value.ToString().ToLower().Contains(searchBox.Text.ToLower())
                    && !row.Cells[authorIndex].Value.ToString().ToLower().Contains(searchBox.Text.ToLower()))
                {
                    row.Visible = false; 
                }
                else
                {
                    row.Visible = true;
                }
                    
            }
        }

        private void table_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, CurState);
            settings.ShowDialog();
            
            UpdateTable();
            //if(settings.DialogResult == DialogResult.OK)
            //{
            //    settings.Close();
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void zeroitMetroButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zeroitMetroButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void loadallsongs_Click_1(object sender, EventArgs e)
        {

        }
        public void SaveAlbums()
        {

            int id;
            for (int i = 0; i < rowsToSave.Count; i++)
            {

                switch (columnsToSave[i])
                {
                    case "album_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["album_id"].Index].Value.ToString());
                        string author_name = table.Rows[rowsToSave[i]].Cells[table.Columns["album_name"].Index].Value.ToString();
                        SqlDatabase.ChangeAlbumName(id, author_name);
                        break;
                    case "album_date":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["album_id"].Index].Value.ToString());
                        int date = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["album_date"].Index].Value.ToString());
                        SqlDatabase.ChangeAlbumDateViaId(id, date);
                        break;
                }
            }
        }
        public void SaveAuthors()
        {
            int id;
            for (int i = 0; i < rowsToSave.Count; i++)
            {
                switch (columnsToSave[i])
                {
                    case "author_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["author_id"].Index].Value.ToString());
                        string author_name = table.Rows[rowsToSave[i]].Cells[table.Columns["author_name"].Index].Value.ToString();
                        SqlDatabase.ChangeAuthorName(id, author_name);
                        break;
                }
            }
        }
        public void SaveSongs()
        {
            int id;
            for (int i = 0; i < rowsToSave.Count; i++)
            {
                switch (columnsToSave[i])
                {
                    case "song_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        string newname = table.Rows[rowsToSave[i]].Cells[table.Columns["song_name"].Index].Value.ToString();
                        SqlDatabase.ChangeName(id, newname);
                        break;
                    case "genre_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        string genre = table.Rows[rowsToSave[i]].Cells[table.Columns["genre_name"].Index].Value.ToString();
                        SqlDatabase.AddGenre(genre);
                        SqlDatabase.ChangeGenre(id, genre);
                        break;
                    case "author_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        string author = table.Rows[rowsToSave[i]].Cells[table.Columns["author_name"].Index].Value.ToString();
                        SqlDatabase.AddAuthor(author, "");
                        SqlDatabase.ChangeAuthor(id, author);
                        break;
                    case "album_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        string album = table.Rows[rowsToSave[i]].Cells[table.Columns["album_name"].Index].Value.ToString();
                        SqlDatabase.AddAlbum(album, 0);
                        SqlDatabase.ChangeAlbum(id, album);
                        break;
                    case "country_name":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        string country = table.Rows[rowsToSave[i]].Cells[table.Columns["country_name"].Index].Value.ToString();
                        SqlDatabase.AddCountry(country);
                        SqlDatabase.ChangeCountry(id, country);
                        break;
                    case "album_date":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        int date = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["album_date"].Index].Value.ToString());
                        SqlDatabase.ChangeAlbumDate(id, date);
                        break;
                    case "song_date":
                        id = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_id"].Index].Value.ToString());
                        int date2 = int.Parse(table.Rows[rowsToSave[i]].Cells[table.Columns["song_date"].Index].Value.ToString());
                        SqlDatabase.ChangeSongDate(id, date2);
                        break;
                }
            }
        }
        private void Save()
        {
            switch (CurState)
            {
                case State.Albums: SaveAlbums(); break;
                case State.Authors: SaveAuthors(); break;
                default: SaveSongs();break;
            }
            rowsToSave.Clear();
            columnsToSave.Clear();
            changed = false;
            MessageBox.Show("Сохранение прошло успешно!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void UpdateTable()
        {
            if (CurState == State.AllSongs)
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            else
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.Rows.Clear();
            table.Columns.Clear();
            table.Refresh();
            List<List<string>> list = new List<List<string>>();
            switch (CurState)
            {
                case State.ShortSongs:
                    list = SqlDatabase.LoadShort();
                    break;
                case State.MediumSongs:
                    list = SqlDatabase.LoadMedium();
                    break;
                case State.AllSongs:
                    list = SqlDatabase.LoadAll();
                    break;
                case State.Albums:
                    list = SqlDatabase.LoadAlbums();
                    break;
                case State.Authors:
                    list = SqlDatabase.LoadAuthors();
                    break;
            }

            foreach (string s in SqlDatabase.GetColumnNames(CurState))
            {
                table.Columns.Add(s, s);
            }

            foreach (var b in list)
            {
                table.Rows.Add(b.ToArray());
            }
            foreach(DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void table_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
            
        }

        private void table_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            changingCell = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        }

        private void table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (CurState)
            {
                case State.AllSongs:
                case State.ShortSongs:
                case State.MediumSongs:
                    CheckCorrectnessSongs(e);
                    break;
                case State.Albums:
                    CheckCorrectnessAlbums(e);
                    break;
                case State.Authors:
                    CheckCorrectnessAuthors(e);
                    break;
            }
          
        }
        private void CheckCorrectnessAlbums(DataGridViewCellEventArgs e)
        {
            if(table.Rows[e.RowIndex].Cells["album_name"].Value == null)
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Нельзя сделать поле названия альбома пустым, вместо этого воспользуйтесь удалением");

            }
            if (table.Columns[e.ColumnIndex].Name == "album_date" && !CheckDate(table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Неверный формат");
            }

            char[] forbidden = { '\\', '/', ':', '*', '?', '<', '>', '|' };
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().IndexOfAny(forbidden) != -1)
            {
                MessageBox.Show("Нельзя вводить данные символы: " + new string(forbidden));
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }

            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell && (table.Columns[e.ColumnIndex].Name == "album_id"))
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Невозможно изменить это значение");
                return;
            }
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell)
            {
                if (!(rowsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    rowsToSave.Add(e.RowIndex);
                    columnsToSave.Add(table.Columns[e.ColumnIndex].Name);
                    changed = true;
                }
            }


        }
        private void CheckCorrectnessAuthors(DataGridViewCellEventArgs e)
        {
            if (table.Rows[e.RowIndex].Cells["author_name"].Value == null)
            {
                MessageBox.Show("Нельзя сделать поле названия автора пустым, вместо этого воспользуйтесь удалением");

            }
            char[] forbidden = { '\\', '/', ':', '*', '?', '<', '>', '|' };
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().IndexOfAny(forbidden) != -1)
            {
                MessageBox.Show("Нельзя вводить данные символы: " + new string(forbidden));
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }

            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell && (table.Columns[e.ColumnIndex].Name == "album_id"))
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Невозможно изменить это значение");
                return;
            }
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell)
            {
                if (!(rowsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    rowsToSave.Add(e.RowIndex);
                    columnsToSave.Add(table.Columns[e.ColumnIndex].Name);
                    changed = true;
                }
            }
        }
        private void CheckCorrectnessSongs(DataGridViewCellEventArgs e)
        {

            if (table.Columns[e.ColumnIndex].Name == "album_date" && table.Rows[e.RowIndex].Cells["album_name"].Value == null)
            {
                MessageBox.Show("Невозможно назначить дату альбома, пока нет самого альбома");
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }
            if (table.Columns[e.ColumnIndex].Name == "song_date" && !CheckDate(table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Неверный формат");
            }
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null && table.Columns[e.ColumnIndex].Name == "song_name")
            {
                MessageBox.Show("Имя не может быть пустым");
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }
            if (table.Columns[e.ColumnIndex].Name == "country_name" && table.Rows[e.RowIndex].Cells["author_name"].Value == null)
            {
                MessageBox.Show("Невозможно назначить страну автора, пока не назначен сам автор");
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell && (table.Columns[e.ColumnIndex].Name == "duration"
                || table.Columns[e.ColumnIndex].Name == "format_name" || table.Columns[e.ColumnIndex].Name == "directory")
                 || table.Columns[e.ColumnIndex].Name == "song_id"
                 || table.Columns[e.ColumnIndex].Name == "path_name" || table.Columns[e.ColumnIndex].Name == "song_name")
            {
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                MessageBox.Show("Невозможно изменить это значение");
                return;
            }

            char[] forbidden = { '\\', '/', ':', '*', '?', '<', '>', '|' };
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().IndexOfAny(forbidden) != -1)
            {
                MessageBox.Show("Нельзя вводить данные символы: " + new string(forbidden));
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;
                return;
            }

            int id = int.Parse(table.Rows[e.RowIndex].Cells[0].Value.ToString());
            string format = SqlDatabase.GetFormat(id);
            string path = SqlDatabase.GetPath(id);
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell && (SqlDatabase.CheckSong(path,
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),
                format)))
            {
                MessageBox.Show("В одной директории не могут находиться файлы с одинаковым названием!");
                table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = changingCell;

                return;
            }

            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != changingCell)
            {
                if (!(rowsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    rowsToSave.Add(e.RowIndex);
                    columnsToSave.Add(table.Columns[e.ColumnIndex].Name);
                    changed = true;
                }
            }
        }
        private void zeroitMetroButton6_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void вывестиСписокАльбомовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnNoImport.Enabled = false;

            if (CurState == State.Albums) return;
            if (changed)
            {
                UserCheck check = new UserCheck();
                var res = check.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Save();
                }
                else if(res == DialogResult.Abort)
                {
                    return;
                }
                
            }
            changed = false;
            rowsToSave.Clear();
            columnsToSave.Clear();
            CurState = State.Albums;
            UpdateTable();
            settingsButton.Enabled = false;

        }

        private void вывестиСписокПесенToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
            btnNoImport.Enabled = true;

            if (CurState == State.ShortSongs || CurState == State.MediumSongs || CurState == State.AllSongs) return;
            if (changed)
            {
                UserCheck check = new UserCheck();
                var res = check.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Save();
                }
                else if (res == DialogResult.Abort)
                {

                    return;
                }

            }
            changed = false;
            rowsToSave.Clear();
            columnsToSave.Clear();
            CurState = State.MediumSongs;
            UpdateTable();
            settingsButton.Enabled = true;

        }
        private bool CheckDate(string value)
        {
            int year;
            bool result = int.TryParse(value, out year);
            if(year<0 || year > 2020)
            {
                result = false;
            }
            return result;
        }
        private void вывестиСписокИсполнителейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnNoImport.Enabled = false;
            if (CurState == State.Authors) return;
            if (changed)
            {
                UserCheck check = new UserCheck();
                var res = check.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Save();
                }
                else if (res == DialogResult.Abort)
                {

                    return;
                }

            }
            changed = false;
            rowsToSave.Clear();
            columnsToSave.Clear();
            CurState = State.Authors;
            UpdateTable();
            settingsButton.Enabled = false;
        }

        private void zeroitMetroButton3_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            foreach(DataGridViewRow a in table.SelectedRows)
            {
                rows.Add(int.Parse(table.Rows[a.Index].Cells[0].Value.ToString()));
            }
            if (rows.Count == 0) return;
            switch (CurState)
            {
                case State.AllSongs:
                case State.MediumSongs:
                case State.ShortSongs:
                    SqlDatabase.DeleteSongs(rows);
                    break;
                case State.Albums:
                    try
                    {
                        SqlDatabase.DeleteAlbums(rows);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Невозможно удалить выбранные альбомы, так как в этих альбомах есть песни");
                        return;
                    }
                    break;
                case State.Authors:
                    try
                    {
                        SqlDatabase.DeleteAuthors(rows);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Невозможно удалить выбранных авторов, так как в базе данных есть песни этих авторов");
                        return;
                    }
                    break;
            }
            UpdateTable();
            MessageBox.Show("Удаление прошло успешно!");
        }

        private void импортироватьВExcelФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in table.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in table.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Music");
                    wb.SaveAs(dialog.FileName);
                }
                MessageBox.Show("Успешно сохранено!");
            }
            
        }

        private void импортироватьНаУстройствоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rowsToImport.Count == 0)
            {
                MessageBox.Show("Сначала файлы для импорта");
                return;


            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            Copying copying = new Copying(rowsToImport);
            var res = dialog.ShowDialog();
            
            if(res == DialogResult.OK)
            {
                copying.path = dialog.SelectedPath;
                try
                {
                    copying.ShowDialog();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Невозможно скопировать в эту директорию");
                    return;
                }
            }
            rowsToImport.Clear();
        }
        

        private void zeroitMetroButton5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in table.SelectedRows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());
                if (!rowsToImport.Contains(id))
                {
                    rowsToImport.Add(id);
                }
            }
            MessageBox.Show("Добавлены выбранные элементы");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void btnNoImport_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in table.SelectedRows)
            {
                int id = int.Parse(row.Cells[0].Value.ToString());
                if (rowsToImport.Contains(id))
                {
                    rowsToImport.Remove(id);
                }
            }
            MessageBox.Show("Удалены выбранные элементы");
        }

        private void отобразитьВыбранныеПесниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in table.Rows)
            {

                if (rowsToImport.Contains(int.Parse(row.Cells[0].Value.ToString())))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }

            }
        }
    }
   
}
