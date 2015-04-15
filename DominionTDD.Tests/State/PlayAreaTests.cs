using DominionTDD.Cards;
using DominionTDD.State;
using NUnit.Framework;

namespace DominionTDD.Tests.State
{
    [TestFixture]
    public class PlayAreaTests
    {
        private PlayArea _playArea;

        [SetUp]
        public void SetUp()
        {
            _playArea = new PlayArea();
        }

        [Test]
        public void PlayAreaStartsEmpty()
        {
            // ASSERT
            Assert.That(_playArea.Cards(), Is.Empty);
        }

        [Test]
        public void CanSeeASingleCardAddedIntoThePlayArea()
        {
            // ARRANGE
            var copper = new Copper();

            // ACT
            _playArea.AddCard(copper);

            // ASSERT
            Assert.That(_playArea.Cards(), Is.EquivalentTo(new []{copper}));
        }

        [Test]
        public void CanSeeAllCardsWhenMultipleAdded()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();

            // ACT
            _playArea.AddCard(copper);
            _playArea.AddCard(silver);

            // ASSERT
            Assert.That(_playArea.Cards(), Is.EquivalentTo(new ICard[] { copper, silver }));
        }

        [Test]
        public void RemovingAllCardsWhenEmptyReturnsEmptySet()
        {  
            // ACT
            var removed = _playArea.TakeAll();

            // ASSERT
            Assert.That(removed, Is.Empty);
        }

        [Test]
        public void RemovingMultipleCardsGetsAllTheCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _playArea.AddCard(copper);
            _playArea.AddCard(silver);

            // ACT
            var removed = _playArea.TakeAll();

            // ASSERT
            Assert.That(removed, Is.EquivalentTo(new ICard[] { copper, silver }));
        }

        [Test]
        public void TakingAllCardsLeavesItEmpty()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _playArea.AddCard(copper);
            _playArea.AddCard(silver);

            // ACT
            _playArea.TakeAll();

            // ASSERT
            Assert.That(_playArea.Cards(), Is.Empty);
        }
    }
}
