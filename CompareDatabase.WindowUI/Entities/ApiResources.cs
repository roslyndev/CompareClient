namespace CompareDatabase.WindowUI
{
    public class ApiResources
    {
        public int Id { get; set; } = 0;

        public bool Enabled { get; set; } = false;

        public string Name { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Created { get; set; } = new DateTime();

        public DateTime Updated { get; set; } = new DateTime();

        public DateTime LastAccessed { get; set; } = new DateTime();

        public bool NonEditable { get; set; } = false;

        public string AllowedAccessTokenSigningAlgorithms { get; set; } = string.Empty;

        public bool ShowInDiscoveryDocument { get; set; } = false;

        public bool RequireResourceIndicator { get; set; } = false;

        public ApiResources()
        {
        }

    }


}
