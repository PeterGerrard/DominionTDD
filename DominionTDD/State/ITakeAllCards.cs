using System.Collections.Generic;
using DominionTDD.Cards;

namespace DominionTDD.State
{
    public interface ITakeAllCards
    {
        IEnumerable<ICard> TakeAll();
    }
}