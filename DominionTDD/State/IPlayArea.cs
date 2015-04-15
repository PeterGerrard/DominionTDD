using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IPlayArea
    {
        void AddCard(ICard card);
        IEnumerable<ICard> TakeAll();
    }
}