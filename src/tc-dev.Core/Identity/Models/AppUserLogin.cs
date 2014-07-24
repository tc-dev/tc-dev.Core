namespace tc_dev.Core.Identity.Models
{
    public class AppUserLogin
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual int UserId { get; set; }
    }
}
