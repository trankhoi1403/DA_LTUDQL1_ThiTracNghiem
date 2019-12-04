using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new frmLogin());
            Application.Run(new frmHocSinh());
            }
=======
            Application.Run(new frmGiaoVien());
        }
>>>>>>> ed8c6854f4c516fbb50069e68190b271d71dbb27
    }
}
