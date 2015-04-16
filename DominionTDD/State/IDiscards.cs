using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface IDiscards
    {
        int Count { get; }
        IEnumerable<ICard> TakeAll();
        void Add(ICard card);
    }
}