namespace ArtArea.Web.Services.Auth
{
    public class JwtBearerSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }
}