using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    static class Program
    {
        public static string conStr = @"Data Source=DESKTOP-U3DA8K5\KOICHEN;Initial Catalog=QLTTN;Integrated Security=True";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            Application.Run(new frmHocSinh());
            }
    }
}
