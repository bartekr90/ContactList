using System;
using System.IO;
using System.Windows.Forms;

namespace ContactList
{
    static class Program
    {
        public static string _FilePath = "";
        public static string _DataFolder = "";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FileSet();
            Application.Run(new MainWindow());
        }
        static void FileSet()
        {
            string dir =
             Path.Combine(Environment.CurrentDirectory, "data");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            _FilePath =
                Path.Combine(Environment.CurrentDirectory, "data", "contacts.txt");
            _DataFolder = dir;
        }
    }
}
