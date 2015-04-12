using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
{
    class SilverTests : CardTests
    {
        [Test]
        public void CostsThreeMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Silver(), 3));
        }
    }
}