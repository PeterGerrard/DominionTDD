using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface ICardPile
    {
        int Count { get; }
        void AddCard(ICard card);
    }
}