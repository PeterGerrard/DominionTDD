namespace DominionTDD.Tests
{
    class CardTests
    {
        protected bool CardCostsTheCorrectPrice(ICard card, int cost)
        {
            return card.Cost == cost;
        }
    }
}