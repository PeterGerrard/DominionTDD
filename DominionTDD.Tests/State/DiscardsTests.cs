using DominionTDD.Cards;
using DominionTDD.State;
using NUnit.Framework;

namespace DominionTDD.Tests.State
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
        public void TopCardOfAnEmptyDiscardsIsNull()
        {
            Assert.That(_discards.TopCard, Is.Null);
        }

        [Test]
        public void AfterAddingACardThatIsTheTopCard()
        {
            // ACT
            _discards.AddCard(_copper);

            // ASSERT
            Assert.That(_discards.TopCard, Is.InstanceOf<Copper>());
        }

        [Test]
        public void AfterAddingMultipleCardsTheLastIsTheTopCard()
        {
            // ACT
            _discards.AddCard(_copper);
            _discards.AddCard(_estate);
            
            // ASSERT
            Assert.That(_discards.TopCard, Is.InstanceOf<Estate>());
        }

        [Test]
        public void AfterTakingCardsTheTopCardIsNull()
        {
            // ARRANGE
            _discards.AddCard(_copper);

            // ACT
            _discards.TakeAll();

            // ASSERT
            Assert.That(_discards.TopCard, Is.Null);
        }
    }
}