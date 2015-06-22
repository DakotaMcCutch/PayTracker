using System;
using System.Windows.Forms;

namespace PayTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.FirstStart == true)
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