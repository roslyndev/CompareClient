namespace CompareDatabase.WindowUI
{
    public class ApiScopes
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool Required { get; set; } = false;

        public bool Emphasize { get; set; } = false;

        public bool ShowInDiscoveryDocument { get; set; } = false;

        public bool Enabled { get; set; } = false;

        public DateTime Created { get; set; } = new DateTime();

        public DateTime LastAccessed { get; set; } = new DateTime();

        public bool NonEditable { get; set; } = false;

        public DateTime Updated { get; set; } = new DateTime();

        public ApiScopes()
        {
        }

    }


}
