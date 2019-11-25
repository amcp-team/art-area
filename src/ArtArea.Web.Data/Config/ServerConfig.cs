namespace ArtArea.Web.Data.Config
{
    public class ServerConfig
    {
        public ApplicationDbConfig MongoDb { get; set; } = new ApplicationDbConfig();
    }
}