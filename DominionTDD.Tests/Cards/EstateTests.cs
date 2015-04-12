using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
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