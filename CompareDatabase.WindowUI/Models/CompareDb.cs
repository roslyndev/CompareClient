using Microsoft.Data.SqlClient;

namespace CompareDatabase.WindowUI
{
    public class CompareDb
    {
        private readonly string _connectionString;

        protected SqlConnection SqlConn { get; set; }

        public CompareDb(string connStr)
        {
            this._connectionString = connStr;
            if (!string.IsNullOrWhiteSpace(this._connectionString))
            {
                this.SqlConn = new SqlConnection(_connectionString);
                this.SqlConn.Open();
            }

        }


        public List<Clients> GetClients()
        {
            var result = new List<Clients>();

            using(SqlCommand cmd = new SqlCommand("select * from clients", this.SqlConn))
            {
                result = cmd.ExecuteEntities<Clients>();
            }

            return result;
        }

        public Task<List<Clients>> GetClientsAsync()
        {
            return Task.Factory.StartNew(() => GetClients());
        }

        public Clients GetClient(int id)
        {
            var result = new Clients();

            using (SqlCommand cmd = new SqlCommand("select * from clients where [Id] = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = cmd.ExecuteEntity<Clients>();
            }

            return result;
        }

        public Task<Clients> GetClientAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClient(id));
        }

        public List<ClientScopes> GetClientScope(int id)
        {
            var result = new List<ClientScopes>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientScopes where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = cmd.ExecuteEntities<ClientScopes>();
            }

            return result;
        }

        public Task<List<ClientScopes>> GetClientScopeAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientScope(id));
        }

        public ApiScopes GetApiScopes(string scopeName)
        {
            var result = new ApiScopes();

            using (SqlCommand cmd = new SqlCommand("select * from ApiScopes where [Name] = @Name", this.SqlConn))
            {
                cmd.Parameters.Set("@Name", System.Data.SqlDbType.NVarChar, scopeName, 200);
                result = cmd.ExecuteEntity<ApiScopes>();
            }

            return result;
        }

        public Task<ApiScopes> GetApiScopesAsync(string scopeName)
        {
            return Task.Factory.StartNew(() => GetApiScopes(scopeName));
        }

        public ApiResources GetApiResources(string scopeName)
        {
            var result = new ApiResources();

            using (SqlCommand cmd = new SqlCommand("select * from ApiResources where [Name] = @Name", this.SqlConn))
            {
                cmd.Parameters.Set("@Name", System.Data.SqlDbType.NVarChar, scopeName, 200);
                result = cmd.ExecuteEntity<ApiResources>();
            }

            return result;
        }

        public Task<ApiResources> GetApiResourcesAsync(string scopeName)
        {
            return Task.Factory.StartNew(() => GetApiResources(scopeName));
        }


        public Dictionary<string,string> GetClientClaims(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientClaims where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientClaimsAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientClaims(id));
        }

        public Dictionary<string,string> GetClientCorsOrigins(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientCorsOrigins where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientCorsOriginsAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientCorsOrigins(id));
        }

        public Dictionary<string,string> GetClientGrantTypes(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientGrantTypes where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientGrantTypesAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientGrantTypes(id));
        }

        public Dictionary<string,string> GetClientIdPRestrictions(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientIdPRestrictions where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientIdPRestrictionsAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientIdPRestrictions(id));
        }

        public Dictionary<string,string> GetClientProperties(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientProperties where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientPropertiesAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientProperties(id));
        }

        public Dictionary<string,string> GetClientRedirectUris(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ClientRedirectUris where clientid = @id", this.SqlConn))
            {
                cmd.Parameters.Set("@id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetClientRedirectUrisAsync(int id)
        {
            return Task.Factory.StartNew(() => GetClientRedirectUris(id));
        }


        public Dictionary<string,string> GetApiScopeClaims(int Id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiScopeClaims where [ScopeId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, Id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiScopeClaimsAsync(int Id)
        {
            return Task.Factory.StartNew(() => GetApiScopeClaims(Id));
        }

        public Dictionary<string,string> GetApiScopeProperties(int Id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiScopeProperties where [ScopeId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, Id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiScopePropertiesAsync(int Id)
        {
            return Task.Factory.StartNew(() => GetApiScopeProperties(Id));
        }


        public Dictionary<string,string> GetApiResourceScopes(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiResourceScopes where [ApiResourceId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiResourceScopesAsync(int id)
        {
            return Task.Factory.StartNew(() => GetApiResourceScopes(id));
        }

        public Dictionary<string,string> GetApiResourceClaims(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiResourceClaims where [ApiResourceId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiResourceClaimsAsync(int id)
        {
            return Task.Factory.StartNew(() => GetApiResourceClaims(id));
        }

        public Dictionary<string,string> GetApiResourceProperties(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiResourceProperties where [ApiResourceId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiResourcePropertiesAsync(int id)
        {
            return Task.Factory.StartNew(() => GetApiResourceProperties(id));
        }

        public Dictionary<string,string> GetApiResourceSecrets(int id)
        {
            var result = new Dictionary<string, string>();

            using (SqlCommand cmd = new SqlCommand("select * from ApiResourceSecrets where [ApiResourceId] = @Id", this.SqlConn))
            {
                cmd.Parameters.Set("@Id", System.Data.SqlDbType.Int, id);
                result = TextHelper.TableToText(cmd.ExecuteTable());
            }

            return result;
        }

        public Task<Dictionary<string,string>> GetApiResourceSecretsAsync(int id)
        {
            return Task.Factory.StartNew(() => GetApiResourceSecrets(id));
        }
    }
}
