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
            //if (System.Diagnostics.Debugger.IsAttached)
            //{
            //    Settings.Default.Reset();
            //}
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