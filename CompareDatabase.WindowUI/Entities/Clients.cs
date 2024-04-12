namespace CompareDatabase.WindowUI
{
    public class Clients
    {
        public int Id { get; set; } = 0;

        public bool Enabled { get; set; } = false;

        public string ClientId { get; set; } = string.Empty;

        public string ProtocolType { get; set; } = string.Empty;

        public bool RequireClientSecret { get; set; } = false;

        public string ClientName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ClientUri { get; set; } = string.Empty;

        public string LogoUri { get; set; } = string.Empty;

        public bool RequireConsent { get; set; } = false;

        public bool AllowRememberConsent { get; set; } = false;

        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;

        public bool RequirePkce { get; set; } = false;

        public bool AllowPlainTextPkce { get; set; } = false;

        public bool AllowAccessTokensViaBrowser { get; set; } = false;

        public string FrontChannelLogoutUri { get; set; } = string.Empty;

        public bool FrontChannelLogoutSessionRequired { get; set; } = false;

        public string BackChannelLogoutUri { get; set; } = string.Empty;

        public bool BackChannelLogoutSessionRequired { get; set; } = false;

        public bool AllowOfflineAccess { get; set; } = false;

        public int IdentityTokenLifetime { get; set; } = 0;

        public int AccessTokenLifetime { get; set; } = 0;

        public int AuthorizationCodeLifetime { get; set; } = 0;

        public int ConsentLifetime { get; set; } = 0;

        public int AbsoluteRefreshTokenLifetime { get; set; } = 0;

        public int SlidingRefreshTokenLifetime { get; set; } = 0;

        public int RefreshTokenUsage { get; set; } = 0;

        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } = false;

        public int RefreshTokenExpiration { get; set; } = 0;

        public int AccessTokenType { get; set; } = 0;

        public bool EnableLocalLogin { get; set; } = false;

        public bool IncludeJwtId { get; set; } = false;

        public bool AlwaysSendClientClaims { get; set; } = false;

        public string ClientClaimsPrefix { get; set; } = string.Empty;

        public string PairWiseSubjectSalt { get; set; } = string.Empty;

        public DateTime Created { get; set; } = new DateTime();

        public DateTime Updated { get; set; } = new DateTime();

        public DateTime LastAccessed { get; set; } = new DateTime();

        public int UserSsoLifetime { get; set; } = 0;

        public string UserCodeType { get; set; } = string.Empty;

        public int DeviceCodeLifetime { get; set; } = 0;

        public bool NonEditable { get; set; } = false;

        public string AllowedIdentityTokenSigningAlgorithms { get; set; } = string.Empty;

        public bool RequireRequestObject { get; set; } = false;

        public int CibaLifetime { get; set; } = 0;

        public int PollingInterval { get; set; } = 0;

        public bool CoordinateLifetimeWithUserSession { get; set; } = false;

        public DateTime DPoPClockSkew { get; set; } = new DateTime();

        public int DPoPValidationMode { get; set; } = 0;

        public string InitiateLoginUri { get; set; } = string.Empty;

        public int PushedAuthorizationLifetime { get; set; } = 0;

        public bool RequireDPoP { get; set; } = false;

        public bool RequirePushedAuthorization { get; set; } = false;

        public Clients()
        {
        }

    }


}
