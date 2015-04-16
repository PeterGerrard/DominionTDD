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
            Assert.That(_playArea.GetCards(), Is.Empty);
        }

        [Test]
        public void CanSeeASingleCardAddedIntoThePlayArea()
        {
            // ARRANGE
            var copper = new Copper();
            _playArea.AddCard(copper);

            // ACT
            var playedCards = _playArea.GetCards();

            // ASSERT
            Assert.That(playedCards, Is.EquivalentTo(new[] { copper }));
        }

        [Test]
        public void CanSeeAllCardsWhenMultipleAdded()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _playArea.AddCard(copper);
            _playArea.AddCard(silver);

            // ACT
            var playedCards = _playArea.GetCards();

            // ASSERT
            Assert.That(playedCards, Is.EquivalentTo(new ICard[] { copper, silver }));
        }
    }
}
