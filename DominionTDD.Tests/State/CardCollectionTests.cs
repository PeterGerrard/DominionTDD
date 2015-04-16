using DominionTDD.Cards;
using DominionTDD.State;
using NUnit.Framework;

namespace DominionTDD.Tests.State
{
    [TestFixture]
    public class CardCollectionTests
    {
        private CardCollection _cards;

        [SetUp]
        public void SetUp()
        {
            _cards = new CardCollection();
        }

        [Test]
        public void CollectionStartsEmpty()
        {
            // ASSERT
            Assert.That(_cards.Count, Is.EqualTo(0));
        }

        [Test]
        public void AfterAddingACardThatCardIsInTheCollection()
        {
            // ARRANGE
            var card = new Copper();

            // ACT
            _cards.AddCard(card);

            // ASSERT
            Assert.That(_cards.TakeAll(), Is.EquivalentTo(new []{card}));
        }

        [Test]
        public void CanAddMultipleCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _cards.AddCard(copper);
            _cards.AddCard(silver);

            // ASSERT
            Assert.That(_cards.TakeAll(), Is.EquivalentTo(new ICard[] { copper, silver }));
        }

        [Test]
        public void EmptyingAnEmptyCollectionReturnsNothing()
        {
            // ACT
            var removed = _cards.TakeAll();

            // ASSERT
            Assert.That(removed, Is.Empty);
        }

        [Test]
        public void EmptyingANonEmptyCollectionGetsTheAddedCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _cards.AddCard(copper);
            _cards.AddCard(silver);

            // ACT
            var removed = _cards.TakeAll();

            // ASSERT
            Assert.That(removed, Is.EqualTo(new ICard[] { copper, silver }));
        }

        [Test]
        public void EmptyingANonEmptyHandLeavesItEmpty()
        {
            // ARRANGE
            _cards.AddCard(new Copper());

            // ACT
            _cards.TakeAll();

            // ASSERT
            Assert.That(_cards.Count, Is.EqualTo(0));
        }
    }
}
