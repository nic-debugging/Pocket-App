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
            ApplicationConfiguration.Initialize();

            //Initialize database connections
            PocketLibrary_temp.GlobalConfig.InitializeConnections();
            //PocketLibrary_temp.GlobalConfig.GetConnectionString();

            // app first opens this main home screen 
            Application.Run(new PocketInterface());
        }
    }
}
