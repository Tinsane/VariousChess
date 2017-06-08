using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarChess.UserInterface
{
    public class MainForm : Form
    {
        public const string StartGameText = "Начать игру!";

        private readonly ComboBox comboBox;
        private readonly IGameForm[] forms;
        
        public MainForm(IGameForm[] forms)
        {
            this.forms = forms;
            comboBox = new ComboBox()
            {
                Anchor = AnchorStyles.Top,
                Dock = DockStyle.Top
            };
            foreach (IGameForm form in forms)
                comboBox.Items.Add(form.GameName);
            var startGameButton = new Button
            {
                Text = StartGameText,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                Anchor = AnchorStyles.Bottom,
                Dock = DockStyle.Bottom
            };
            startGameButton.Click += (sender, args) => RunSelectedGame();
            Controls.Add(comboBox);
            Controls.Add(startGameButton);
            Show();
        }

        public void RunSelectedGame()
        {
            if (comboBox.SelectedIndex != -1)
                forms[comboBox.SelectedIndex].Run(this);
        }
    }
}
