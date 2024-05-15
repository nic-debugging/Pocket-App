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
//using System.Windows.Forms;
using System.Reflection;


//IN title VARCHAR(100),
//IN link VARCHAR(200),
//IN image BLOB,
//IN timeInserted TIMESTAMP,
//OUT orderPosition int,

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

            //connectionString = configuration.GetConnectionString("ConnectionString");
            
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
                //p.Add("@orderPosition", 69, dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.Add("@orderPosition", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@orderPositionUnusedValue", 69);
                //p.Add("@orderPosition", 69);
                
                
                /*
                var p = new DynamicParameters();
                p.Add("@TabTitle", newTab.TabTitle);
                p.Add("@TabLink", newTab.TabLink);
                p.Add("@TabImage", newTab.TabImage);
                p.Add("@TimeInserted", newTab.TimeInserted);
                p.Add("@OrderPosition", 69); // I assume you don't need this parameter in the stored procedure
                */
                
                /*
                try
                {
                    var result = connection.Execute("editTab", p, commandType: CommandType.StoredProcedure);
                    if (result < 0)
                    {
                        Console.WriteLine($"Error executing stored procedure. Result: {result}");
                    }

                    newTab.OrderPosition = p.Get<int>("@orderPosition");
                    Console.WriteLine($"Order Position: {newTab.OrderPosition}");
                }
                catch (Exception ex)
                {
                    // Handle the exception, print, log, or debug as needed
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                */

                

                // Execute == pass in info, no info passed out
                var result = connection.Execute("editTab", p, commandType: CommandType.StoredProcedure);
                
                ///
                if (result < 0)
                {
                    // There might be an error, print or log the result
                    Console.WriteLine($"Error executing stored procedure. Result: {result}");
                }
                ///

                //newTab.OrderPosition = p.Get<int>("@orderPosition");

                ///
                //Console.WriteLine($"Order Position: {newTab.OrderPosition}");
                ///
                

                return newTab;


                // var result = connection.Query<Tab>("editTab", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

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
                //p.Add("@orderPositionUnusedValue", 69);
                
                
                //var result = connection.Execute("editFile, commandType: CommandType.StoredProcedure");
                var result = connection.Execute("editFile", p, commandType: CommandType.StoredProcedure);
                
                
                
                ///
                if (result < 0)
                {
                    // There might be an error, print or log the result
                    Console.WriteLine($"Error executing stored procedure. Result: {result}");
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
            /*
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnTabs = "SELECT * FROM tab";
                string returnSorted = returnTabs + " " + sortType;
                
                // Select the data from the tab table
                var data = connection.Query<Tab>(returnSorted);


                // Convert the IEnumerable<Tab> to a List<Tab>
                return data.ToList();
            }
            */


            
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                //string returnTabs = "SELECT * FROM tab";
                string returnTabs = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";
                //string returnSorted = returnTabs + " " + sortType;

                // Use SplitOn method to split columns based on the delimiter ','
                //var data = SqlMapper.Query<Tab>(connection, returnSorted, commandType: CommandType.Text, splitOn: "TabTitle,TabLink,TabImage,TimeInserted,OrderPosition").ToList();
                //var data = connection.Query<Tab>(returnSorted);
                var data = connection.Query<Tab>(returnTabs);



                // Convert the IEnumerable<Tab> to a List<Tab>
                return data.ToList();
            }
        }
        
        /*

        // called from 'Apply' button.
        public List<LibraryItem> ApplyFilterSort(string sortType, bool filterTab, bool filterFile)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnData = "";
                string returnTabs = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";
                string returnFiles = "SELECT path as FilePath, name as FileName, extension as FileExtension, image as FileImage, timeInserted, orderPosition FROM file";
                //string returnBoth = "SELECT tabTitle, tabLink, bothImage, filePath, fileName, fileExtension, timeInserted FROM libraryItem";
                string returnBoth = "SELECT tabTitle, tabLink, bothImage, filePath, fileName, fileExtension, timeInserted FROM libraryItem";


                List<LibraryItem> data;


                //var data = 6969;

                // if (sortType != null) 
                //returnTabs = returnTabs + " " + sortType;
                //returnFiles = returnFiles + " " + sortType;
                //returnBoth = returnBoth 

                if (filterTab == true && filterFile == true)
                {
                    returnData = returnBoth;


                    // create libraryItem table that merges both tabs and files together first
                    // before retrieving data from this table afterwards

                    //var result = connection.Execute("GetBothTabsFiles", p, commandType: CommandType.StoredProcedure);
                    //var result = connection.Execute("GetBothTabsFiles, commandType: CommandType.StoredProcedure");
                    var result = connection.Execute("GetBothTabsFiles", commandType: CommandType.StoredProcedure);

                    sortType = "ORDER BY timeInserted DESC";



                    Console.WriteLine("THIS SUPPOSED TO SHOW");

                    data = connection.Query<BothTabsFiles>(returnData).Cast<LibraryItem>().ToList();

                    return data.Cast<LibraryItem>().ToList();

                }
                else if (filterTab == true)
                { 
                    returnData = returnTabs;

                    //if (filterFile == true)
                    //{
                    //    returnData = returnData + " UNION " + returnFiles;
                    //}

                    var data = connection.Query<Tab>(returnData);

                }
                else if (filterFile)
                {
                    returnData = returnFiles;

                    var data = connection.Query<Files>(returnData);

                    return data.ToList();
                }
                else
                {
                    //return null;
                    return new List<LibraryItem>();
                }

                returnData = returnData + " " + sortType;

                // Use SplitOn method to split columns based on the delimiter ','
                //var data = SqlMapper.Query<Tab>(connection, returnSorted, commandType: CommandType.Text, splitOn: "TabTitle,TabLink,TabImage,TimeInserted,OrderPosition").ToList();
                
                //var data = connection.Query<Tab>(returnData);
                //var data = connection.Query<LibraryItem>(returnData);

                //var data = connection.Query<BothTabsFiles, Tab, Files, LibraryItem>(returnData);


                // Convert the IEnumerable<Tab> to a List<Tab>

                //return null;
                return data.Cast<LibraryItem>().ToList();

            }
        }
        */

        /*
        public List<LibraryItem> ApplyFilterSort(string sortType, bool filterTab, bool filterFile)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                string returnData = "";
                string returnTabs = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";
                //string returnFiles = "SELECT path as FilePath, name as FileName, extension as FileExtension, image as FileImage, timeInserted, orderPosition FROM file";
                string returnFiles = "SELECT path as FilePath, name as FileName, extension as FileExtension, image as FileImage, timeInserted FROM file";
                //string returnBoth = "SELECT tabTitle, tabLink, bothImage, filePath, fileName, fileExtension, timeInserted FROM libraryItem";
                string returnBoth = "SELECT tabTitle, tabLink, bothImage, filePath, fileName, fileExtension, timeInserted FROM BothTabsFiles";

                List<LibraryItem> data;  // Declare data outside of the if blocks

                if (filterTab == true && filterFile == true)
                {
                    var result = connection.Execute("GetBothTabsFiles", commandType: CommandType.StoredProcedure);

                    returnData = returnBoth;
                    //sortType = "ORDER BY timeInserted DESC";
                    //sortType += " DESC";

                    returnData = returnData + " " + sortType;

                    //data = connection.Query<BothTabsFiles>(returnData).Cast<LibraryItem>().ToList();
                    data = connection.Query<BothTabsFiles>(returnData)
                 //.Select(item => new PocketLibrary_temp.BothTabsFiles
                 .Select(item => new LibraryItem(new BothTabsFiles
                 {
                     tabTitle = item.tabTitle,
                     tabLink = item.tabLink,
                     bothImage = item.bothImage,
                     filePath = item.filePath,
                     fileName = item.fileName,
                     fileExtension = item.fileExtension,
                     timeInserted = item.timeInserted
                 }))
                 .ToList();


                    Console.WriteLine("THIS SUPPOSED TO SHOW");
                    
                }
                else if (filterTab == true)
                {
                    returnData = returnTabs;
                    returnData = returnData + " " + sortType;

                    data = connection.Query<Tab>(returnData).Cast<LibraryItem>().ToList();
                }
                else if (filterFile)
                {
                    returnData = returnFiles;
                    returnData = returnData + " " + sortType;
                    
                    data = connection.Query<Files>(returnData).Cast<LibraryItem>().ToList();
                }
                else
                {
                    data = new List<LibraryItem>();
                    return data;  // Return here to avoid using uninitialized variable
                }

                
                return data;  // Return data at the end of the method
            }
        }
        */

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


                    //sortType = "ORDER BY timeInserted DESC";
                    //sortType += " DESC";

                    returnData = returnData + " " + sortType;

                    //data = connection.Query<BothTabsFiles>(returnData).Cast<LibraryItem>().ToList();
                    data = connection.Query<BothTabsFiles>(returnData)
                    //.Select(item => new PocketLibrary_temp.BothTabsFiles

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


                    /*
                     .Select(item => new BothTabsFiles
                     {
                         tabTitle = item.tabTitle,
                         tabLink = item.tabLink,
                         bothImage = item.bothImage,
                         filePath = item.filePath,
                         fileName = item.fileName,
                         fileExtension = item.fileExtension,
                         timeInserted = item.timeInserted
                     })
                     .ToList();
                    */

                    return data;
                }

            }
            catch (MySqlException ex)
            {
                //if (ex.Message.Contains("Data too long"))

                // 1406 is the MySQL error code for data too long
                if (ex.Number == 1406)
                {
                    //MessageBox.Show("No URL entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // Handle the specific error related to exceeding the maximum length
                    // Log the error, notify the user, or take appropriate action
                }
                else
                {
                    // Handle other types of MySQL exceptions
                }

                // Optionally, rethrow the exception if you want it to propagate further
                // throw;

                // Return a default or empty result, depending on your needs
                return new List<BothTabsFiles>();
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions

                // Optionally, rethrow the exception if you want it to propagate further
                // throw;

                // Return a default or empty result, depending on your needs
                return new List<BothTabsFiles>();
            }

        }

        public List<PocketLibrary_temp.Tab> ApplyFilterSort_Tabs(string sortType)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                //string returnTabs = "SELECT * FROM tab";
                string returnData = "SELECT title as TabTitle, link as TabLink, image as TabImage, timeInserted, orderPosition FROM tab";
                
                returnData = returnData + " " + sortType;

                /*
                var data = connection.Query<PocketLibrary_temp.Tab>(returnData)                 
                 .Select(item => new PocketLibrary_temp.Tab
                 {
                     TabTitle = item.TabTitle,
                     TabLink = item.TabLink,
                     TabImage = item.TabImage, 
                     TimeInserted = item.TimeInserted,
                     OrderPosition = item.OrderPosition


                 })
                 .ToList();
                */

                var data = connection.Query<PocketLibrary_temp.Tab>(returnData)
                .Select(item => new PocketLibrary_temp.Tab(
                    tabTitle: item.TabTitle,
                    tabLink: item.TabLink,
                    tabImage: item.TabImage,
                    timeInserted: item.TimeInserted,
                    orderPosition: item.OrderPosition
                ))
                .ToList();



                // Convert the IEnumerable<Tab> to a List<Tab>
                return data.ToList();
            }
        }

        public List<Files> ApplyFilterSort_Files(string sortType)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                connection.Open();

                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                var assembly = Assembly.GetExecutingAssembly();
                var resourceNames = assembly.GetManifestResourceNames();

                Console.WriteLine("FUCK33333");


                // Print out each resource name for debugging
                foreach (var resourceName in resourceNames)
                {
                    Console.WriteLine("FUCK");

                    Console.WriteLine(resourceName);
                }
                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
                //FUCKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK

                //string returnTabs = "SELECT * FROM tab";
                string returnData = "SELECT path as FilePath, name as FileName, extension as FileExtension, image as FileImage, timeInserted FROM file";

                returnData = returnData + " " + sortType;

                /*
                var data = connection.Query<PocketLibrary_temp.Tab>(returnData)                 
                 .Select(item => new PocketLibrary_temp.Tab
                 {
                     TabTitle = item.TabTitle,
                     TabLink = item.TabLink,
                     TabImage = item.TabImage, 
                     TimeInserted = item.TimeInserted,
                     OrderPosition = item.OrderPosition


                 })
                 .ToList();
                */

                var data = connection.Query<Files>(returnData)
                .Select(item => new Files(
                    filePath: item.FilePath,
                    fileName: item.FileName,
                    fileExtension: item.FileExtension,
                    fileImage: item.FileImage,
                    timeInserted: item.TimeInserted
                ))
                .ToList();

                //string defaultImageFileName = "defaultFileIcon3.jpg";
                //string defaultImagePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), defaultImageFileName);

                foreach (var file in data)
                {
                    // if no image is present, set to default file icon
                    if (file.FileImage == null)
                    {
                        ////////////NEW SHITTTTTTTTTTTTTTTTTTTTTT
                        ////////////NEW SHITTTTTTTTTTTTTTTTTTTTTT
                        //string defaultImageName = "PocketLibrary_temp.Resources.folderImage.png";
                        //byte[] defaultImageData;
//
                        //using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(defaultImageName))
                        //{
                        //
                        //    using (MemoryStream memoryStream = new MemoryStream())
                        //    {
                        //        stream.CopyTo(memoryStream);
                        //        defaultImageData = memoryStream.ToArray();
                        //    }
                        //
                        //}
                        //file.FileImage = defaultImageData;
                        ////////////NEW SHITTTTTTTTTTTTTTTTTTTTTT
                        ////////////NEW SHITTTTTTTTTTTTTTTTTTTTTT


                        ////////////OLDDDDDDDDDDDDDDDDDDDDDD SHIT
                        //string defaultImagePath = "PocketLibrary_temp.Resources.fileImage.png";
                        //file.FileImage = File.ReadAllBytes(defaultImagePath);
                        ////////////OLDDDDDDDDDDDDDDDDDDDDDD SHIT




                        //byte[] defaultFileIcon = FileIconGenerator.GetDefaultFileIcon();
                        //file.FileImage = defaultFileIcon;

                    }
                }
                
                

                // Convert the IEnumerable<Tab> to a List<Tab>
                return data.ToList();
            }

        }

        //public static void DeleteTab(DateTime TimeInserted)
        public static void DeleteTab(DateTime TimeInserted)

        {
            // Implement your SQL query to delete the tab from the database
            // Example:
            // string query = $"DELETE FROM Tabs WHERE TabTitle = '{tabTitle}'";

            // Execute the query using your database connection
            // Example:
            // SqlConnection connection = new SqlConnection(connectionString);
            // SqlCommand command = new SqlCommand(query, connection);
            // connection.Open();
            // command.ExecuteNonQuery();
            // connection.Close();

            // Don't forget error handling and proper disposal of resources



            //string connectionString = GlobalConfig.Connection.ConnectionString;
            string connectionString = GlobalConfig.GetConnectionString();


            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                // Construct the SQL query to delete the tab with the given title
                
                //string query = "DELETE FROM YourTabTable WHERE timeInserted = @TimeInserted";
                
                // NEW SHITTTT
                string query = "DELETE FROM tab WHERE timeInserted = @TimeInserted";

                // Use Dapper's Execute method to execute the SQL query
                int rowsAffected = connection.Execute(query, new { TimeInserted = TimeInserted });

                /*
                // Check if deletion was successful
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Successfully deleted tab: {tabTitle}");
                }
                else
                {
                    Console.WriteLine($"Failed to delete tab: {tabTitle}");
                }
                */
            }
        }


        public static int DeleteFile(DateTime TimeInserted)
        {

            string connectionString = GlobalConfig.GetConnectionString();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                string query = "DELETE FROM file WHERE timeInserted = @TimeInserted";

                int rowsAffected = connection.Execute(query, new { TimeInserted = TimeInserted });


                //System.Diagnostics.Debug.WriteLine("FUCKKKKKKKKKKKKKKKKK");
                //System.Diagnostics.Debug.WriteLine(TimeInserted);


                return rowsAffected;
            }
        }


    }
}