/*********************************************************************************************
 * The entry point. It has only one class interface method which closes the application.
*********************************************************************************************/

namespace ReaderX
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
            Application.Run(new MainForm());
        }


        public static void Exit() => Application.Exit();
    }
}