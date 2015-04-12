using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
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