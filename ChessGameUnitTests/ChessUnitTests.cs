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

        private ChessGameStateProvider GameStateProvider { get; set; }

        [Test]
        public void TestCorrectBishopMove1()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                ".B......",
                "........",
                "........",
                "........",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(0, 1), new ChessPosition(3, 4)));
        }

        [Test]
        public void TestCorrectBishopMove2()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "...B....",
                "........",
                "........",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 3), new ChessPosition(4, 0)));
        }

        [Test]
        public void TestIncorrectBishopMove()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                ".B......",
                "........",
                "........",
                "........",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsFalse(game.TryMakeMove(new ChessPosition(0, 1), new ChessPosition(0, 4)));
        }

        [Test]
        public void TestCorrectRookMove1()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                ".....R..",
                "........",
                "........",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 5), new ChessPosition(6, 5)));
        }

        [Test]
        public void TestCorrectRookMove2()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                ".....R..",
                "........",
                "........",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 5), new ChessPosition(1, 2)));
        }

        [Test]
        public void TestCorrectKnightMove1()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "........",
                "........",
                "....N...",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(3, 4), new ChessPosition(1, 5)));
        }

        [Test]
        public void TestCorrectKnightMove2()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "........",
                "........",
                "....N...",
                "........",
                "........",
                "K.......",
                ".......k"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(3, 4), new ChessPosition(5, 3)));
        }

        [Test]
        public void TestDoubleMove()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "...P....",
                "........",
                "....p..k",
                "........",
                "........",
                "K.......",
                "........"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 3), new ChessPosition(3, 3)));
        }

        [Test]
        public void TestEnPassat()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "...P....",
                "........",
                "....p..k",
                "........",
                "........",
                "K.......",
                "........"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 3), new ChessPosition(3, 3)));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(3, 4), new ChessPosition(2, 3)));
        }

        [Test]
        public void TestCastling()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "R...K...",
                "...P....",
                "........",
                "....p..k",
                "........",
                "........",
                "........",
                "........"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(0, 4), new ChessPosition(0, 2)));
        }


        [Test]
        public void TestCheck()
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
        public void TestNonCheck()
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
        public void TestNonMoveToCheck()
        {
            var game = new ChessGame(GameStateProvider.FromRepr(new[]
            {
                "........",
                "...P....",
                "........",
                "R...p..k",
                "........",
                "........",
                "K.......",
                "........"
            }));
            Assert.IsTrue(game.TryMakeMove(new ChessPosition(1, 3), new ChessPosition(3, 3)));
            Assert.IsFalse(game.TryMakeMove(new ChessPosition(3, 4), new ChessPosition(2, 3)));
        }
    }
}