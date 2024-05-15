using System;
using System.Collections.Generic;
//using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PocketLibrary_temp
{
    public static class GlobalConfig
    {
        // Store the IDataConnection instance
        public static IDataConnection Connection { get; private set; }
        private static IConfiguration configuration;
        
        static GlobalConfig()
        {
            //var configuration = new ConfigurationBuilder()
            configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Initialize the SQL connector directly
            Connection = new SqlConnector();


            // NEW SHITTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
            //string connectionString = configuration.GetConnectionString("DefaultConnection");

            //SqlConnector.DeleteTab(connectionString, DateTime.Now);
        }

        public static void InitializeConnections()
        {
            // Read connection string from appsettings.json
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Initialize connection using the retrieved connection string
            // Example: Connection = new SqlConnection(connectionString);

            // You can initialize other connections or settings here if needed
        }
        
        public static string GetConnectionString()
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            return connectionString;
        }
    }
}

