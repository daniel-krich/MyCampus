namespace MyCampusUI.Consts
{
    public static class CookiesConst
    {
        public const string AccessCookie = "Campus-Authentication-Token";
        public const string SecretTokenKey = "2L6ToZXboA6Qnk9pgBoFVOL4ovZEBWENJuAkpb0fADjanyZxvMzhMjSMeMVdxoAm";
        public const string IssuerAndAudience = "my-campus";
        public static TimeSpan AccessCookieExpireTemp = TimeSpan.FromHours(6);
        public static TimeSpan AccessCookieExpire = TimeSpan.FromDays(14);
    }
}
