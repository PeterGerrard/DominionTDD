using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IDiscards
    {
        bool IsEmpty();
        IEnumerable<ICard> TakeAll();
        void AddCards(IEnumerable<ICard> cards);
        void AddCard(ICard card);
    }
}