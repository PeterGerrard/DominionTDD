using NUnit.Framework;

namespace DominionTDD.Tests
{
    class ProvinceTests : CardTests
    {
        [Test]
        public void CostsEightMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Province(), 8));
        }
    }
}