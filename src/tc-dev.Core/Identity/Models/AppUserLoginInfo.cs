namespace tc_dev.Core.Identity.Models
{
    public sealed class AppUserLoginInfo
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public AppUserLoginInfo(string loginProvider, string providerKey) {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }
    }
}
