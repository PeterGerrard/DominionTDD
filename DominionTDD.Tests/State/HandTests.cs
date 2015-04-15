using System.Collections.Generic;
using System.Linq;
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
        public void HandStartsEmpty()
        {
            // ASSERT
            AssertHandContainsOnlyTheseCards(Enumerable.Empty<ICard>(), Enumerable.Empty<ICard>());
        }

        [Test]
        public void AfterAddingACardThatCardIsInTheHand()
        {
            // ARRANGE
            var card = new Copper();

            // ACT
            _hand.AddCard(card);

            // ASSERT
            AssertHandContainsOnlyTheseCards(new []{card}, Enumerable.Empty<ICard>());
        }

        [Test]
        public void CanAddMultipleCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            var gold = new Gold();

            // ACT
            _hand.AddCard(copper);
            _hand.AddCard(silver);

            // ASSERT
            AssertHandContainsOnlyTheseCards(new ICard[]{copper, silver}, new []{gold});
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
            AssertHandContainsOnlyTheseCards(Enumerable.Empty<ICard>(), new []{card});
        }

        [Test]
        public void RemovingACardNotInTheHandThrowsAnException()
        {
            // ASSERT
            Assert.Throws<CardNotInHandException>(() => _hand.RemoveCard(new Copper()));
        }

        [Test]
        public void EmptyingAnEmptyHandReturnsNothing()
        {
            // ACT
            var removed = _hand.TakeAll();

            // ASSERT
            Assert.That(removed, Is.Empty);
        }

        [Test]
        public void EmptyingANonEmptyHandGetsTheAddedCards()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _hand.AddCard(copper);
            _hand.AddCard(silver);

            // ACT
            var removed = _hand.TakeAll();

            // ASSERT
            Assert.That(removed, Is.EqualTo(new ICard[]{copper, silver}));
        }

        [Test]
        public void EmptyingANonEmptyHandLeavesItEmpty()
        {
            // ARRANGE
            var copper = new Copper();
            var silver = new Silver();
            _hand.AddCard(copper);
            _hand.AddCard(silver);

            // ACT
            var removed = _hand.TakeAll();

            // ASSERT
            AssertHandContainsOnlyTheseCards(Enumerable.Empty<ICard>(), new ICard[]{copper, silver});
        }

        private void AssertHandContainsOnlyTheseCards(IEnumerable<ICard> contains, IEnumerable<ICard> notContains)
        {
            Assert.That(_hand.Count, Is.EqualTo(contains.Count()));
            foreach (var card in contains)
            {
                Assert.That(_hand.Contains(card), Is.True);
            }
            foreach (var card in notContains)
            {
                Assert.That(_hand.Contains(card), Is.False);
            }
        }
    }
}