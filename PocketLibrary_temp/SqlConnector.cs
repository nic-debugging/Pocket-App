using Dapper;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace PocketLibrary_temp
{
    public class SqlConnector : IDataConnection
    {

        private string connectionString;
        public SqlConnector()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        // TODO - Make createTab actually save to database
        /// <summary>
        /// Saves a new tab to database
        /// </summary>
        /// <param name="newTab">The new tab's info</param>
        /// <returns>TODO - finish sql table, maybe return unique id or sum</returns>
        public Tab createTab(Tab newTab)
        {

            // after the { } below, connection is destroyed, so exceptions won't stop a connection
            // from closing!
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                
                var p = new DynamicParameters();
                p.Add("@title", newTab.TabTitle);
                p.Add("@link", newTab.TabLink);
                p.Add("@image", newTab.TabImage);
                p.Add("@timeInserted", newTab.TimeInserted);
                p.Add("@orderPositionUnusedValue", 69);                

                // Execute == pass in info, no info passed out
                var result = connection.Execute("editTab", p, commandType: CommandType.StoredProcedure);
                
                if (result < 0)
                {
                    Console.WriteLine($"Error executing procedure; {result}");
                }
                return newTab;
            }
        }

        /*

        public Files createFile(Files newFile)
        {

            // after the { }below, connection is destroyed, so exceptions won't stop a connection
            // from closing!
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {

                var p = new DynamicParameters();
                p.Add("@path", newFile.FilePath);
                p.Add("@name", newFile.FileName);
                p.Add("@extension", newFile.FileExtension);
                p.Add("@image", newFile.FileImage);
                p.Add("@timeInserted", newFile.TimeInserted);                
                
                var result = connection.Execute("editFile", p, commandType: CommandType.StoredProcedure);

                if (result < 0)
                {
                    Console.WriteLine($"Error executing procedure; {result}");
                }

                return newFile;
            }
        }

        */

        public Files createFile(Files newFile)
        {
            // Console.WriteLine("Connection String: " + connectionString);

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                var p = new DynamicParameters();
                p.Add("path", newFile.FilePath); // Removed @ symbol
                p.Add("name", newFile.FileName); // Removed @ symbol
                p.Add("extension", newFile.FileExtension); // Removed @ symbol
                p.Add("image", newFile.FileImage); // Removed @ symbol
                p.Add("timeInserted", newFile.TimeInserted); // Removed @ symbol

                // Console.WriteLine($"Parameters - path: {newFile.FilePath}, name: {newFile.FileName}, extension: {newFile.FileExtension}, image: {newFile.FileImage}, timeInserted: {newFile.TimeInserted}");

                try
                {
                    var result = connection.Execute("editFile", p, commandType: CommandType.StoredProcedure);

                    if (result < 0)
                    {
                        Console.WriteLine($"Error executing procedure; {result}");
                    }
                    else
                    {
                        Console.WriteLine("Procedure executed successfully.");
                    }
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine($"ArgumentException: {argEx.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    throw;
                }

                return newFile;
            }
        }


        /*
        public Tag createTag(Tag newTag)
        {
            newTag.Name = "Test Tag";

            return newTag;
        }
        */

        public List<Tab> loadTabs(string sortType)
        {
            
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnTabs = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";

                var data = connection.Query<Tab>(returnTabs);

                // Convert the IEnumerable<Tab> to a List<Tab>
                return data.ToList();
            }
        }

        public List<BothTabsFiles> ApplyFilterSort_Both(string sortType)
        {
            try
            {
                using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    connection.Open();

                    string returnData = "SELECT tabTitle, tabLink, bothImage, filePath, fileName, fileExtension, timeInserted FROM BothTabsFiles";
                    List<BothTabsFiles> data;

                    var result = connection.Execute("GetBothTabsFiles", commandType: CommandType.StoredProcedure);

                    returnData = returnData + " " + sortType;

                    data = connection.Query<BothTabsFiles>(returnData)

                    .Select(item => new BothTabsFiles(
                        item.TabTitle,
                        item.TabLink,
                        item.BothImage,
                        item.FilePath,
                        item.FileName,
                        item.FileExtension,
                        item.TimeInserted
                    ))
                    .ToList();

                    return data;
                }

            }
            catch (MySqlException ex)
            {

                // 1406 is the MySQL error code for data too long
                if (ex.Number == 1406)
                {
                    //MessageBox.Show("...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Other SQL exceptions
                }

                return new List<BothTabsFiles>();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Please report this error.");
                return new List<BothTabsFiles>();
            }

        }

        public List<PocketLibrary_temp.Tab> ApplyFilterSort_Tabs(string sortType)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnData = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";
                
                returnData = returnData + " " + sortType;

                var data = connection.Query<PocketLibrary_temp.Tab>(returnData)
                .Select(item => new PocketLibrary_temp.Tab(
                    tabTitle: item.TabTitle,
                    tabLink: item.TabLink,
                    tabImage: item.TabImage,
                    timeInserted: item.TimeInserted,
                    orderPosition: item.OrderPosition
                ))
                .ToList();

                return data.ToList();
            }
        }

        public List<Files> ApplyFilterSort_Files(string sortType)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly.GetManifestResourceNames();

                string returnData = "SELECT path as FilePath, name as FileName, extension as FileExtension, image as FileImage, timeInserted FROM file";

                returnData = returnData + " " + sortType;

                var data = connection.Query<Files>(returnData)
                .Select(item => new Files(
                    filePath: item.FilePath,
                    fileName: item.FileName,
                    fileExtension: item.FileExtension,
                    fileImage: item.FileImage,
                    timeInserted: item.TimeInserted
                ))
                .ToList();

                return data.ToList();
            }

        }

        public static void DeleteTab(DateTime TimeInserted)
        {

            string connectionString = GlobalConfig.GetConnectionString();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                string query = "DELETE FROM tab WHERE timeInserted = @TimeInserted";

                int rowsAffected = connection.Execute(query, new { TimeInserted = TimeInserted });
            }
        }

        public static void DeleteFile(DateTime TimeInserted)
        {

            string connectionString = GlobalConfig.GetConnectionString();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                string query = "DELETE FROM file WHERE timeInserted = @TimeInserted";

                int rowsAffected = connection.Execute(query, new { TimeInserted = TimeInserted });
            }
        }

        public List<PocketLibrary_temp.Tab> ApplySort_Time(string sortType)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnData = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";

                returnData = returnData + " " + sortType;

                var data = connection.Query<PocketLibrary_temp.Tab>(returnData)
                .Select(item => new PocketLibrary_temp.Tab(
                    tabTitle: item.TabTitle,
                    tabLink: item.TabLink,
                    tabImage: item.TabImage,
                    timeInserted: item.TimeInserted,
                    orderPosition: item.OrderPosition
                ))
                .ToList();

                return data.ToList();
            }
        }
    }
}
