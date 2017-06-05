using System;
using System.Windows.Forms;

namespace WarChess
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}