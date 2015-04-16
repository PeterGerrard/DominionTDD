using DominionTDD.Cards;
using DominionTDD.State;
using NUnit.Framework;

namespace DominionTDD.Tests.State
{
    [TestFixture]
    public class HandTests
    {
        private Hand _hand;

        [SetUp]
        public void SetUp()
        {
            _hand = new Hand();
        }

        [Test]
        public void CanRemoveACard()
        {
            // ARRANGE
            var card = new Copper();
            _hand.AddCard(card);

            // ACT
            _hand.RemoveCard(card);

            // ASSERT
            Assert.That(_hand.Contains(card), Is.False);
        }

        [Test]
        public void RemovingACardNotInTheHandThrowsAnException()
        {
            // ASSERT
            Assert.Throws<CardNotInHandException>(() => _hand.RemoveCard(new Copper()));
        }
    }
}