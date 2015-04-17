using System.Linq;
using DominionTDD.Cards;
using DominionTDD.State;
using NSubstitute;
using NUnit.Framework;

namespace DominionTDD.Tests
{
    [TestFixture]
    public class GameCreationTests
    {
        private GameCreator _gameCreator;
        private IKingdomState _kingdomState;
        private IPlayerStateFactory _playerStateFactory;
        private IPlayerState _playerState1;
        private IPlayerState _playerState2;
        private IPlayerState _playerState3;
        private IPlayerState _playerState4;

        [SetUp]
        public void SetUp()
        {
            _kingdomState = Substitute.For<IKingdomState>();
            _playerStateFactory = Substitute.For<IPlayerStateFactory>();
            _playerState1 = Substitute.For<IPlayerState>();
            _playerState2 = Substitute.For<IPlayerState>();
            _playerState3 = Substitute.For<IPlayerState>();
            _playerState4 = Substitute.For<IPlayerState>();
            _playerStateFactory.CreatePlayerState(Arg.Any<IPlayer>())
                .Returns(
                    _playerState1,
                    _playerState2,
                    _playerState3,
                    _playerState4);
            _gameCreator = new GameCreator(_kingdomState, _playerStateFactory);
        }

        [Test]
        [TestCase(0, TestName = "No players")]
        [TestCase(1, TestName = "One player")]
        [TestCase(5, TestName = "Five players")]
        [TestCase(10, TestName = "Ten players")]
        public void ThrowsExceptionWhenTryingToStartAGameWith(int playerCount)
        {
            // ARRANGE
            AddPlayers(playerCount);

            // ACT, ASSERT
            Assert.Throws<IncorrectNumberOfPlayersException>(() => _gameCreator.CreateGame());
        }

        [Test]
        [TestCase(2, TestName = "Two players")]
        [TestCase(3, TestName = "Three players")]
        [TestCase(4, TestName = "Four players")]
        public void CanStartAGameWith(int playerCount)
        {
            // ARRANGE
            AddPlayers(playerCount);

            // ACT, ASSERT
            Assert.DoesNotThrow(() => _gameCreator.CreateGame());
        }

        [Test]
        public void With2PlayersThereAre8OfEachVictoryCard()
        {
            // ARRANGE
            AddPlayers(2);

            // ACT
            _gameCreator.CreateGame();

            // ASSERT
            _kingdomState.Received(1).AddPile<Estate>(8);
            _kingdomState.Received(1).AddPile<Duchy>(8);
            _kingdomState.Received(1).AddPile<Province>(8);
        }

        [Test]
        public void With3PlayersThereAre12OfEachVictoryCard()
        {
            // ARRANGE
            AddPlayers(3);

            // ACT
            _gameCreator.CreateGame();

            // ASSERT
            _kingdomState.Received(1).AddPile<Estate>(12);
            _kingdomState.Received(1).AddPile<Duchy>(12);
            _kingdomState.Received(1).AddPile<Province>(12);
        }

        [Test]
        public void With4PlayersThereAre12OfEachVictoryCard()
        {
            // ARRANGE
            AddPlayers(4);

            // ACT
            _gameCreator.CreateGame();

            // ASSERT
            _kingdomState.Received(1).AddPile<Estate>(12);
            _kingdomState.Received(1).AddPile<Duchy>(12);
            _kingdomState.Received(1).AddPile<Province>(12);
        }

        [Test]
        [TestCase(2, TestName = "Two Players")]
        [TestCase(3, TestName = "Three Players")]
        [TestCase(4, TestName = "Four Players")]
        public void StartsWithTheCorrectNumberOfCoppersRemovedAndStandardNumberOfSilversAndGolds(int numPlayers)
        {
            // ARRANGE
            AddPlayers(numPlayers);
            
            // ACT
            _gameCreator.CreateGame();

            // ASSERT
            var expectedCoppers = 60 - (7*numPlayers);
            _kingdomState.Received(1).AddPile<Copper>(expectedCoppers);
            _kingdomState.Received(1).AddPile<Silver>(40);
            _kingdomState.Received(1).AddPile<Gold>(30);
        }

        [Test]
        public void EachPlayerGetsGivenTheCorrectStartingCards()
        {
            // ARRANGE
            AddPlayers(4);
            
            // ACT
            _gameCreator.CreateGame();

            // ASSERT
            _playerState1.Received(3).GainCard<Estate>();
            _playerState1.Received(7).GainCard<Copper>();
        }

        private void AddPlayers(int numPlayers)
        {
            foreach (var id in Enumerable.Range(1, numPlayers))
            {
                var player = Substitute.For<IPlayer>();
                player.Id.Returns(id);
                _gameCreator.AddPlayer(player);
            }
        }
    }
}
