using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IDeck
    {
        ICard TakeCard();
        int Count { get; }
        void PlaceOnTop(ICard card);
    }
}