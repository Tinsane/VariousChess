using System;
using System.Windows.Forms;
using WarChess.UserInterface;
using WarChess.UserInterface.ChessUI;

namespace WarChess
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm(new ChessForm[] {}));
        }
    }
}