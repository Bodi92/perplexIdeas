using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace IdeasAPI
{
    internal class DatabaseConnection
    {
        private string sqlConnectionString;
        public string SqlConnectionString { get { return sqlConnectionString; } private set { sqlConnectionString = value; } }
        public DatabaseConnection()
        {
            var configBulider = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBulider.AddJsonFile(path);
            var root = configBulider.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }
    }
}
