using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarChess.UserInterface
{
    public static class FormUtils
    {
        public static void SwitchTo(this Form from, Form to)
        {
            from.Hide();
            to.FormClosed += (sender, args) => from.Show();
            to.Show();
        }
    }
}
