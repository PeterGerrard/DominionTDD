using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
{
    class GoldTests : CardTests
    {
        [Test]
        public void CostsSixMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Gold(), 6));
        }
    }
}