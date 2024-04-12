using System.Windows;
using System.Windows.Controls;

namespace CompareDatabase.WindowUI.Sub
{
    public partial class DbManager : Window
    {
        private SqliteManager sqlManager { get; set; }

        private int TargetKey { get; set; } = -1;

        private MainWindow _main;

        public DbManager(MainWindow main)
        {
            _main = main;
            InitializeComponent();

            sqlManager = new SqliteManager();
            this.LoadDatabase();
        }

        public void LoadDatabase()
        {
            List<DatabaseInfo> databaseList = sqlManager.GetDatabaseInfo();
            databaseDataGrid.ItemsSource = databaseList;
            databaseDataGrid.DisplayMemberPath = "Title";
            databaseDataGrid.SelectedValuePath = "Idx";
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            this.ClearForm();
        }

        private void ClearForm()
        {
            titleTextBox.Text = "";
            connectionStringTextBox.Text = "";
            this.TargetKey = -1;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTextBox.Text;
            string connStr = connectionStringTextBox.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Database이름이 지정되지 않았습니다.");
            }
            else if (string.IsNullOrWhiteSpace(connStr))
            {
                MessageBox.Show("Database 연결문자열이 지정되지 않았습니다.");
            }
            else
            {
                if (this.TargetKey > -1)
                {
                    sqlManager.UpdateDatabaseInfo(title, connStr, this.TargetKey);
                }
                else
                {
                    sqlManager.AddDatabaseInfo(title, connStr);
                }
                UpdateDatabaseGrid();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TargetKey > 0)
            {
                sqlManager.DeleteDatabaseInfo(this.TargetKey);
                UpdateDatabaseGrid();
            }
            else
            {
                MessageBox.Show("대상이 지정되지 않았습니다.");
            }
        }

        private void DatabaseDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (databaseDataGrid.SelectedItem != null)
            {
                DatabaseInfo selectedDatabase = (DatabaseInfo)databaseDataGrid.SelectedItem;
                titleTextBox.Text = selectedDatabase.Title;
                connectionStringTextBox.Text = selectedDatabase.ConnectionString;
                TargetKey = selectedDatabase.Idx;
            }
        }

        private void UpdateDatabaseGrid()
        {
            this.LoadDatabase();
            this.ClearForm();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this._main.LoadDatabase();
            this.Close();
        }
    }
}
