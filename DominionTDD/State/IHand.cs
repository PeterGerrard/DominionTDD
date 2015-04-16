using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IHand : ICardPile, ITakeAllCards
    {
        void RemoveCard(ICard card);
        bool Contains(ICard card);
    }
}