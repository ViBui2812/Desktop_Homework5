using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Desktop_Homework5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Bai2());
            //Application.Run(new Bai3());
            //Application.Run(new Bai4());
            //Application.Run(new Bai5());
            //Application.Run(new Bai6());
            //Application.Run(new Bai7());
            Application.Run(new Bai8());
            //Application.Run(new Bai9());

        }
    }
}
