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
        List<DataGridViewRow> importList = new List<DataGridViewRow>();
        List<int> idsToSave = new List<int>();
        List<int> idsToDelete = new List<int>();
        List<string> columnsToSave = new List<string>();
        public enum Appearance
        {
            ShortSongs,
            MediumSongs,
            AllSongs,

        }
        public enum Table
        {
            Songs,
            Albums,
            Authors,
            Import
        }
        public Appearance CurState = Appearance.MediumSongs;
        public Table CurRequest = Table.Songs;

        public MainForm()
        {
            SqlDatabase.Connect();
            InitializeComponent();
            LoadTable();
            //ImportTable.Columns.AddRange()
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
                   

                    LoadTable();
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
                    LoadTable();
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
            var a = CurState;
            Settings settings = new Settings(this, CurState);
            if (settings.ShowDialog() == DialogResult.OK)
            {
                UpdateAppearance();

            }
            else
            {
                CurState = a;
            }

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
            for (int i = 0; i < idsToSave.Count; i++)
            {

                switch (columnsToSave[i])
                {
                    case "album_name":
                        id = int.Parse(table.Rows[idsToSave[i]].Cells[table.Columns["album_id"].Index].Value.ToString());
                        string author_name = table.Rows[idsToSave[i]].Cells[table.Columns["album_name"].Index].Value.ToString();
                        SqlDatabase.ChangeAlbumName(id, author_name);
                        break;
                    case "album_date":
                        id = int.Parse(table.Rows[idsToSave[i]].Cells[table.Columns["album_id"].Index].Value.ToString());
                        int date = int.Parse(table.Rows[idsToSave[i]].Cells[table.Columns["album_date"].Index].Value.ToString());
                        SqlDatabase.ChangeAlbumDateViaId(id, date);
                        break;
                }
            }
        }
        public void SaveAuthors()
        {
            int id;
            for (int i = 0; i < idsToSave.Count; i++)
            {
                switch (columnsToSave[i])
                {
                    case "author_name":
                        id = int.Parse(table.Rows[idsToSave[i]].Cells[table.Columns["author_id"].Index].Value.ToString());
                        string author_name = table.Rows[idsToSave[i]].Cells[table.Columns["author_name"].Index].Value.ToString();
                        SqlDatabase.ChangeAuthorName(id, author_name);
                        break;
                }
            }
        }
        public void SaveSongs()
        {

            
            for (int i = 0; i < idsToSave.Count; i++)
            {
                DataGridViewRow row = table.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["song_id"].Value.ToString().Equals(idsToSave[i].ToString()))
                    .First();
                switch (columnsToSave[i])
                {
                    case "song_name":
                        string newname = row.Cells[table.Columns["song_name"].Index].Value.ToString();
                        SqlDatabase.ChangeName(idsToSave[i], newname);
                        break;
                    case "genre_name":
                        string genre = row.Cells[table.Columns["genre_name"].Index].Value.ToString();
                        SqlDatabase.AddGenre(genre);
                        SqlDatabase.ChangeGenre(idsToSave[i], genre);
                        break;
                    case "author_name":
                        string author = row.Cells[table.Columns["author_name"].Index].Value.ToString();
                        SqlDatabase.AddAuthor(author, "");
                        SqlDatabase.ChangeAuthor(idsToSave[i], author);
                        break;
                    case "album_name":
                        string album = row.Cells[table.Columns["album_name"].Index].Value.ToString();
                        SqlDatabase.AddAlbum(album, 0);
                        SqlDatabase.ChangeAlbum(idsToSave[i], album);
                        break;
                    case "country_name":
                        string country = row.Cells[table.Columns["country_name"].Index].Value.ToString();
                        SqlDatabase.AddCountry(country);
                        SqlDatabase.ChangeCountry(idsToSave[i], country);
                        break;
                    case "album_date":
                        int date = int.Parse(row.Cells[table.Columns["album_date"].Index].Value.ToString());
                        SqlDatabase.ChangeAlbumDate(idsToSave[i], date);
                        break;
                    case "song_date":
                        int date2 = int.Parse(row.Cells[table.Columns["song_date"].Index].Value.ToString());
                        SqlDatabase.ChangeSongDate(idsToSave[i], date2);
                        break;
                }
            }


        }
        private void Save()
        {
            switch (CurRequest)
            {
                case Table.Albums: SaveAlbums(); break;
                case Table.Authors: SaveAuthors(); break;
                default: SaveSongs();break;
            }
            idsToSave.Clear();
            columnsToSave.Clear();
            changed = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Delete();
            Save();
            
            MessageBox.Show("Успешно сохранено!");
        }
        private void LoadTable()
        {
            table.Rows.Clear();
            table.Columns.Clear();
            table.Refresh();
            List<List<string>> list = new List<List<string>>();
            foreach (string s in SqlDatabase.GetColumnNames(CurRequest))
            {
                table.Columns.Add(s, GetProperName(s));
            }

            switch (CurRequest)
            {
                case Table.Import:
                    ShowImport();
                    UpdateAppearance();
                    break;
                case Table.Songs:
                    list = SqlDatabase.LoadAll();
                    UpdateAppearance();
                    break;
                case Table.Albums:
                    table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    list = SqlDatabase.LoadAlbums();
                    break;
                case Table.Authors:
                    table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    list = SqlDatabase.LoadAuthors();
                    break;

            }

            foreach (var b in list)
            {
                table.Rows.Add(b.ToArray());
            }
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void UpdateAppearance()
        {
            if (CurState == Appearance.AllSongs)
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            else
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            switch (CurState)
            {
                case Appearance.AllSongs:
                    SetTableAll();
                    break;
                case Appearance.MediumSongs:
                    SetTableMedium();
                    break;
                case Appearance.ShortSongs:
                    SetTableSimple();
                    break;
            }
        }

        private void SetTableSimple()
        {
            foreach(DataGridViewColumn column in table.Columns)
            {
                column.Visible = false;
            }
            table.Columns["song_id"].Visible = true;
            table.Columns["song_name"].Visible = true;
            table.Columns["author_name"].Visible = true;

        }
        private void SetTableMedium()
        {
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.Visible = false;
            }
            table.Columns["song_id"].Visible = true;
            table.Columns["song_name"].Visible = true;
            table.Columns["author_name"].Visible = true;
            table.Columns["album_name"].Visible = true;
            table.Columns["duration"].Visible = true;


        }
        private void SetTableAll()
        {
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.Visible = true;
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
            switch (CurRequest)
            {
                case Table.Songs:
                case Table.Import:
                    CheckCorrectnessSongs(e);
                    break;
                case Table.Albums:
                    CheckCorrectnessAlbums(e);
                    break;
                case Table.Authors:
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
                if (!(idsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    idsToSave.Add(int.Parse(table.Rows[e.RowIndex].Cells[0].Value.ToString()));
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
                if (!(idsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    idsToSave.Add(int.Parse(table.Rows[e.RowIndex].Cells[0].Value.ToString()));
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
                if (!(idsToSave.Contains(e.RowIndex) && columnsToSave.Contains(table.Columns[e.ColumnIndex].Name)))
                {
                    idsToSave.Add(int.Parse(table.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    columnsToSave.Add(table.Columns[e.ColumnIndex].Name);
                    changed = true;
                }
            }
        }
        private void zeroitMetroButton6_Click(object sender, EventArgs e)
        {
            LoadTable();

        }

        private void вывестиСписокАльбомовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnNoImport.Enabled = false;

            if (CurRequest == Table.Albums) return;
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
            idsToSave.Clear();
            columnsToSave.Clear();
            CurRequest = Table.Albums;
            LoadTable();
            settingsButton.Enabled = false;

        }

        private void вывестиСписокПесенToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = true;
            btnNoImport.Enabled = true;

            if (CurRequest == Table.Songs) return;
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
            idsToSave.Clear();
            idsToDelete.Clear();
            columnsToSave.Clear();
            CurRequest = Table.Songs;
            LoadTable();
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
            if (CurRequest == Table.Authors) return;
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
            idsToSave.Clear();
            idsToDelete.Clear();

            columnsToSave.Clear();
            CurRequest = Table.Authors;
            LoadTable();
            settingsButton.Enabled = false;
        }
        private void Delete()
        {
            
            if (idsToDelete.Count == 0) return;
            switch (CurRequest)
            {
                case Table.Songs:
                    SqlDatabase.DeleteSongs(idsToDelete);
                    break;
                case Table.Albums:
                    try
                    {
                        SqlDatabase.DeleteAlbums(idsToDelete);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Невозможно удалить выбранные альбомы, так как в этих альбомах есть песни");
                        return;
                    }
                    break;
                case Table.Authors:
                    try
                    {
                        SqlDatabase.DeleteAuthors(idsToDelete);
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Невозможно удалить выбранных авторов, так как в базе данных есть песни этих авторов");
                        return;
                    }
                    break;
            }
            LoadTable();
            idsToDelete.Clear();
        }
        private void zeroitMetroButton3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow a in table.SelectedRows)
            {
                int id = int.Parse(table.Rows[a.Index].Cells[0].Value.ToString());
                a.Visible = false;
                idsToDelete.Add(id);
                if (idsToSave.Contains(id))
                {
                    idsToSave.Remove(id);
                }
                if (importList.Contains(a))
                {
                    importList.Remove(a);
                    ShowImport();
                }
            }

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
            if (importList.Count == 0)
            {
                MessageBox.Show("Сначала добавьте файлы для импорта");
                return;
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            List<int> rowsToImport = new List<int>();
            foreach(DataGridViewRow row in importList)
            {
                rowsToImport.Add(int.Parse(row.Cells["song_id"].Value.ToString()));
            }
            Copying copying = new Copying(rowsToImport);
            var res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                copying.path = dialog.SelectedPath;
                try
                {
                    if(copying.ShowDialog() != DialogResult.Cancel)
                    {
                        importList.Clear();

                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Невозможно скопировать в эту директорию");
                    return;
                }
            }
            
        }
        

        private void zeroitMetroButton5_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in table.SelectedRows)
            {
                if (!importList.Contains(row))
                {
                    importList.Add(row);

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
                if (importList.Contains(row))
                {
                    importList.Remove(row);
                }
            }
            if (CurRequest == Table.Import) ShowImport();
            MessageBox.Show("Удалены выбранные элементы");
        }

        private void отобразитьВыбранныеПесниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowImport();
        }
        private void ShowImport()
        {
            CurRequest = Table.Import;
            table.Rows.Clear();
            foreach (DataGridViewRow row in importList)
            {
                table.Rows.Add(row);
            }
        }
        private string GetProperName(string s)
        {
            switch (s)
            {
                case "song_name": return "Название";
                case "album_name": return "Альбом";
                case "id": return "Идентификатор";
                case "duration": return "Длительность";
                case "country_name": return "Название страны";
                case "author_name": return "Исполнитель";
                case "song_id": return "Идентификатор";


            }
            return s;
        }
        private void конструкторЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Constructor constructor = new Constructor();
            if (constructor.ShowDialog() == DialogResult.OK)
            {
                //constructor.result;
                //constructor.cmd;


                btnImport.Enabled = true;
                btnNoImport.Enabled = true;

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
                idsToSave.Clear();
                idsToDelete.Clear();
                columnsToSave.Clear();
                CurRequest = Table.Songs;
                LoadTable();
                settingsButton.Enabled = true;
            }
        }
    }
   
}
