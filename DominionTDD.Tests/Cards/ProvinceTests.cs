using DominionTDD.Cards;
using NUnit.Framework;

namespace DominionTDD.Tests.Cards
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