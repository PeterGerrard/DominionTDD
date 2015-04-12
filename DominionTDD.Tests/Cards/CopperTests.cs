using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
{
    class CopperTests : CardTests
    {
        [Test]
        public void CostsZeroMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Copper(), 0));
        }
    }
}
