using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests
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
        public void DeckStartsEmpty()
        {
            // ASSERT
            Assert.That(_deck.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanAddACardToTheDeck()
        {
            // ARRANGE
            var card = new Copper();

            // ACT
            _deck.PlaceOnTop(card);

            // ASSERT
            Assert.That(_deck.Count, Is.EqualTo(1));
        }

        [Test]
        public void AfterAddingACardItIsTheTopCard()
        {
            // ARRANGE
            var added = new Copper();

            // ACT
            _deck.PlaceOnTop(added);
            var taken = _deck.TakeCard();

            // ASSERT
            Assert.That(taken, Is.EqualTo(added));
        }

        [Test]
        public void AfterRemovingTheSingleCardTheDeckIsEmpty()
        {
            // ARRANGE
            var card = new Copper();
            _deck.PlaceOnTop(card);

            // ACT
            _deck.TakeCard();

            // ASSERT
            Assert.That(_deck.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanAddMultipleCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _deck.PlaceOnTop(copper);
            _deck.PlaceOnTop(silver);

            // ASSERT
            Assert.That(_deck.Count, Is.EqualTo(2));
        }

        [Test]
        public void LastAddedCardIsTheTopCard()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _deck.PlaceOnTop(copper);
            _deck.PlaceOnTop(silver);
            var topCard = _deck.TakeCard();

            // ASSERT
            Assert.That(topCard, Is.EqualTo(silver));
        }

        [Test]
        public void FirstAddedCardIsBottomCard()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _deck.PlaceOnTop(copper);
            _deck.PlaceOnTop(silver);
            var topCard = _deck.TakeCard();
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
