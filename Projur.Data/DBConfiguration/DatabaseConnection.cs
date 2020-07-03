using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Projur.Data.DBConfiguration
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                string diretorioPai = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                string path = Path.Combine(diretorioPai, "Projur.Data");   

                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();
                    
                return Configuration;
            }
        }
    }
}