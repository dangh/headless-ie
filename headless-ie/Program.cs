using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace headless_ie
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string url = "";
            if (args.Length > 0)
            {
                url = args[0];
            }
            Application.Run(new frmMain(url));
        }
    }
}
