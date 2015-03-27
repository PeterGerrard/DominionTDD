using NUnit.Framework;

namespace DominionTDD.Tests
{
    class EstateTests : CardTests
    {
        [Test]
        public void CostsTwoMoney()
        {
            Assert.IsTrue(CardCostsTheCorrectPrice(new Estate(), 2));
        }
    }
}