using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IDeck
    {
        ICard TakeCard();
        bool IsEmpty();
        void AddCards(IEnumerable<ICard> cards);
    }
}