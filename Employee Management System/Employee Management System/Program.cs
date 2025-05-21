using System;
using System.Windows.Forms;
using EmployeeManagementSystem;

namespace CA_03
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
            Application.Run(new Form1()); // Ensure Form1 is in the CA_03 namespace
        }
    }
}