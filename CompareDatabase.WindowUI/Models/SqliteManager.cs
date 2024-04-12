using System.Data.SQLite;
using System.Windows;

namespace CompareDatabase.WindowUI
{
    public class SqliteManager
    {
        private readonly string connectionString;

        public SqliteManager()
        {
            connectionString = $"Data Source=compareDb.sqlite;Version=3;";
            InitializeDatabase();
        }

        // 데이터베이스 초기화
        private void InitializeDatabase()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createTableQuery = "CREATE TABLE IF NOT EXISTS DatabaseInfo (idx INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, connectionString TEXT);";

                    using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite 오류: {ex.Message}");
            }
        }

        // 데이터베이스에 데이터 추가
        public void AddDatabaseInfo(string title, string dbconnStr)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string addDataQuery = "INSERT INTO DatabaseInfo (title, connectionString) VALUES (@Title, @ConnectionString);";

                    using (SQLiteCommand command = new SQLiteCommand(addDataQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@ConnectionString", dbconnStr);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite 오류: {ex.Message}");
            }
        }

        public void UpdateDatabaseInfo(string title, string dbconnStr, int idx)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string addDataQuery = "Update DatabaseInfo set title=, connectionString=@ConnectionString where Idx=@idx;";

                    using (SQLiteCommand command = new SQLiteCommand(addDataQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@ConnectionString", dbconnStr);
                        command.Parameters.AddWithValue("@idx", idx);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite 오류: {ex.Message}");
            }
        }

        // 데이터베이스 정보 조회
        public List<DatabaseInfo> GetDatabaseInfo()
        {
            List<DatabaseInfo> databaseInfoList = new List<DatabaseInfo>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT idx, title, connectionString FROM DatabaseInfo;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idx = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string connStr = reader.GetString(2);

                                databaseInfoList.Add(new DatabaseInfo(idx, title, connStr));
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite 오류: {ex.Message}");
            }

            return databaseInfoList;
        }

        // 데이터베이스 정보 삭제
        public void DeleteDatabaseInfo(int idx)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteDataQuery = "DELETE FROM DatabaseInfo WHERE idx = @Idx;";

                    using (SQLiteCommand command = new SQLiteCommand(deleteDataQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Idx", idx);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"SQLite 오류: {ex.Message}");
            }
        }
    }

    // 데이터베이스 정보 클래스
    public class DatabaseInfo
    {
        public int Idx { get; set; }
        public string Title { get; set; }
        public string ConnectionString { get; set; }

        public DatabaseInfo(int idx, string title, string connectionString)
        {
            Idx = idx;
            Title = title;
            ConnectionString = connectionString;
        }
    }
}
