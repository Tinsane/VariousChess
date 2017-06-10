using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarChess.UserInterface.WarChessUI
{
    class RusWarChessLanguagePack : IWarChessLanguagePack
    {
        public string MessagePawnCanAttack => "Пешка может рубить";

        public string GameName => "Военные шахматы";

        public string Language => "rus";

        public string MessageCheck => "Шах";

        public string MessageMate => "Мат";

        public string MessageStaleMate => "Пат";

        public string StartTurn => "Начать ход";
    }
}
