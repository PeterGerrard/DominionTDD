using NUnit.Framework;

namespace DominionTDD.Tests
{
    class DuchyTests : CardTests
    {
        [Test]
        public void CostsFiveMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Duchy(), 5));
        }
    }
}