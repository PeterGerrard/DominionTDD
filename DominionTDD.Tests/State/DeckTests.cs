using DominionTDD.Cards;
using DominionTDD.State;
using NUnit.Framework;

namespace DominionTDD.Tests.State
{
    [TestFixture]
    public class DeckTests
    {
        private Deck _deck;

        [SetUp]
        public void SetUp()
        {
            _deck = new Deck();
        }

        [Test]
        public void AfterAddingACardItIsTheTopCard()
        {
            // ARRANGE
            var added = new Copper();

            // ACT
            _deck.AddCard(added);
            var taken = _deck.TakeCard();

            // ASSERT
            Assert.That(taken, Is.EqualTo(added));
        }

        [Test]
        public void AfterRemovingTheSingleCardTheDeckIsEmpty()
        {
            // ARRANGE
            var card = new Copper();
            _deck.AddCard(card);

            // ACT
            _deck.TakeCard();

            // ASSERT
            Assert.That(_deck.Count, Is.EqualTo(0));
        }

        [Test]
        public void LastAddedCardIsTheTopCard()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _deck.AddCard(copper);
            _deck.AddCard(silver);

            // ASSERT
            var topCard = _deck.TakeCard();
            Assert.That(topCard, Is.EqualTo(silver));
        }

        [Test]
        public void FirstAddedCardIsBottomCard()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _deck.AddCard(copper);
            _deck.AddCard(silver);
            _deck.TakeCard();
            var bottomCard = _deck.TakeCard();

            // ASSERT
            Assert.That(bottomCard, Is.EqualTo(copper));
        }

        [Test]
        public void AttemptingToTakeACardFromAnEmptyDeckThrowsAnError()
        {
            // ASSERT
            Assert.Throws<DeckIsEmptyException>(() => _deck.TakeCard());
        }
    }
}
