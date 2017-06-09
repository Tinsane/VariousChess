using NUnit.Framework;
using WarChess.Domain.Chess;
using WarChess.Domain.Chess.GameStateProvider;
using WarChess.Domain.ChessAlikeApi;

namespace ChessGameUnitTests
{
    [TestFixture]
    public class ChessUnitTests
    {
        private static object[] chessPositionCases =
        {
            new object[] {"e2", new ChessPosition(1, 4)},
            new object[] {"a8", new ChessPosition(7, 0)},
            new object[] {"h1", new ChessPosition(0, 7)}
        };

        [Test]
        [TestCaseSource(nameof(chessPositionCases))]
        public void TestChessPosition(string repr, ChessPosition expected)
        {
            var actual = repr.GetChessPosition();
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }
    }

    [TestFixture]
    public class ChessGameUnitTests
    {
        [SetUp]
        protected void SetUp()
        {
            GameStateProvider = new ChessGameStateProvider(new QueenPawnTransformer());
        }

        private static object[] correctMoveCases =
        {
            new object[]
            {
                new ChessGame(new ChessGameStateProvider(new QueenPawnTransformer())),
                new ChessPosition(1, 4),
                new ChessPosition(2, 4)
            },
            new object[]
            {
                new ChessGame(new ChessGameStateProvider(new QueenPawnTransformer())),
                new ChessPosition(1, 4),
                new ChessPosition(3, 4)
            },
            new object[]
            {
                new ChessGame(new ChessGameStateProvider(new QueenPawnTransformer())),
                new ChessPosition(0, 1),
                new ChessPosition(2, 2)
            }
        };

        private ChessGameStateProvider GameStateProvider { get; set; }

        [Test]
        public void TestCheckRook()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "........",
                "........",
                "........",
                "........",
                "........",
                "K......r",
                ".......k"
            }));
            Assert.IsTrue(game.IsCheck);
        }

        [Test]
        public void TestNonCheckRook()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "........",
                "........",
                "........",
                "........",
                "........",
                "K..b...r",
                ".......k"
            }));
            Assert.IsFalse(game.IsCheck);
        }

        [Test]
        [TestCaseSource(nameof(correctMoveCases))]
        public void TestCorrectMove(ChessGame game, ChessPosition from, ChessPosition to)
        {
            Assert.IsTrue(game.TryMakeMove(from, to));
        }
    }
}