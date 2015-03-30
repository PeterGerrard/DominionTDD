using System.Linq;
using NUnit.Framework;

namespace DominionTDD.Tests
{
    [TestFixture]
    public class DiscardsTests
    {
        private Discards _discards;
        private Copper _copper;
        private Estate _estate;

        [SetUp]
        public void SetUp()
        {
            _discards = new Discards();
            _copper = new Copper();
            _estate = new Estate();
        }

        [Test]
        public void NewDiscardPileIsEmpty()
        {
            Assert.That(_discards.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanAddOneCardToDiscards()
        {
            // ACT
            _discards.Add(_copper);

            // ASSERT
            Assert.That(_discards.Count, Is.EqualTo(1));
        }

        [Test]
        public void CanAddMultipleCardsAtOnceToDiscards()
        {
            // ACT
            _discards.Add(_copper);
            _discards.Add(_estate);

            // ASSERT
            Assert.That(_discards.Count, Is.EqualTo(2));
        }

        [Test]
        public void TopCardOfAnEmptyDiscardsIsNull()
        {
            Assert.That(_discards.TopCard, Is.Null);
        }

        [Test]
        public void AfterAddingACardThatIsTheTopCard()
        {
            // ACT
            _discards.Add(_copper);

            // ASSERT
            Assert.That(_discards.TopCard, Is.InstanceOf<Copper>());
        }

        [Test]
        public void AfterAddingMultipleCardsIndividuallyTheLastIsTheTopCard()
        {
            // ACT
            _discards.Add(_copper);
            _discards.Add(_estate);
            
            // ASSERT
            Assert.That(_discards.TopCard, Is.InstanceOf<Estate>());
        }

        [Test]
        public void TakingTheCardsFromAnEmptyDiscardsReturnsNoCards()
        {
            // ACT
            var taken = _discards.TakeAll();

            // ASSERT
            Assert.That(taken.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TakingAnIndividualCardGetsYouThatOneCard()
        {
            // ARRANGE
            _discards.Add(_copper);

            // ACT
            var taken = _discards.TakeAll();

            // ASSERT
            Assert.That(taken, Is.EquivalentTo(new []{_copper}));
        }

        [Test]
        public void TakingMultipleCardsGetsAllOfThem()
        {
            // ARRANGE
            _discards.Add(_copper);
            _discards.Add(_estate);

            // ACT
            var taken = _discards.TakeAll();

            // ASSERT
            Assert.That(taken, Is.EquivalentTo(new ICard[]{_copper, _estate}));
        }

        [Test]
        public void AfterTakingCardsTheDiscardsIsEmpty()
        {
            // ARRANGE
            _discards.Add(_copper);
            _discards.Add(_estate);
            
            // ACT
            _discards.TakeAll();

            // ASSERT
            Assert.That(_discards.Count, Is.EqualTo(0));
        }

        [Test]
        public void AfterTakingCardsTheTopCardIsNull()
        {
            // ARRANGE
            _discards.Add(_copper);

            // ACT
            _discards.TakeAll();

            // ASSERT
            Assert.That(_discards.TopCard, Is.Null);
        }
    }
}