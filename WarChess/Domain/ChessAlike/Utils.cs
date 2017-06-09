namespace WarChess.Domain.ChessAlike
{
    public static class Utils
    {
        public const int WhitePlayerId = 0;
        public const int BlackPlayerId = 1;
        public const int PlayersCount = 2;
        public const int BoardSize = 8;

        public static int AnotherPlayerId(int playerId) => (playerId + 1) % PlayersCount;
    }
}