using NUnit.Framework;

namespace DominionTDD.Tests
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
