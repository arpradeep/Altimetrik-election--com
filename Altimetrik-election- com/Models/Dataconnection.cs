namespace Altimetrik_election__com.Models
{
    public class Dataconnection
    {
       
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public string Connecctions()
               
        {
            var configuation = GetConfiguration();
            return configuation.GetSection("ConnectionStrings").GetSection("DBconnection").Value;

        }

    }
}
