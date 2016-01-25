using System;
using System.Windows.Forms;
using PayTracker.Properties;

namespace PayTracker
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Settings.Default.FirstStart)
            {
                Application.Run(new firstStart());
            }
            else
            {
                Application.Run(new Start());
            }
        }
    }
}