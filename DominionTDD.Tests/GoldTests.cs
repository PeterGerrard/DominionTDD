using NUnit.Framework;

namespace DominionTDD.Tests
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