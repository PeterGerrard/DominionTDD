using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IHand
    {
        void AddCard(ICard card);
        IEnumerable<ICard> TakeAll();
        void RemoveCard(ICard card);
        bool Contains(ICard card);
    }
}