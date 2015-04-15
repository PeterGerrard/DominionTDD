using System.Linq;
using DominionTDD.Cards;
using DominionTDD.State;
using NSubstitute;
using NUnit.Framework;

namespace DominionTDD.Tests.State
{
    [TestFixture]
    public class PlayerStateTests
    {
        private PlayerState _playerState;
        private IHand _hand;
        private IDeck _deck;
        private IDiscards _discards;
        private IShuffler<ICard> _shuffler;
        private IPlayArea _playArea;

        [SetUp]
        public void SetUp()
        {
            _hand = Substitute.For<IHand>();
            _deck = Substitute.For<IDeck>();
            _deck.IsEmpty().Returns(true);
            _discards = Substitute.For<IDiscards>();
            _discards.IsEmpty().Returns(true);
            _shuffler = Substitute.For<IShuffler<ICard>>();
            _playArea = Substitute.For<IPlayArea>();
            _playerState = new PlayerState(_deck, _hand, _discards, _shuffler, _playArea);
        }

        [Test]
        public void DrawingCardsWhenDeckIsEmptyDoesNotAttemptAnyDraws()
        {
            // ACT
            _playerState.DrawCard();

            // ASSERT
            _deck.DidNotReceive().TakeCard();
        }

        [Test]
        public void TheCardDrawnFromTheDeckIsAddedToTheHand()
        {
            // ARRANGE
            var card = new Copper();
            _deck.TakeCard().Returns(card);
            _deck.IsEmpty().Returns(false);

            // ACT
            _playerState.DrawCard();

            // ASSERT
            _deck.Received(1).TakeCard();
            _hand.Received(1).AddCard(card);
        }

        [Test]
        public void WhenDeckIsEmptyAndDiscardsIsNotThenDrawingCausesDiscardsToBeShuffledIntoDeck()
        {
            // ARRANGE
            var taken = Enumerable.Repeat(new Copper(), 1);
            var shuffled = Enumerable.Repeat(new Silver(), 1);
            _discards.IsEmpty().Returns(false);
            _discards.TakeAll().Returns(taken);
            _shuffler.Shuffle(taken).Returns(shuffled);

            // ACT
            _playerState.DrawCard();

            // ASSERT
            _discards.Received(1).TakeAll();
            _shuffler.Received(1).Shuffle(taken);
            _deck.Received(1).AddCards(shuffled);
        }

        [Test]
        public void WhenDiscardHandTheyAllEndInDiscards()
        {
            // ARRANGE
            var hand = Enumerable.Repeat(new Copper(), 1);
            _hand.TakeAll().Returns(hand);

            // ACT
            _playerState.DiscardHand();

            // ASSERT
            _discards.Received(1).AddCards(hand);
        }

        [Test]
        public void PlayedCardsAreAddedToThePlayArea()
        {
            // ARRANGE
            var copper = new Copper();
            _hand.Contains(copper).Returns(true);
            var hand = Enumerable.Repeat(copper, 1);

            // ACT
            _playerState.PlayCard(copper);

            // ASSERT
            _hand.Received(1).RemoveCard(copper);
            _playArea.AddCard(copper);
        }

        [Test]
        public void DoesntAttemptToPlayCardNotInHand()
        {
            // ARRANGE
            var copper = new Copper();

            // ACT
            _playerState.PlayCard(copper);

            // ASSERT
            _hand.DidNotReceive().RemoveCard(copper);
            _playArea.DidNotReceive().AddCard(copper);
        }

        [Test]
        public void EmptyingPlayAreaAddsItToDiscards()
        {
            // ARRANGE
            var cards = new []{new Copper()};
            _playArea.TakeAll().Returns(cards);
            
            // ACT
            _playerState.EmptyPlayArea();

            // ASSERT
            _playArea.Received(1).TakeAll();
            _discards.Received(1).AddCards(cards);
        }

        [Test]
        public void GainCardAddsToDiscards()
        {
            // ARRANGE
            var card = new Copper();

            // ACT
            _playerState.GainCard(card);

            // ASSERT
            _discards.Received(1).AddCard(card);
        }
    }
}