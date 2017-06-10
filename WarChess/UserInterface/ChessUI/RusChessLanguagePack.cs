using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarChess.Domain.Chess;

namespace WarChess.UserInterface.ChessUI
{
    class RusChessLanguagePack : IChessLanguagePack
    {
        public string GameName => "Шахматы";

        public string Language => "rus";

        public string MessageCheck => "Шах";

        public string MessageMate => "Мат";

        public string MessageStaleMate => "Пат";


    }
}
