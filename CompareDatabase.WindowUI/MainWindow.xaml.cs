using CompareDatabase.WindowUI.Sub;
using System.Windows;
using System.Windows.Controls;

namespace CompareDatabase.WindowUI
{
    public partial class MainWindow : Window
    {
        public string LocalDB_ConnStr { get; set; } = string.Empty;

        public string TargetDB_ConnStr { get; set; } = string.Empty;

        public CompareDb OriginDB { get; set; }

        public CompareDb TargetDB { get; set; }

        private SqliteManager sqlManager { get; set; }

        public CompareModel compareModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            sqlManager = new SqliteManager();
            compareModel = new CompareModel();

            this.LoadDatabase();
        }

        public void LoadDatabase()
        {
            List<DatabaseInfo> databaseList = sqlManager.GetDatabaseInfo();
            originDatabaseComboBox.ItemsSource = databaseList;
            originDatabaseComboBox.DisplayMemberPath = "Title";
            originDatabaseComboBox.SelectedValuePath = "ConnectionString";
            targetDatabaseComboBox.ItemsSource = databaseList;
            targetDatabaseComboBox.DisplayMemberPath = "Title";
            targetDatabaseComboBox.SelectedValuePath = "ConnectionString";
        }

        private void TargetDatabaseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (targetDatabaseComboBox.SelectedItem != null)
            {
                string connectionString = ((DatabaseInfo)targetDatabaseComboBox.SelectedItem).ConnectionString;
                this.TargetDB = new CompareDb(connectionString);
                var targetClients = this.TargetDB.GetClients();
                targetClientComboBox.ItemsSource = targetClients;
                targetClientComboBox.DisplayMemberPath = "ClientId";
                targetClientComboBox.SelectedValuePath = "Id";
            }
        }

        private void OriginDatabaseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (originDatabaseComboBox.SelectedItem != null)
            {
                string connectionString = ((DatabaseInfo)originDatabaseComboBox.SelectedItem).ConnectionString;
                this.OriginDB = new CompareDb(connectionString);
                var originClients = this.OriginDB.GetClients();
                originClientComboBox.ItemsSource = originClients;
                originClientComboBox.DisplayMemberPath = "ClientId";
                originClientComboBox.SelectedValuePath = "Id";
            }
        }

        private async void OriginClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (originClientComboBox.SelectedItem != null)
            {
                int idx = ((Clients)originClientComboBox.SelectedItem).Id;
                var originClients = this.OriginDB.GetClient(idx);
                compareModel.AddOrigin(originClients);
                var clientClaims = await this.OriginDB.GetClientClaimsAsync(idx);
                compareModel.AddOrigin(clientClaims);
                var clientCorsOrigins = await this.OriginDB.GetClientCorsOriginsAsync(idx);
                compareModel.AddOrigin(clientCorsOrigins);
                var clientGrantTypes = await this.OriginDB.GetClientGrantTypesAsync(idx);
                compareModel.AddOrigin(clientGrantTypes);
                var clientIdPRestrictions = await this.OriginDB.GetClientIdPRestrictionsAsync(idx);
                compareModel.AddOrigin(clientIdPRestrictions);
                var clientProperties = await this.OriginDB.GetClientPropertiesAsync(idx);
                compareModel.AddOrigin(clientProperties);
                var clientRedirectUris = await this.OriginDB.GetClientRedirectUrisAsync(idx);
                compareModel.AddOrigin(clientRedirectUris);

                var clientScopes = await this.OriginDB.GetClientScopeAsync(idx);
                if (clientScopes != null && clientScopes.Count > 0)
                {
                    compareModel.AddTarget("ClientScopes", String.Join(',', (from a in clientScopes select a.Scope).ToList()));
                    foreach (var scope in clientScopes)
                    {
                        var apiScopes = await this.OriginDB.GetApiScopesAsync(scope.Scope);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiScopeClaims = await this.OriginDB.GetApiScopeClaimsAsync(apiScopes.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiScopeProperties = await this.OriginDB.GetApiScopePropertiesAsync(apiScopes.Id);
                        compareModel.AddTarget(clientRedirectUris);

                        var apiResource = await this.OriginDB.GetApiResourcesAsync(scope.Scope);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceScopes = await this.OriginDB.GetApiResourceScopesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceClaims = await this.OriginDB.GetApiResourceClaimsAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceProperties = await this.OriginDB.GetApiResourcePropertiesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceSecrets = await this.OriginDB.GetApiResourcePropertiesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                    }
                }
            }
        }

        private async void TargetClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (targetClientComboBox.SelectedItem != null)
            {
                int idx = ((Clients)targetClientComboBox.SelectedItem).Id;
                var targetClients = this.TargetDB.GetClient(idx);
                compareModel.AddTarget(targetClients);
                var clientClaims = await this.TargetDB.GetClientClaimsAsync(idx);
                compareModel.AddTarget(clientClaims);
                var clientCorsOrigins = await this.TargetDB.GetClientCorsOriginsAsync(idx);
                compareModel.AddOrigin(clientCorsOrigins);
                var clientGrantTypes = await this.TargetDB.GetClientGrantTypesAsync(idx);
                compareModel.AddOrigin(clientGrantTypes);
                var clientIdPRestrictions = await this.TargetDB.GetClientIdPRestrictionsAsync(idx);
                compareModel.AddOrigin(clientIdPRestrictions);
                var clientProperties = await this.TargetDB.GetClientPropertiesAsync(idx);
                compareModel.AddOrigin(clientProperties);
                var clientRedirectUris = await this.TargetDB.GetClientRedirectUrisAsync(idx);
                compareModel.AddOrigin(clientRedirectUris);

                var clientScopes = await this.TargetDB.GetClientScopeAsync(idx);
                if (clientScopes != null && clientScopes.Count > 0)
                {
                    compareModel.AddTarget("ClientScopes", String.Join(',', (from a in clientScopes select a.Scope).ToList()));
                    foreach (var scope in clientScopes)
                    {
                        var apiScopes = await this.TargetDB.GetApiScopesAsync(scope.Scope);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiScopeClaims = await this.TargetDB.GetApiScopeClaimsAsync(apiScopes.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiScopeProperties = await this.TargetDB.GetApiScopePropertiesAsync(apiScopes.Id);
                        compareModel.AddTarget(clientRedirectUris);

                        var apiResource = await this.TargetDB.GetApiResourcesAsync(scope.Scope);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceScopes = await this.TargetDB.GetApiResourceScopesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceClaims = await this.TargetDB.GetApiResourceClaimsAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceProperties = await this.TargetDB.GetApiResourcePropertiesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                        var apiResourceSecrets = await this.TargetDB.GetApiResourcePropertiesAsync(apiResource.Id);
                        compareModel.AddTarget(clientRedirectUris);
                    }
                }
            }
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            comparisonDataGrid.ItemsSource = compareModel.Data;
        }

        private void DatabaseManagementButton_Click(object sender, RoutedEventArgs e)
        {
            DbManager databaseManagerWindow = new DbManager(this);
            databaseManagerWindow.Owner = this;
            databaseManagerWindow.ShowDialog();
        }
    }
}