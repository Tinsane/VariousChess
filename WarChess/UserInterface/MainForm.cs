using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarChess.Infrastructure;

namespace WarChess.UserInterface
{
    public class MainForm : Form
    {
        public const string StartGameText = "Начать игру!";

        private readonly ComboBox comboBox;
        private readonly Func<IGameForm[]> formsSupplier;
        private IGameForm[] currentForms;
        
        public MainForm(Func<IGameForm[]> formsSupplier)
        {
            this.formsSupplier = formsSupplier;
            comboBox = new ComboBox()
            {
                Anchor = AnchorStyles.Top,
                Dock = DockStyle.Top
            };
            currentForms = formsSupplier();
            foreach (IGameForm form in currentForms)
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
                currentForms[comboBox.SelectedIndex].Run(this);
            currentForms = formsSupplier();
        }
    }
}
