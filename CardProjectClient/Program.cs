using CardProjectClient.components;
using System.Runtime.InteropServices;

namespace CardProjectClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Consider using WPF instead of Windows Forms
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}