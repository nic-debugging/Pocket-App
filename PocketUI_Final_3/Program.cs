using PocketUI_Final_3;

namespace PocketUI_Final_3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Initialize database connections

            PocketLibrary_temp.GlobalConfig.InitializeConnections();
            //PocketLibrary_temp.GlobalConfig.GetConnectionString();

            // can't put PocketLibrary, after i renamed the project...


            // app first opens this main home screen 
            Application.Run(new PocketInterface());
        }
    }
}