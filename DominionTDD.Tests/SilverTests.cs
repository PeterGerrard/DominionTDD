using NUnit.Framework;

namespace DominionTDD.Tests
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