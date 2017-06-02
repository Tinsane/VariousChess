using System;

namespace WarChess.Domain.AbstractChess
{
    public class Position
    {
        public int x, y;

        public Position(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        //TODO: Делай внутреннюю индексацию как хочешь.
        //TODO: Я хочу, чтобы я мог корректно получать позицию по шахматной нотации и наоборот.
        //TODO: Под шахматной нотацией я подразумеваю запись в стиле 'e2'
        public Position(string chessNotation)
        {
            throw new NotImplementedException();
        }
        
        public string ToChessNotation()
        {
            throw new NotImplementedException();
        }
    }
}
