using DominionTDD.Cards;

namespace DominionTDD.Tests.Cards
{
    class CardTests
    {
        protected bool CardCostsTheCorrectPrice(ICard card, int cost)
        {
            return card.Cost == cost;
        }
    }
}