using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IDeck : ICardPile
    {
        ICard TakeCard();
    }
}