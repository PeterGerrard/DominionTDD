using System.Collections.Generic;
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
            _discards = Substitute.For<IDiscards>();
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
            _deck.Count.Returns(1);

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
            var silver = new Silver();
            var shuffled = Enumerable.Repeat(silver, 1);
            _discards.Count.Returns(1);
            _discards.TakeAll().Returns(Enumerable.Empty<ICard>());
            _shuffler.Shuffle(Arg.Any<IEnumerable<ICard>>()).Returns(shuffled);

            // ACT
            _playerState.DrawCard();

            // ASSERT
            _discards.Received(1).TakeAll();
            _shuffler.Received(1).Shuffle(Arg.Any<IEnumerable<ICard>>());
            _deck.Received(1).AddCard(silver);
        }

        [Test]
        public void WhenDiscardHandTheyAllEndInDiscards()
        {
            // ARRANGE
            var copper = new Copper();
            var hand = Enumerable.Repeat(copper, 1);
            _hand.TakeAll().Returns(hand);

            // ACT
            _playerState.DiscardHand();

            // ASSERT
            _discards.Received(1).AddCard(copper);
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
            var copper = new Copper();
            _playArea.TakeAll().Returns(new []{copper});
            
            // ACT
            _playerState.EmptyPlayArea();

            // ASSERT
            _playArea.Received(1).TakeAll();
            _discards.Received(1).AddCard(copper);
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