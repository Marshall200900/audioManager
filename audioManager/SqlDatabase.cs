using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace audioManager
{
    static class SqlDatabase
    {

        public static string GetQuery(MainForm.Table state)
        {
            switch (state)
            {
                case MainForm.Table.Import:
                case MainForm.Table.Songs: return Properties.Resources.allQuery;
                case MainForm.Table.Albums: return "select * from albums";
                case MainForm.Table.Authors: return "select * from authors";
            }
            return null;
        }
        private static SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-TP148UI;Initial Catalog=\"Music Library\";Integrated Security=True");

        public static void Connect()
        {
            Connection.Open();
        }

        public static void DeleteSongs(List<int> ids)
        {

            foreach(var id in ids)
            {
                SqlCommand command = new SqlCommand(Properties.Resources.deleteSong, Connection);
                command.Parameters.AddWithValue("@song_id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteAuthors(List<int> ids)
        {
            foreach (var id in ids)
            {
                SqlCommand command = new SqlCommand(Properties.Resources.deleteAuthor, Connection);
                command.Parameters.AddWithValue("@author_id", id);
                command.ExecuteNonQuery();
            }


        }
        public static void DeleteAlbums(List<int> ids)
        {
            foreach (var id in ids)
            {
                SqlCommand command = new SqlCommand(Properties.Resources.deleteAlbum, Connection);
                command.Parameters.AddWithValue("@album_id", id);
                command.ExecuteNonQuery();
            }


        }
        public static void AddFiles(List<TagLib.File> files)
        {
            foreach(var f in files)
            {
                AddFile(f);
                
            }
        }

        public static void CloseConnection()
        {
            Connection.Close();

        }
        public static List<string> GetColumnNames(MainForm.Table state)
        {
            SqlCommand command = new SqlCommand(GetQuery(state), Connection);
            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            SqlDataReader reader = command.ExecuteReader();
            List<string> output = new List<string>();
            for(int i = 0;i< reader.FieldCount;i++)
            {
                output.Add(reader.GetName(i));
            }
            reader.Close();
            return output;
        }
        public static void AddFile(TagLib.File file)
        {
            string name = file.Name.Substring(file.Name.LastIndexOf('\\')+1, file.Name.LastIndexOf('.')- file.Name.LastIndexOf('\\')-1);

            int duration = (int)file.Properties.Duration.TotalSeconds;
            string format = file.Name.Split('.').Last();
            string album = file.Tag.Album;
            string artist = file.Tag.FirstPerformer;
            string genre = file.Tag.Genres.Length == 0 ? null: file.Tag.Genres.First() ;
            string path = file.Name.Substring(0, file.Name.LastIndexOf('\\'));
            int year = (int)file.Tag.Year;
            int track = (int)file.Tag.Track;

            SqlCommand cmd = new SqlCommand();
            if (CheckSong(path, name, format)) return;

            AddGenre(genre);
            AddFormat(format);
            AddAlbum(album, year);
            AddPath(path);
            AddAuthor(artist, "");
            AddSong(name, duration, year, format, path, artist, genre);
            AddSongsNAlbums(name, album);
        }
        public static string GetFullPath(int song_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = Properties.Resources.getFullPath;
            cmd.Parameters.AddWithValue("@song_id", song_id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var a = reader[0].ToString();
            reader.Close();
            return a;

        }
        public static bool CheckSong(string path, string name, string format)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = Properties.Resources.checkSong;
            cmd.Parameters.AddWithValue("@song_name", name);
            cmd.Parameters.AddWithValue("@format_name", format);
            cmd.Parameters.AddWithValue("@path_name", path);
            SqlDataReader reader = cmd.ExecuteReader();


            bool a = reader.HasRows;
            reader.Close();
            return a;
        }
        public static List<List<string>> LoadAuthors()
        {

            List<List<string>> output = new List<List<string>>();
            string QUERY_STRING = "select * from authors";
            SqlCommand command = new SqlCommand(QUERY_STRING, Connection);


            SqlDataReader reader = command.ExecuteReader();

            DataColumnCollection columns = reader.GetSchemaTable().Columns;
            while (reader.Read())
            {
                output.Add(new List<string>());
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output.Last().Add(reader[i].ToString());
                }
            }
            reader.Close();
            command.Dispose();
            return output;
        }
        public static List<List<string>> LoadAlbums()
        {

            List<List<string>> output = new List<List<string>>();
            string QUERY_STRING = "select * from albums";
            SqlCommand command = new SqlCommand(QUERY_STRING, Connection);


            SqlDataReader reader = command.ExecuteReader();

            DataColumnCollection columns = reader.GetSchemaTable().Columns;
            while (reader.Read())
            {
                output.Add(new List<string>());
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output.Last().Add(reader[i].ToString());
                }
            }
            reader.Close();
            command.Dispose();
            return output;
        }
        public static void ChangeAuthorName(int author_id, string author_name)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeAuthorName, Connection);
            command.Parameters.AddWithValue("@author_id", author_id);
            command.Parameters.AddWithValue("@author_name", author_name);
            command.ExecuteNonQuery();
        }
        public static void ChangeAlbumDateViaId(int album_id, int album_date)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeAlbumDateViaId, Connection);
            command.Parameters.AddWithValue("@album_id", album_id);
            command.Parameters.AddWithValue("@album_date", album_date);
            command.ExecuteNonQuery();
        }
        public static void ChangeAlbumName(int album_id, string album_name)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeAlbumName, Connection);
            command.Parameters.AddWithValue("@album_id", album_id);
            command.Parameters.AddWithValue("@album_name", album_name);
            command.ExecuteNonQuery();
        }
        public static List<List<string>> LoadShort()
        {
            
            List<List<string>> output = new List<List<string>>();
            string QUERY_STRING = Properties.Resources.shortQuery;
            SqlCommand command = new SqlCommand(QUERY_STRING, Connection);
            

            SqlDataReader reader = command.ExecuteReader();

            DataColumnCollection columns = reader.GetSchemaTable().Columns;
            while (reader.Read())
            {
                output.Add(new List<string>());
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output.Last().Add(reader[i].ToString());
                }
            }
            reader.Close();
            command.Dispose();
            return output;
        }
        public static List<List<string>> LoadMedium()

        {
            List<List<string>> output = new List<List<string>>();

            SqlCommand command = new SqlCommand(Properties.Resources.mediumQuery, Connection);


            SqlDataReader reader = command.ExecuteReader();
            DataColumnCollection columns = reader.GetSchemaTable().Columns;

            while (reader.Read())
            {
                output.Add(new List<string>());
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output.Last().Add(reader[i].ToString());
                }
            }
            reader.Close();

            return output;
        }


        public static List<List<string>> LoadAll()
        {
            List<List<string>> output = new List<List<string>>();
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(Properties.Resources.allQuery, Connection);

            // Open the connection in a try/catch block. 
            // Create and execute the DataReader, writing the result
            // set to the console window.
            SqlDataReader reader = command.ExecuteReader();
            DataColumnCollection columns = reader.GetSchemaTable().Columns;
            while (reader.Read())
            {
                output.Add(new List<string>());
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    output.Last().Add(reader[i].ToString());
                }
            }
            reader.Close();

            return output;
        }
        public static void ChangeName(int id, string newname)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongName, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            command.Parameters.AddWithValue("@song_name", newname);
            command.ExecuteNonQuery();


        }
        public static void ChangeSongDate(int id, int date)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongDate, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            if(date == 0)
            {
                command.Parameters.AddWithValue("@song_date", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@song_date", date);

            }
            command.ExecuteNonQuery();
        }
        public static void ChangeAlbumDate(int id, int date)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeAlbumDate, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            if (date == 0)
            {
                command.Parameters.AddWithValue("@album_date", DBNull.Value);

            }
            else
            {
                command.Parameters.AddWithValue("@album_date", date);

            }
            command.ExecuteNonQuery();
        }
        public static void ChangeGenre(int id, string genre)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongGenre, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            command.Parameters.AddWithValue("@genre_name", genre);
            command.ExecuteNonQuery();
        }
        public static void ChangeAuthor(int id, string author)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongAuthor, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            command.Parameters.AddWithValue("@author_name", author);
            command.ExecuteNonQuery();
        }
        public static void ChangeAlbum(int id, string album)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongAlbum, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            command.Parameters.AddWithValue("@album_name", album);
            command.ExecuteNonQuery();
        }
        public static void ChangeCountry(int id, string country)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.changeSongCountry, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            command.Parameters.AddWithValue("@country_name", country);
            command.ExecuteNonQuery();
        }

        public static string GetPath(int id)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.getPathById, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            string output = null;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                output = reader[0].ToString();
                
            }
            reader.Close();
            return output;
        }

        public static string GetFormat(int id)
        {
            SqlCommand command = new SqlCommand(Properties.Resources.getFormatById, Connection);
            command.Parameters.AddWithValue("@song_id", id);
            string output = null;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                output = reader[0].ToString();
            }
            reader.Close();

            return output;
        }
        public static void AddGenre(string genre)
        {
            if(genre!="" && genre != null)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addGenre;

                command.Parameters.AddWithValue("@genre", genre);
                command.ExecuteNonQuery();
                
            }
        }

        public static void AddCountry(string country)
        {
            if (country != "" && country != null)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addCountry;

                command.Parameters.AddWithValue("@country", country);
                command.ExecuteNonQuery();

            }
        }
        public static void AddFormat(string format)
        {
            if (format != "" && format != null)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addFormat;

                command.Parameters.AddWithValue("@format", format);
                command.ExecuteNonQuery();
            }
        }
        public static void AddAlbum(string album, int date)
        {
            if (album != "" && album != null)
            {
                
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addAlbum;

                command.Parameters.AddWithValue("@name", album);
                if (date == 0)
                {
                    command.Parameters.AddWithValue("@date", DBNull.Value);

                }
                else
                {
                    command.Parameters.AddWithValue("@date", date);
                }
                command.ExecuteNonQuery();
            }
        }
        public static void AddPath(string path)
        {
            if (path != "" && path != null)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addPath;

                command.Parameters.AddWithValue("@path", path);
                command.ExecuteNonQuery();
            }
        }
        public static void AddAuthor(string author, string country_name)
        {
            if (author != "" && author != null)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addAuthor;

                command.Parameters.AddWithValue("@name", author);
                command.ExecuteNonQuery();
            }
        }
        public static void AddSong(string name, int duration, int date, string format_name, string path_name, string author_name, string genre_name)
        {
            if (path_name != "" && path_name != null)
            {
                if (format_name == null) format_name = "";
                if (path_name == null) path_name = "";
                if (author_name == null) author_name = "";
                if (genre_name == null) genre_name = "";


                SqlCommand command = new SqlCommand();
                command.Connection = Connection;
                command.CommandText = Properties.Resources.addSong;

                command.Parameters.AddWithValue("@path", path_name);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@duration", duration);
                command.Parameters.AddWithValue("@format_name", format_name);
                if(date == 0)
                {
                    command.Parameters.AddWithValue("@date", DBNull.Value);

                }
                else
                {
                    command.Parameters.AddWithValue("@date", date);

                }
                if (author_name == null || author_name == "")
                {
                    command.Parameters.AddWithValue("@author_name", DBNull.Value);

                }
                else
                {
                    command.Parameters.AddWithValue("@author_name", author_name);

                }
                if(genre_name == null || genre_name == "")
                {
                    command.Parameters.AddWithValue("@genre_name", DBNull.Value);

                }
                else
                {
                    command.Parameters.AddWithValue("@genre_name", genre_name);

                }
                command.ExecuteNonQuery();
            }   
        }
        public static void AddSongsNAlbums(string song_name, string album_name)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Connection;
            command.CommandText = Properties.Resources.addSongsNAlbums;
            command.Parameters.AddWithValue("@song_name", song_name);
            command.Parameters.AddWithValue("@album_name", album_name);
            command.ExecuteNonQuery();
        }
    }
}
